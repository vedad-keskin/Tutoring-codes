import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/recenzija.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/providers/recenzije_provider.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_mobile/widgets/ride_widget_detailed.dart';

class RateListScreen extends StatefulWidget {
  const RateListScreen({super.key});

  @override
  State<RateListScreen> createState() => _RateListScreenState();
}

class _RateListScreenState extends State<RateListScreen> {
  late RecenzijeProvider _recenzijeProvider;

  SearchResult<Recenzija>? recenzijaResults;

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _recenzijeProvider = context.read<RecenzijeProvider>();

    initList();
  }

  Future initList() async {
    recenzijaResults = await _recenzijeProvider.get(filter: {
      'KorisnikId': Authorization.id,
      'OrderBy': "DatumKreiranja DESC"
    });

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 3,
      header: "Ocjena",
      headerDescription: "Ovdje možete da pregledate voznje koje ste ocijenili",
      headerColor: Color(0xFF39D5C3),
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            children: [
              isLoading
                  ? LoadingSpinnerWidget(height: 100)
                  : _buildRatingsList()
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildRatingsList() {
    if (recenzijaResults?.result == null || recenzijaResults!.result.isEmpty) {
      return const Center(
        child: Text(
          "Nemate ocjenjenih vožnji.",
          style: TextStyle(
            fontFamily: "Inter",
            fontSize: 16,
            fontWeight: FontWeight.w600,
          ),
        ),
      );
    }
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Column(
        spacing: 10,
        children: recenzijaResults?.result.map((element) {
              return RideWidgetDetailed(
                voznja: element.voznja!,
                boxColor: Color(0xFF39D5C3),
                rating: true,
              );
            }).toList() ??
            [],
      ),
    );
  }
}
