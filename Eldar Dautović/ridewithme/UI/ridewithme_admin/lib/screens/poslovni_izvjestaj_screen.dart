import 'dart:io';
import 'dart:typed_data';

import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/poslovni_izvjestaj.dart';
import 'package:ridewithme_admin/models/ukupna_statistika.dart';
import 'package:ridewithme_admin/providers/statistika_provider.dart';
import 'package:ridewithme_admin/screens/analitika_screen.dart';
import 'package:ridewithme_admin/utils/chart_utils.dart';
import 'package:ridewithme_admin/utils/file_utils.dart';
import 'package:ridewithme_admin/utils/pdf_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';
import 'package:syncfusion_flutter_pdf/pdf.dart';

class PoslovniIzvjestajScreen extends StatefulWidget {
  const PoslovniIzvjestajScreen({super.key});

  @override
  State<PoslovniIzvjestajScreen> createState() =>
      _PoslovniIzvjestajScreenState();
}

class _PoslovniIzvjestajScreenState extends State<PoslovniIzvjestajScreen> {
  late StatistikaProvider _statistikaProvider;

  List<PoslovniIzvjestaj>? izvjestajResult;
  UkupnaStatistika? ukupnaStatistikaResult;

  bool isLoading = true;

  int touchedIndex = -1;
  int usersCount = 0;

  final Uint8List fontData =
      File('./fonts/Inter-Regular.ttf').readAsBytesSync();

  final List<Map<String, dynamic>> columnData = [
    {"label": "Godina"},
    {"label": "Broj administratora"},
    {"label": "Broj korisnika"},
    {"label": "Broj kreiranih kupona"},
    {"label": "Broj iskorištenih kupona"},
    {"label": "Broj vožnji"},
    {"label": "Prihodi"},
  ];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _statistikaProvider = context.read<StatistikaProvider>();

