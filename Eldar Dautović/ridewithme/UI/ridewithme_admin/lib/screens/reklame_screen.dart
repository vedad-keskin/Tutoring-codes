import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/reklama.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/reklame_provider.dart';
import 'package:ridewithme_admin/screens/reklame_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class ReklameScreen extends StatefulWidget {
  const ReklameScreen({super.key});

  @override
  State<ReklameScreen> createState() => _ReklameScreenState();
}

class _ReklameScreenState extends State<ReklameScreen> {
  late ReklameProvider _reklameProvider;

  final _horizontalScrollController = ScrollController();

  SearchResult<Reklama>? reklameResult;

  final _formKey = GlobalKey<FormBuilderState>();

  bool isLoading = true;
  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  final List<Map<String, dynamic>> columnData = [
    {"label": "Klijent"},
    {"label": "Naziv kampanje"},
    {"label": "Kreirao"},
    {"label": "Datum kreiranja"},
    {"label": "Datum izmjene"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  @override
  void initState() {
    super.initState();

    _reklameProvider = context.read<ReklameProvider>();

    initTable();
  }

  Future initTable() async {
    reklameResult = await _reklameProvider.get(filter: {
      "NazivKlijentaGTE": _formKey.currentState?.value['NazivKlijentaGTE'],
      "NazivKampanjeGTE": _formKey.currentState?.value['NazivKampanjeGTE'],
      "IsKorisniciIncluded": true,
      "Page": _pageNumber,
      "PageSize": _pageSize
    });
    _totalPages = ((reklameResult?.count ?? 1) / _pageSize).ceil();

    setState(() {
      isLoading = false;
    });
  }

  showAlertDialog(BuildContext context, int id) {
    Widget cancelButton = TextButton(
      child: Text("Odustani"),
      onPressed: () {
        Navigator.pop(context, true);
      },
    );
    Widget continueButton = TextButton(
      child: Text("Da"),
      onPressed: () async {
        try {
          await _reklameProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali reklamu."),
              action: SnackBarAction(
                label: "U redu",
                onPressed: () =>
                    ScaffoldMessenger.of(context)..removeCurrentSnackBar(),
              ),
            ),
          );

          initTable();

          setState(() {
            isLoading = true;
          });
        } on Exception catch (e) {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text(e.toString()),
              action: SnackBarAction(
                label: "U redu",
                onPressed: () =>
                    ScaffoldMessenger.of(context)..removeCurrentSnackBar(),
              ),
            ),
          );
        }
      },
    );

    AlertDialog alert = AlertDialog(
      title: Text("Upozorenje"),
      content: Text("Da li ste sigurni da želite da obrišete reklamu?"),
      actions: [
        cancelButton,
        continueButton,
      ],
    );

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        selectedIndex: 7,
        headerTitle: "Reklame",
        headerDescription: "Ovdje možete pregledati listu reklama.",
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            _buildSearch(),
            isLoading ? LoadingSpinnerWidget() : _buildResultView()
          ],
        ));
  }

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      onChanged: () {
        _formKey.currentState?.save();
        initTable();
      },
      child: Padding(
        padding: const EdgeInsets.only(bottom: 20),
        child: SizedBox(
          width: MediaQuery.of(context).size.width / 3,
          child: Row(
            spacing: 10,
            children: [
              Expanded(
                  child: FormBuilderTextField(
                name: "NazivKlijentaGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Klijent...",
                    labelText: "Klijent",
                    prefixIcon: Icon(Icons.abc_rounded)),
              )),
              Expanded(
                  child: FormBuilderTextField(
                name: "NazivKampanjeGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Kampanja...",
                    labelText: "Kampanja",
                    prefixIcon: Icon(Icons.abc_rounded)),
              )),
              CustomButtonWidget(
                buttonText: "Dodaj reklamu",
                onPress: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => ReklameDetailsScreen(),
                    ),
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }

  DataRow _buildDataRow(Reklama e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.nazivKlijenta),
        buildDataCell(e.nazivKampanje),
        buildDataCell("${e.korisnik?.ime} ${e.korisnik?.prezime}"),
        buildDataCell(e.datumKreiranja != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumKreiranja!)
            : "N/A"),
        buildDataCell(e.datumIzmjene != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumIzmjene!)
            : "N/A"),
        DataCell(Row(
          children: [
            IconButton(
              onPressed: () {
                showAlertDialog(context, e.id ?? 0);
              },
              icon: const Icon(Icons.delete),
              iconSize: 17,
            ),
            IconButton(
              onPressed: () {
                Navigator.of(context)
                    .push(
                      MaterialPageRoute(
                        builder: (context) => ReklameDetailsScreen(reklama: e),
                      ),
                    )
                    .then((value) => setState(() {}));
              },
              icon: const Icon(Icons.edit),
              iconSize: 17,
            ),
          ],
        )),
      ],
    );
  }

  Widget _buildResultView() {
    if (isLoading == false &&
        reklameResult != null &&
        reklameResult?.count == 0) {
      return Text("Nema rezultata.");
    }

    return Expanded(
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Container(
              decoration: BoxDecoration(
                color: Color(0x29C3CBCA),
                borderRadius: BorderRadius.circular(20),
                border: Border.all(color: Color(0xFFD3D3D3)),
              ),
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Scrollbar(
                  controller: _horizontalScrollController,
                  thumbVisibility: true,
                  trackVisibility: true,
                  child: SingleChildScrollView(
                    controller: _horizontalScrollController,
                    scrollDirection: Axis.horizontal,
                    child: ConstrainedBox(
                      constraints: BoxConstraints(
                          minWidth: 1500,
                          minHeight: MediaQuery.of(context).size.height - 500),
                      child: DataTable(
                        showCheckboxColumn: false,
                        columnSpacing: 25,
                        columns: columnData.map((col) {
                          return DataColumn(
                            label: Text(col["label"], style: columnTextStyle),
                            numeric: col["numeric"] ?? false,
                          );
                        }).toList(),
                        rows: reklameResult?.result
                                .map((e) => _buildDataRow(e, context))
                                .toList()
                                .cast<DataRow>() ??
                            [],
                      ),
                    ),
                  ),
                ),
              ),
            ),
            SizedBox(
              height: 10,
            ),
            if (reklameResult != null) ...[
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  IconButton(
                    onPressed: _pageNumber > 1
                        ? () {
                            setState(() {
                              _pageNumber = _pageNumber - 1;
                              initTable();
                            });
                          }
                        : null,
                    icon: const Icon(Icons.arrow_back_ios_new_rounded),
                  ),
                  Text('$_pageNumber',
                      style: Theme.of(context).textTheme.bodyLarge),
                  IconButton(
                    onPressed: _pageNumber < _totalPages
                        ? () {
                            setState(() {
                              _pageNumber = _pageNumber + 1;
                            });
                            initTable();
                          }
                        : null,
                    icon: const Icon(Icons.arrow_forward_ios_rounded),
                  ),
                ],
              ),
            ],
          ],
        ),
      ),
    );
  }
}
