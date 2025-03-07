import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/korisnici_dostignuca.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';
import 'package:ridewithme_mobile/providers/korisnik_provider.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class AchievementsScreen extends StatefulWidget {
  const AchievementsScreen({super.key});

  @override
  State<AchievementsScreen> createState() => _AchievementsScreenState();
}

class _AchievementsScreenState extends State<AchievementsScreen> {
  late KorisnikProvider _korisnikProvider;

  Korisnik? result;

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _korisnikProvider = context.read<KorisnikProvider>();

    initView();
  }

  Future initView() async {
    result = await _korisnikProvider.getById(Authorization.id ?? 0);

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 4,
      header: "Dostignuća",
      headerDescription: "Ovdje možete pregledati osvojena dostignuća.",
      headerColor: Color(0xFF7463DE),
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            children: [
              isLoading
                  ? LoadingSpinnerWidget(height: 100)
                  : (result == null || result!.korisniciDostignuca!.isEmpty)
                      ? Padding(
                          padding: const EdgeInsets.all(20),
                          child: Text(
                            "Nemate niti jedno dostignuće.",
                            textAlign: TextAlign.center,
                            style: TextStyle(
                              fontFamily: "Inter",
                              fontSize: 16,
                              fontWeight: FontWeight.w600,
                            ),
                          ),
                        )
                      : _buildView()
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildView() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Column(
        spacing: 10,
        children: result?.korisniciDostignuca?.map((element) {
              return _buildAchievementRow(element);
            }).toList() ??
            [],
      ),
    );
  }

  Widget _buildAchievementRow(KorisniciDostignuca dostignuce) {
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(15),
        color: const Color(0xFF7463DE).withAlpha(40),
      ),
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 20),
        child: Row(
          children: [
            Expanded(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    dostignuce.dostignuce?.naziv ?? '',
                    style: const TextStyle(
                      fontFamily: "Inter",
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                    ),
                    overflow: TextOverflow.ellipsis,
                    maxLines: 1,
                  ),
                  Text(
                    dostignuce.dostignuce?.opis ?? '',
                    style: const TextStyle(
                      fontFamily: "Inter",
                      fontSize: 14,
                      fontWeight: FontWeight.w500,
                    ),
                    overflow: TextOverflow.ellipsis,
                    maxLines: 2,
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
