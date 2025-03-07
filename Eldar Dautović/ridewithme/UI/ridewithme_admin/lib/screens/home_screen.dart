import 'package:flutter/material.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/card_item_model.dart';
import 'package:ridewithme_admin/providers/statistika_provider.dart';
import 'package:ridewithme_admin/screens/kuponi_screen.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/info_card_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  late StatistikaProvider _statistikaProvider;

  List<CardItemModel> _cardItems = [];

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _statistikaProvider = context.read<StatistikaProvider>();

    initCards();
  }

  Future initCards() async {
    var result = await _statistikaProvider.get();

    _cardItems = [
      CardItemModel(
          title: "Korisnici",
          subtitle: "Ukupno registrovanih korisnika",
          value: result.result[0].brojRegistrovanihKorisnika.toString()),
      CardItemModel(
          title: "Vožnje",
          subtitle: "Broj kreiranih vožnji",
          value: result.result[0].brojKreiranihVoznji.toString()),
      CardItemModel(
          title: "Kuponi",
          subtitle: "Broj iskorištenih kupona",
          value: result.result[0].brojIskoristenihKupona.toString())
    ];

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        selectedIndex: 0,
        child: Container(
            child: isLoading
                ? Center(
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [CircularProgressIndicator()],
                    ),
                  )
                : _buildCards()));
  }

  Widget _buildCards() {
    return Column(
      children: [
        StaggeredGrid.count(
          crossAxisCount: 12,
          mainAxisSpacing: 24,
          crossAxisSpacing: 40,
          children: [
            ..._cardItems.map(
              (e) => StaggeredGridTile.count(
                crossAxisCellCount: 4,
                mainAxisCellCount: 2,
                child: InfoCardWidget(
                  cardTitle: e.title,
                  cardSubtitle: e.subtitle,
                  cardValue: e.value,
                ),
              ),
            ),
            StaggeredGridTile.count(
                crossAxisCellCount: 9,
                mainAxisCellCount: 1,
                child: _buildAuthCard()),
            StaggeredGridTile.count(
                crossAxisCellCount: 3,
                mainAxisCellCount: 4,
                child: _buildCTA()),
            StaggeredGridTile.count(
                crossAxisCellCount: 9,
                mainAxisCellCount: 3,
                child: _buildAnalitics()),
          ],
        )
      ],
    );
  }

  Widget _buildCTA() {
    return Container(
      decoration: BoxDecoration(
          gradient: LinearGradient(
              colors: [Color(0xFF39D5C3), Color(0xFF7463DE)],
              begin: Alignment.topCenter,
              end: Alignment.bottomCenter),
          borderRadius: BorderRadius.circular(10)),
      child: Center(
          child: Column(
        spacing: 14,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Container(
            constraints: BoxConstraints(
                maxWidth: MediaQuery.of(context).size.width * 0.15),
            child: Text(
              "Napravi kupon kako bi mušterije ostvarile popust na kupovinu",
              textAlign: TextAlign.center,
              style: TextStyle(
                  fontFamily: "Inter",
                  fontSize: MediaQuery.of(context).size.width * 0.010,
                  color: Color(0xFF072220),
                  fontWeight: FontWeight.w500),
            ),
          ),
          CustomButtonWidget(
              buttonText: "Kreiraj kupon",
              onPress: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => KuponiScreen(),
                  ),
                );
              })
        ],
      )),
    );
  }

  Widget _buildAnalitics() {
    return Container();
  }

  Widget _buildAuthCard() {
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(15),
        color: Color(0x29C3CBCA),
      ),
      alignment: Alignment.centerLeft,
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Text(
          "Dobrodošli nazad, ${Authorization.fullName}!",
          style: TextStyle(
              fontFamily: "Inter", fontSize: 18, fontWeight: FontWeight.w800),
        ),
      ),
    );
  }
}