    _initReport();
  }

  Future _initReport() async {
    izvjestajResult = await _statistikaProvider.getBusinessReport();
    ukupnaStatistikaResult = await _statistikaProvider.monthly();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 1,
      backButton: AnalitikaScreen(),
      headerTitle: "Poslovni izvještaj",
      headerDescription:
          "Ovdje možete da pogledate poslovni izvještaj i printate isti.",
      child: Column(
        spacing: 10,
        children: [
          _buildPrintButton(),
          _buildResultView(),
          isLoading ? LoadingSpinnerWidget() : _buildPieChart()
        ],
      ),
    );
  }

  Widget _buildPieChart() {
    return Expanded(
      child: AspectRatio(
        aspectRatio: 1,
        child: PieChart(
          PieChartData(
            pieTouchData: PieTouchData(
              touchCallback: (FlTouchEvent event, pieTouchResponse) {
                setState(() {
                  touchedIndex = event.isInterestedForInteractions &&
                          pieTouchResponse?.touchedSection != null
                      ? pieTouchResponse!.touchedSection!.touchedSectionIndex
                      : -1;
                });
              },
            ),
            startDegreeOffset: 90,
            sectionsSpace: 4,
            centerSpaceRadius: 0,
            sections: _showingSections(),
          ),
        ),
      ),
    );
  }

  List<PieChartSectionData> _showingSections() {
    return [
      buildPieSection(
          "Korisnici", Color(0xff39D5C3), izvjestajResult?[2].brojKorisnika),
      buildPieSection("Administratori", Color(0xFF7463DE),
          izvjestajResult?[2].brojAdministratora),
    ];
  }

  Widget _buildPrintButton() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        CustomButtonWidget(buttonText: "Printaj", onPress: () => _buildReport())
      ],
    );
  }

  DataRow _buildDataRow(PoslovniIzvjestaj e, BuildContext context, int index) {
    return DataRow(
      color: WidgetStatePropertyAll(
          index % 2 == 0 ? Color(0x808E9EE6) : Color(0x4F8E9EE6)),
      cells: [
        buildReportCell(e.godina?.toString()),
        buildReportCell(e.brojAdministratora?.toString()),
        buildReportCell(e.brojKorisnika.toString()),
        buildReportCell(e.brojKreiranihKupona.toString()),
        buildReportCell(e.brojIskoristenihKupona.toString()),
        buildReportCell(e.brojVoznji.toString()),
        buildReportCell(e.prihodiVozaca.toString() + " KM"),
      ],
    );
  }

  Widget _buildResultView() {
    if (isLoading == false &&
        izvjestajResult != null &&
        izvjestajResult?.isEmpty == true) {
      return Text("Nema rezultata.");
    }

    return SizedBox(
      width: double.infinity,
      child: Container(
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(20),
          border: Border.all(color: Color(0xFFD3D3D3)),
        ),
        child: ClipRRect(
          borderRadius: BorderRadius.circular(20), // Dodajte ovde borderRadius
          child: SingleChildScrollView(
            child: DataTable(
              showCheckboxColumn: false,
              columnSpacing: 25,
              border: TableBorder(
                borderRadius: BorderRadius.circular(20),
                horizontalInside: const BorderSide(
                  width: 1,
                  color: Color(0xFF8E9EE6),
                ),
              ),
              columns: columnData.map((col) {
                return DataColumn(
                  label: Text(
                    col["label"],
                    style: TextStyle(
                      color: Color(0xFF565252),
                      fontFamily: "Inter",
                      fontWeight: FontWeight.w700,
                      fontSize: 14,
                    ),
                  ),
                  numeric: true,
                );
              }).toList(),
              rows: izvjestajResult
                      ?.asMap()
                      .entries
                      .map((entry) =>
                          _buildDataRow(entry.value, context, entry.key))
                      .toList()
                      .cast<DataRow>() ??
                  [],
            ),
          ),
        ),
      ),
    );
  }

  Future<void> _buildReport() async {
    await _initReport();

    final PdfDocument document = PdfDocument();
    final PdfPage page = document.pages.add();
    final Size pageSize = page.getClientSize();

    page.graphics.drawRectangle(
        bounds: Rect.fromLTWH(0, 0, pageSize.width, pageSize.height),
        pen: PdfPen(PdfColor(68, 114, 196)));

    final PdfGrid grid = getGrid();

    final PdfLayoutResult result = drawHeader(page, pageSize, grid, fontData);

    drawGrid(page, grid, result);
    drawFooter(page, pageSize);

    final List<int> bytes = document.saveSync();

    document.dispose();

    await saveAndLaunchFile(bytes, 'ridewithme_poslovni_izvjestaj.pdf');
  }

  void drawGrid(PdfPage page, PdfGrid grid, PdfLayoutResult result) {
    Rect? totalPriceCellBounds;
    Rect? quantityCellBounds;

    grid.beginCellLayout = (Object sender, PdfGridBeginCellLayoutArgs args) {
      final PdfGrid grid = sender as PdfGrid;
      if (args.cellIndex == grid.columns.count - 1) {
        totalPriceCellBounds = args.bounds;
      } else if (args.cellIndex == grid.columns.count - 2) {
        quantityCellBounds = args.bounds;
      }
    };
    result = grid.draw(
        page: page, bounds: Rect.fromLTWH(0, result.bounds.bottom + 40, 0, 0))!;
  }

  void drawFooter(PdfPage page, Size pageSize) {
    final PdfPen linePen =
        PdfPen(PdfColor(68, 114, 196), dashStyle: PdfDashStyle.custom);
    linePen.dashPattern = <double>[3, 3];

    page.graphics.drawLine(linePen, Offset(0, pageSize.height - 100),
        Offset(pageSize.width, pageSize.height - 100));

    const String footerContent = '''Imate pitanje? support@ridewithme.com''';

    page.graphics.drawString(footerContent, PdfTrueTypeFont(fontData, 9),
        format: PdfStringFormat(alignment: PdfTextAlignment.right),
        bounds: Rect.fromLTWH(pageSize.width - 30, pageSize.height - 70, 0, 0));
  }

  PdfGrid getGrid() {
    final PdfGrid grid = PdfGrid();
    grid.columns.add(count: 7);
    final PdfGridRow headerRow = grid.headers.add(1)[0];

    headerRow.style.backgroundBrush = PdfSolidBrush(PdfColor(68, 114, 196));
    headerRow.style.textBrush = PdfBrushes.white;

    headerRow.cells[0].style.font = PdfTrueTypeFont(fontData, 7);
    headerRow.cells[1].style.font = PdfTrueTypeFont(fontData, 7);
    headerRow.cells[2].style.font = PdfTrueTypeFont(fontData, 7);
    headerRow.cells[3].style.font = PdfTrueTypeFont(fontData, 7);
    headerRow.cells[4].style.font = PdfTrueTypeFont(fontData, 7);
    headerRow.cells[5].style.font = PdfTrueTypeFont(fontData, 7);
    headerRow.cells[6].style.font = PdfTrueTypeFont(fontData, 7);

    headerRow.cells[0].value = 'Godina';
    headerRow.cells[0].stringFormat.alignment = PdfTextAlignment.center;
    headerRow.cells[1].value = 'Broj administratora';
    headerRow.cells[2].value = 'Broj korisnika';
    headerRow.cells[3].value = 'Broj kreiranih kupona';
    headerRow.cells[4].value = 'Broj iskorištenih kupona';
    headerRow.cells[5].value = 'Broj vožnji';
    headerRow.cells[6].value = 'Prihod vozača';

    if (izvjestajResult != null) {
      for (var item in izvjestajResult!) {
        final PdfGridRow row = grid.rows.add();
        row.cells[0].value = item.godina.toString();
        row.cells[1].value = item.brojAdministratora.toString();
        row.cells[2].value = item.brojKorisnika.toString();
        row.cells[3].value = item.brojKreiranihKupona.toString();
        row.cells[4].value = item.brojIskoristenihKupona.toString();
        row.cells[5].value = item.brojVoznji.toString();
        row.cells[6].value = item.prihodiVozaca.toString() + " KM";
      }
    }

    grid.applyBuiltInStyle(PdfGridBuiltInStyle.listTable4Accent5);

    for (int i = 0; i < headerRow.cells.count; i++) {
      headerRow.cells[i].style.cellPadding =
          PdfPaddings(bottom: 5, left: 5, right: 5, top: 5);
    }
    for (int i = 0; i < grid.rows.count; i++) {
      final PdfGridRow row = grid.rows[i];
      for (int j = 0; j < row.cells.count; j++) {
        final PdfGridCell cell = row.cells[j];
        if (j == 0) {
          cell.stringFormat.alignment = PdfTextAlignment.center;
        }
        cell.style.cellPadding =
            PdfPaddings(bottom: 5, left: 5, right: 5, top: 5);
      }
    }
    return grid;
  }
}
