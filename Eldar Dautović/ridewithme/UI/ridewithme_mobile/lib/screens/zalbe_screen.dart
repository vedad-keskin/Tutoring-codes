import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/zalba.dart';
import 'package:ridewithme_mobile/providers/zalbe_provider.dart';
import 'package:ridewithme_mobile/screens/profile_screen.dart';
import 'package:ridewithme_mobile/screens/zalbe_create_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/complaint_widget_detailed.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class ZalbeScreen extends StatefulWidget {
  const ZalbeScreen({super.key});

  @override
  State<ZalbeScreen> createState() => _ZalbeScreenState();
}

class _ZalbeScreenState extends State<ZalbeScreen> {
  late ZalbeProvider _zalbeProvider;

  SearchResult<Zalba>? zalbeResults;

  bool isLoading = true;

  final Map<String, Color> complaintColors = {
    'active': Color(0xFF7463DE),
    'processing': Color(0xFFD5C339),
    'completed': Color(0xFF39D5C3),
  };

  final Map<String, String> complaintTitles = {
    "active": "Aktivna",
    "processing": "U obradi",
    "completed": "Završena",
  };

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _zalbeProvider = context.read<ZalbeProvider>();

    initData();
  }

  Future initData() async {
    zalbeResults = await _zalbeProvider.get(filter: {
      "KorisnikId": Authorization.id,
      "IsVrstaZalbeIncluded": true,
      "IsAdministratorIncluded": true,
      "IsKorisnikIncluded": true
    });

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 4,
      header: "Žalbe",
      headerDescription: "Žalbe koje ste Vi kreirali",
      backButton: ProfileScreen(),
      headerColor: Color(0xFF39D5C3),
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    CustomButtonWidget(
                        buttonText: "Kreiraj žalbu",
                        fontSize: 13,
                        onPress: () {
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => ZalbeCreateScreen()),
                          );
                        }),
                  ],
                ),
              ),
              Column(
                spacing: 10,
                children: isLoading
                    ? [LoadingSpinnerWidget(height: 200)]
                    : (zalbeResults == null || zalbeResults!.result.isEmpty)
                        ? [
                            Padding(
                              padding: const EdgeInsets.all(20),
                              child: Text(
                                "Nemate niti jednu kreiranu žalbu.",
                                textAlign: TextAlign.center,
                                style: TextStyle(
                                  fontFamily: "Inter",
                                  fontSize: 16,
                                  fontWeight: FontWeight.w600,
                                ),
                              ),
                            )
                          ]
                        : complaintTitles.keys
                            .map((state) => _buildComplaints(state))
                            .toList(),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildComplaints(String state) {
    var filteredRides =
        zalbeResults?.result.where((e) => e.stateMachine == state).toList() ??
            [];
    if (filteredRides.isEmpty) return Container();

    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Column(
        spacing: 10,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            complaintTitles[state]!.toUpperCase(),
            style: TextStyle(
              fontSize: 15,
              fontFamily: 'Inter',
              fontWeight: FontWeight.w700,
              color: Color(0xFF000C3C).withAlpha(40),
            ),
          ),
          Column(
            spacing: 10,
            children: filteredRides.map((element) {
              return ComplaintWidgetDetailed(
                zalba: element,
                boxColor: complaintColors[state]!,
              );
            }).toList(),
          ),
          SizedBox(
            height: 10,
          )
        ],
      ),
    );
  }
}
