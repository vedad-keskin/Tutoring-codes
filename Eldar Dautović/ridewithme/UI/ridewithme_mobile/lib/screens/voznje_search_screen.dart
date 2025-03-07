import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/voznje_provider.dart';
import 'package:ridewithme_mobile/screens/voznje_create_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_screen.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/ride_widget.dart';
import 'package:ridewithme_mobile/widgets/rides_filter_widget.dart';

class VoznjeSearchScreen extends StatefulWidget {
  Map<String, dynamic>? initialValue;
  VoznjeSearchScreen({super.key, this.initialValue});

  @override
  State<VoznjeSearchScreen> createState() => _VoznjeSearchScreenState();
}

class _VoznjeSearchScreenState extends State<VoznjeSearchScreen> {
  late VoznjeProvider _voznjeProvider;

  SearchResult<Voznja>? voznjeResults;

  bool isLoading = true;

  Map<String, dynamic> _formValue = {
    'IsGradoviIncluded': true,
    'IsKorisniciIncluded': true,
    'GradOdId': null,
    'GradDoId': null,
    'OrderBy': 'DatumVrijemePocetka ASC',
    'Status': 'active'
  };

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _voznjeProvider = context.read<VoznjeProvider>();

    Map<String, dynamic> _formValue = {
      'IsGradoviIncluded': true,
      'IsKorisniciIncluded': true,
      'GradOdId': widget.initialValue?['GradOdId'],
      'GradDoId': widget.initialValue?['GradDoId'],
      'OrderBy': 'DatumVrijemePocetka ASC',
      'Status': 'active'
    };

    initResults(_formValue);
  }

  Future initResults([Map<String, dynamic>? query]) async {
    voznjeResults = await _voznjeProvider.get(filter: query);

    if (query != null) {
      _formValue = query;
    }

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 1,
      backButton: VoznjeScreen(),
      header: "Vožnje",
      headerDescription: "Ovdje možete da pretražite vožnje",
      headerColor: Color(0xFF7463DE),
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            spacing: 15,
            children: [_buildSearch(), _buildResults(), _buildSorryScreen()],
          ),
        ),
      ),
    );
  }

  Widget _buildSorryScreen() {
    if (isLoading == false && voznjeResults?.count == 0) {
      return Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Icon(
            Icons.info_outline,
            size: 50,
            color: Colors.grey,
          ),
          SizedBox(height: 10),
          Text(
            'Nema rezultata pretrage.',
            style: TextStyle(fontSize: 16, color: Colors.grey),
            textAlign: TextAlign.center,
          ),
          SizedBox(height: 10),
          CustomButtonWidget(
            buttonText: "Kreiraj vožnju",
            onPress: () {
              Navigator.of(context).push(
                CupertinoPageRoute(
                  builder: (context) => VoznjeCreateScreen(),
                ),
              );
            },
            fontSize: 12,
          ) //TODO: Dodaj navigator do kreiranja
        ],
      );
    }

    return SizedBox.shrink();
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.only(left: 20, bottom: 10.0, right: 20),
      child: CupertinoTextField(
        placeholder: "Pretraži vožnje...",
        prefix: Padding(
          padding: EdgeInsetsDirectional.fromSTEB(6, 0, 0, 3),
          child: Icon(
            CupertinoIcons.search,
            color: Color(0xFF898989),
          ),
        ),
        placeholderStyle: TextStyle(color: Color(0xFF898989)),
        readOnly: true,
        onTap: () async {
          var result = await showModalBottomSheet<Map<String, dynamic>>(
            context: context,

            builder: (BuildContext context) {
              return SizedBox(
                height: 400,
                child: RidesFilterWidget(
                  initialFilters: _formValue,
                ),
              );
            }, // Closing the builder function here
          );

          if (result != null) {
            initResults(result);
          }
        },
        decoration: BoxDecoration(
          border: Border.all(color: Color(0xFFE3E3E3), width: 1),
          color: Color(0xFFF3FCFC),
          borderRadius: BorderRadius.circular(5),
        ),
      ),
    );
  }

  Widget _buildResults() {
    return GridView.extent(
      shrinkWrap: true, // Sprečava beskonačnu visinu
      padding: const EdgeInsets.only(left: 20, right: 20),
      crossAxisSpacing: 10,
      mainAxisSpacing: 10,
      maxCrossAxisExtent: 200,
      childAspectRatio: 200 / 180, // Maksimalna širina jednog elementa
      children: voznjeResults?.result.map((element) {
            return SizedBox(
              width: 200,
              height: 160,
              child: RideWidget(
                voznja: element,
                boxColor: Color(0xFF39D5C3),
              ),
            );
          }).toList() ??
          [],
    );
  }
}
