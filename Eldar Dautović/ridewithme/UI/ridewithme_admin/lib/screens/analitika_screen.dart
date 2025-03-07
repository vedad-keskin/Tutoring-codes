import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/card_item_model.dart';
import 'package:ridewithme_admin/models/ukupna_statistika.dart';
import 'package:ridewithme_admin/providers/statistika_provider.dart';
import 'package:ridewithme_admin/screens/poslovni_izvjestaj_screen.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/info_card_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class AnalitikaScreen extends StatefulWidget {
  const AnalitikaScreen({super.key});

  @override
  State<AnalitikaScreen> createState() => _AnalitikaScreenState();
}

class _AnalitikaScreenState extends State<AnalitikaScreen> {
  late StatistikaProvider _statistikaProvider;

  UkupnaStatistika? rezultat;

  bool isLoading = true;

  int najveciBrojVoznji = 0;

  var _cardItems = [
    CardItemModel(
        title: "Korisnici",
        subtitle: "Ukupno registrovanih korisnika",
        value: "150,000"),
    CardItemModel(
        title: "Aktivne vožnje",
        subtitle: "Broj aktivnih kreiranih vožnji",
        value: "154"),
    CardItemModel(
        title: "Kuponi", subtitle: "Broj iskorištenih kupona", value: "55")
  ];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _statistikaProvider = context.read<StatistikaProvider>();

    initChart();
  }

  Future initChart() async {
    rezultat = await _statistikaProvider.monthly();

    setState(() {
      isLoading = false;
      najveciBrojVoznji = rezultat?.mjesecnaStatistika
              ?.map((e) => e.brojVoznji)
              .reduce((a, b) => a! > b! ? a : b) ??
          0;
    });

    _cardItems = [
      CardItemModel(
          title: "Korisnici",
          subtitle: "Ukupno registrovanih korisnika",
          value: rezultat!.statistika!.brojRegistrovanihKorisnika.toString()),
      CardItemModel(
          title: "Vožnje",
          subtitle: "Broj kreiranih vožnji",
          value: rezultat!.statistika!.brojKreiranihVoznji.toString()),
      CardItemModel(
          title: "Kuponi",
          subtitle: "Broj iskorištenih kupona",
          value: rezultat!.statistika!.brojIskoristenihKupona.toString()),
      CardItemModel(
          title: "Vozači",
          subtitle: "Broj vozača",
          value: rezultat!.statistika!.brojVozaca.toString()),
      CardItemModel(
          title: "Zakazane vožnje",
          subtitle: "Broj zakazanih vožnji",
          value: rezultat!.statistika!.brojZakazanihVoznji.toString()),
    ];
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 1,
      headerTitle: "Analitika",
      headerDescription: "Ovdje možete pregledati analitiku platforme.",
      child: Column(
        spacing: 10,
        children: [
          _buildBusinessReportNav(),
          isLoading ? LoadingSpinnerWidget() : _buildAnalitics(),
          _buildCards()
        ],
      ),
    );
  }

  Widget _buildBusinessReportNav() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        CustomButtonWidget(
            buttonText: "Poslovni izvještaj",
            onPress: () {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => PoslovniIzvjestajScreen(),
                ),
              );
            })
      ],
    );
  }

  Widget _buildAnalitics() {
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(15),
        color: Color(0x21C3CBCA),
      ),
      constraints: BoxConstraints(maxWidth: double.infinity, maxHeight: 340),
      child: Padding(
        padding:
            const EdgeInsets.only(bottom: 15, top: 15, left: 20, right: 20),
        child: Column(
          crossAxisAlignment:
              CrossAxisAlignment.start, // Poravnanje teksta lijevo
          children: [
            Text(
              "Broj vožnji po mjesecima",
              style: TextStyle(
                fontSize: 15,
                fontWeight: FontWeight.w500,
                color: Color(0xFF072220),
              ),
            ),
            SizedBox(height: 10), // Razmak između teksta i grafa
            Expanded(
              child: BarChart(
                BarChartData(
                  barTouchData: barTouchData,
                  titlesData: titlesData,
                  borderData: borderData,
                  barGroups: barGroups,
                  gridData: const FlGridData(show: false),
                  alignment: BarChartAlignment.spaceAround,
                  maxY: najveciBrojVoznji.toDouble() + 10,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildCards() {
    return Expanded(
      child: SingleChildScrollView(
        child: Column(
          children: [
            StaggeredGrid.count(
              crossAxisCount: 16,
              mainAxisSpacing: 10,
              crossAxisSpacing: 20,
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
              ],
            ),
          ],
        ),
      ),
    );
  }

  BarTouchData get barTouchData => BarTouchData(
        enabled: false,
        touchTooltipData: BarTouchTooltipData(
          getTooltipColor: (group) => Colors.transparent,
          tooltipPadding: EdgeInsets.zero,
          tooltipMargin: 8,
          getTooltipItem: (
            BarChartGroupData group,
            int groupIndex,
            BarChartRodData rod,
            int rodIndex,
          ) {
            return BarTooltipItem(
              rod.toY.round().toString(),
              const TextStyle(
                color: Color(0xFF072220),
                fontWeight: FontWeight.bold,
              ),
            );
          },
        ),
      );

  Widget getTitles(double value, TitleMeta meta) {
    final style = TextStyle(
      color: Color(0xFF072220),
      fontWeight: FontWeight.bold,
      fontSize: 14,
    );
    String text;
    switch (value.toInt()) {
      case 1:
        text = 'Jan';
        break;
      case 2:
        text = 'Feb';
        break;
      case 3:
        text = 'Mar';
        break;
      case 4:
        text = 'Apr';
        break;
      case 5:
        text = 'Maj';
        break;
      case 6:
        text = 'Jun';
        break;
      case 7:
        text = 'Jul';
        break;
      case 8:
        text = 'Aug';
        break;
      case 9:
        text = 'Sep';
        break;
      case 10:
        text = 'Okt';
        break;
      case 11:
        text = 'Nov';
        break;
      case 12:
        text = 'Dec';
        break;
      default:
        text = '';
        break;
    }
    return SideTitleWidget(
      meta: meta,
      space: 4,
      child: Text(text, style: style),
    );
  }

  FlTitlesData get titlesData => FlTitlesData(
        show: true,
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            reservedSize: 30,
            getTitlesWidget: getTitles,
          ),
        ),
        leftTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        topTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        rightTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
      );

  FlBorderData get borderData => FlBorderData(
        show: false,
      );

  List<BarChartGroupData> get barGroups =>
      rezultat?.mjesecnaStatistika
          ?.map(
            (e) => BarChartGroupData(
              x: e.mjesec ?? 0,
              barRods: [
                BarChartRodData(
                    width: 25,
                    toY: e.brojVoznji?.toDouble() ?? 0,
                    color: Color(0xFF39D5C3))
              ],
              showingTooltipIndicators: [0],
            ),
          )
          .toList() ??
      [];
}
