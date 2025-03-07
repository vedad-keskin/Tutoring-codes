import 'package:carousel_slider/carousel_options.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/grad.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/gradovi_provider.dart';
import 'package:ridewithme_mobile/providers/voznje_provider.dart';
import 'package:ridewithme_mobile/screens/voznje_create_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_search_screen.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_mobile/widgets/ride_widget.dart';
import 'package:ridewithme_mobile/widgets/town_widget.dart';

class VoznjeScreen extends StatefulWidget {
  const VoznjeScreen({super.key});

  @override
  State<VoznjeScreen> createState() => _VoznjeScreenState();
}

class _VoznjeScreenState extends State<VoznjeScreen> {
  late VoznjeProvider _voznjeProvider;
  late GradoviProvider _gradoviProvider;

  SearchResult<Voznja>? recentRides;
  SearchResult<Voznja>? cheapRides;
  SearchResult<Gradovi>? gradoviResults;

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _voznjeProvider = context.read<VoznjeProvider>();
    _gradoviProvider = context.read<GradoviProvider>();

    initPage();
  }

  Future<void> initPage() async {
    final results = await Future.wait([
      _voznjeProvider.get(filter: {
        "IsGradoviIncluded": true,
        'IsKorisniciIncluded': true,
        "OrderBy": "DatumKreiranja DESC",
        "Status": "active"
      }),
      _voznjeProvider.get(filter: {
        "IsGradoviIncluded": true,
        "OrderBy": "Cijena asc",
        'IsKorisniciIncluded': true,
        "Status": "active"
      }),
      _gradoviProvider.get(),
    ]);

    setState(() {
      recentRides = results[0] as SearchResult<Voznja>?;
      cheapRides = results[1] as SearchResult<Voznja>?;
      gradoviResults = results[2] as SearchResult<Gradovi>?;

      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 1,
      header: "Vožnje",
      headerDescription: "Ovdje možete da pronađete vožnje ",
      headerColor: Color(0xFF7463DE),
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            spacing: 15,
            children: [
              _buildSearch(),
              _buildTownList(),
              _buildRecentRides(),
              _buildCheapRides(),
              _buildSorryScreen()
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildSorryScreen() {
    if (recentRides?.count == 0 &&
        cheapRides?.count == 0 &&
        isLoading == false) {
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
            'Trenutno nema dostupnih vožnji.',
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
        onTap: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => VoznjeSearchScreen(),
            ),
          );
        },
        decoration: BoxDecoration(
          border: Border.all(color: Color(0xFFE3E3E3), width: 1),
          color: Color(0xFFF3FCFC),
          borderRadius: BorderRadius.circular(5),
        ),
      ),
    );
  }

  Widget _buildTownList() {
    if (!isLoading && cheapRides?.count == 0) {
      return Container();
    }

    return Column(
      spacing: 10,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Padding(
          padding: const EdgeInsets.only(left: 20, bottom: 10.0, top: 10),
          child: Text(
            "Gdje želite da putujete?",
            style: TextStyle(
                fontFamily: "Inter",
                color: Colors.black,
                fontSize: 12,
                fontWeight: FontWeight.w500),
          ),
        ),
        isLoading
            ? LoadingSpinnerWidget(
                height: 65,
              )
            : CarouselSlider(
                options: CarouselOptions(
                  height: 65,
                  enableInfiniteScroll: true,
                  viewportFraction: 0.4,
                  enlargeStrategy: CenterPageEnlargeStrategy.scale,
                ),
                items: gradoviResults?.result.map((grad) {
                      return GestureDetector(
                        onTap: () {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => VoznjeSearchScreen(
                                initialValue: {"GradDoId": grad.id},
                              ),
                            ),
                          );
                        },
                        child: TownWidget(
                          grad: grad,
                        ),
                      );
                    }).toList() ??
                    [],
              )
      ],
    );
  }

  Widget _buildCheapRides() {
    if (!isLoading && cheapRides?.count == 0) {
      return Container();
    }

    return Container(
      margin: EdgeInsets.only(bottom: 20),
      child: Column(
        spacing: 10,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.only(left: 20, bottom: 10.0, top: 10),
            child: Text(
              "Jeftine vožnje:",
              style: TextStyle(
                  fontFamily: "Inter",
                  color: Colors.black,
                  fontSize: 12,
                  fontWeight: FontWeight.w500),
            ),
          ),
          isLoading
              ? LoadingSpinnerWidget(
                  height: 160,
                )
              : CarouselSlider(
                  options: CarouselOptions(
                    height: 160,
                    enableInfiniteScroll: true,
                    autoPlay: false,
                    viewportFraction: 0.55,
                    enlargeStrategy: CenterPageEnlargeStrategy.scale,
                  ),
                  items: cheapRides?.result.map((voznja) {
                        return RideWidget(
                          voznja: voznja,
                          boxColor: Color(0xFF39D5C3),
                        );
                      }).toList() ??
                      [],
                ),
        ],
      ),
    );
  }

  Widget _buildRecentRides() {
    if (!isLoading && recentRides?.count == 0) {
      return Container();
    }

    return Container(
      margin: EdgeInsets.only(bottom: 20),
      child: Column(
        spacing: 10,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.only(left: 20, bottom: 10.0, top: 10),
            child: Text(
              "Nedavno objavljene vožnje:",
              style: TextStyle(
                  fontFamily: "Inter",
                  color: Colors.black,
                  fontSize: 12,
                  fontWeight: FontWeight.w500),
            ),
          ),
          isLoading
              ? LoadingSpinnerWidget(
                  height: 160,
                )
              : CarouselSlider(
                  options: CarouselOptions(
                    height: 160,
                    enableInfiniteScroll: true,
                    autoPlay: false,
                    viewportFraction: 0.55,
                    enlargeStrategy: CenterPageEnlargeStrategy.scale,
                  ),
                  items: recentRides?.result.map((voznja) {
                        return RideWidget(
                          voznja: voznja,
                          boxColor: Color(0xFF7463DE),
                        );
                      }).toList() ??
                      [],
                ),
        ],
      ),
    );
  }
}
