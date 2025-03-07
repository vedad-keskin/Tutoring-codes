import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/dogadjaj.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/dogadjaji_provider.dart';
import 'package:ridewithme_admin/screens/dogadjaji_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class DogadjajiScreen extends StatefulWidget {
  const DogadjajiScreen({super.key});

  @override
  State<DogadjajiScreen> createState() => _DogadjajiScreenState();
}

class _DogadjajiScreenState extends State<DogadjajiScreen> {
  late DogadjajiProvider _dogadjajiProvider;

  SearchResult<Dogadjaj>? dogadjajiResult;

  final _formKey = GlobalKey<FormBuilderState>();

  final _horizontalScrollController = ScrollController();

  bool isLoading = true;

  final List<Map<String, dynamic>> columnData = [
    {"label": "Naziv"},
    {"label": "Datum kreiranja"},
    {"label": "Datum izmjene"},
    {"label": "Početak"},
    {"label": "Završetak"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  @override
  void initState() {
    super.initState();

    _dogadjajiProvider = context.read<DogadjajiProvider>();

    initTable();
  }

  Future initTable() async {
    String orderByField =
        _formKey.currentState?.value['OrderByField'] ?? "DatumKreiranja";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "DESC";

    dogadjajiResult = await _dogadjajiProvider.get(filter: {
      "NazivGTE": _formKey.currentState?.value['NazivGTE'],
      "OpisGTE": _formKey.currentState?.value['OpisGTE'],
      'OrderBy': "$orderByField $orderByDirection",
      "Page": _pageNumber,
      "PageSize": _pageSize
    });

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
          await _dogadjajiProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali događaj ID $id."),
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
      content: Text("Da li ste sigurni da želite da obrišete događaj ID $id ?"),
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
        selectedIndex: 4,
        headerTitle: "Događaji",
        headerDescription: "Ovdje možete pregledati listu događaja.",
        child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
          _buildSearch(),
          isLoading ? LoadingSpinnerWidget() : _buildResultView(),
        ]));
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
          child: Row(
            spacing: 10,
            children: [
              Expanded(
                  child: FormBuilderTextField(
                name: "NazivGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Naziv...",
                    labelText: "Naziv",
                    prefixIcon: Icon(Icons.abc_rounded)),
              )),
              Expanded(
                  child: FormBuilderTextField(
                name: "OpisGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Opis...",
                    labelText: "Opis",
                    prefixIcon: Icon(Icons.abc_rounded)),
              )),
              Expanded(
                child: buildDropdown(
                  name: "OrderByField",
                  labelText: "Sortiraj po",
                  initialValue: "DatumKreiranja",
                  prefixIcon: Icon(Icons.sort_by_alpha_rounded),
                  items: const [
                    DropdownMenuItem(
                        value: "DatumKreiranja",
                        child: Text("Datum kreiranja")),
                    DropdownMenuItem(
                        value: "DatumIzmjene", child: Text("Datum izmjene")),
                    DropdownMenuItem(
                        value: "DatumZavrsetka",
                        child: Text("Datum završetka")),
                    DropdownMenuItem(
                        value: "DatumPocetka", child: Text("Datum početka")),
                  ],
                ),
              ),
              Expanded(
                child: buildDropdown(
                  name: "OrderByDirection",
                  labelText: "Smjer",
                  initialValue: "DESC",
                  prefixIcon:
                      _formKey.currentState?.value['OrderByDirection'] == "ASC"
                          ? Icon(Icons.arrow_upward_rounded)
                          : Icon(Icons.arrow_downward_rounded),
                  items: const [
                    DropdownMenuItem(value: "ASC", child: Text("Rastuće")),
                    DropdownMenuItem(value: "DESC", child: Text("Opadajuće")),
                  ],
                ),
              ),
              CustomButtonWidget(
                buttonText: "Dodaj događaj",
                onPress: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => DogadjajiDetailsScreen(),
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

  DataRow _buildDataRow(Dogadjaj e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.naziv),
        buildDataCell(e.datumKreiranja != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumKreiranja!)
            : "N/A"),
        buildDataCell(e.datumIzmjene != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumZavrsetka!)
            : "N/A"),
        buildDataCell(e.datumPocetka != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumZavrsetka!)
            : "N/A"),
        buildDataCell(e.datumZavrsetka != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumZavrsetka!)
            : "N/A"),
        DataCell(Row(
          children: [
            IconButton(
              iconSize: 17,
              onPressed: () {
                showAlertDialog(context, e.id ?? 0);
              },
              icon: const Icon(Icons.delete),
            ),
            IconButton(
              onPressed: () {
                Navigator.of(context)
                    .push(
                      MaterialPageRoute(
                        builder: (context) =>
                            DogadjajiDetailsScreen(dogadjaj: e),
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
        dogadjajiResult != null &&
        dogadjajiResult?.count == 0) {
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
                        rows: dogadjajiResult?.result
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
            if (dogadjajiResult != null) ...[
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
