import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/models/obavjestenje.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/gradovi_provider.dart';
import 'package:ridewithme_admin/providers/obavjestenja_provider.dart';
import 'package:ridewithme_admin/screens/obavjestenja_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class ObavjestenjaScreen extends StatefulWidget {
  const ObavjestenjaScreen({super.key});

  @override
  State<ObavjestenjaScreen> createState() => _ObavjestenjaScreenState();
}

class _ObavjestenjaScreenState extends State<ObavjestenjaScreen> {
  late GradoviProvider _gradoviProvider;
  late ObavjestenjaProvider _obavjestenjeProvider;

  SearchResult<Gradovi>? gradoviResult;
  SearchResult<Obavjestenje>? obavjestenjeResult;

  final _horizontalScrollController = ScrollController();

  final List<Map<String, dynamic>> columnData = [
    {"label": "Naslov"},
    {"label": "Podnaslov"},
    {"label": "Početak"},
    {"label": "Završetak"},
    {"label": "Status"},
    {"label": "Kreirao"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    super.initState();
    _gradoviProvider = context.read<GradoviProvider>();
    _obavjestenjeProvider = context.read<ObavjestenjaProvider>();

    _initialValue = {
      'OrderBy': 'DatumKreiranja DESC',
      'Status': null,
      'datumOd': null,
      'datumDo': null
    };

    initDropdowns();
    initTable();
  }

  Future initDropdowns() async {
    gradoviResult = await _gradoviProvider.get();
  }

  Future initTable() async {
    String orderByField =
        _formKey.currentState?.value['OrderByField'] ?? "DatumKreiranja";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "ASC";

    obavjestenjeResult = await _obavjestenjeProvider.get(filter: {
      'OrderBy': "$orderByField $orderByDirection",
      'Status': _formKey.currentState?.value['status'],
      'DatumOdGTE': _formKey.currentState?.value['datumOd'],
      'DatumDoGTE': _formKey.currentState?.value['datumDo'],
      "Page": _pageNumber,
      "PageSize": _pageSize
    });
    _totalPages = ((obavjestenjeResult?.count ?? 1) / _pageSize).ceil();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 8,
      headerTitle: "Obavještenja",
      headerDescription: "Ovdje možete vidjeti listu obavještenja",
      child: Container(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            _buildSearch(),
            isLoading ? LoadingSpinnerWidget() : _buildResultView()
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      onChanged: () {
        _formKey.currentState?.save();
        initTable();
      },
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.only(bottom: 20),
        child: Row(
          spacing: 10,
          children: [
            Expanded(
                child: FormBuilderDateTimePicker(
                    name: "datumOd",
                    decoration: buildTextFieldDecoration(
                        labelText: "Datum od",
                        hintText: "Datum od",
                        prefixIcon: Icon(Icons.date_range_rounded),
                        onClear: () => _formKey.currentState!.fields['datumOd']
                            ?.reset()))),
            Expanded(
                child: FormBuilderDateTimePicker(
                    name: "datumDo",
                    decoration: buildTextFieldDecoration(
                        labelText: "Datum do",
                        hintText: "Datum do",
                        prefixIcon: Icon(Icons.date_range_rounded),
                        onClear: () => _formKey.currentState!.fields['datumDo']
                            ?.reset()))),
            Expanded(
              child: buildDropdown(
                name: "status",
                labelText: "Status",
                prefixIcon: Icon(Icons.flag),
                items: [
                  DropdownMenuItem(
                    value: null,
                    child: Text("Odaberi"),
                  ),
                  ...ObavjestenjeStatus.values
                      .map((status) => DropdownMenuItem(
                            value: status.name,
                            child: Text(status.naziv),
                          ))
                      .toList()
                ],
                onClear: () {
                  _formKey.currentState!.fields['status']?.reset();
                },
              ),
            ),
            Expanded(
              child: buildDropdown(
                name: "OrderByField",
                labelText: "Sortiraj po",
                initialValue: "DatumKreiranja",
                prefixIcon: Icon(Icons.sort_by_alpha_rounded),
                items: const [
                  DropdownMenuItem(
                      value: "DatumKreiranja", child: Text("Datum kreiranja")),
                  DropdownMenuItem(
                      value: "DatumZavrsetka", child: Text("Datum završetka")),
                  DropdownMenuItem(
                      value: "DatumIzmjene", child: Text("Datum izmjene")),
                  DropdownMenuItem(value: "Naslov", child: Text("Naslov")),
                  DropdownMenuItem(
                      value: "Podnaslov", child: Text("Podnaslov")),
                ],
              ),
            ),
            Expanded(
              child: buildDropdown(
                name: "OrderByDirection",
                labelText: "Smjer",
                initialValue: "ASC",
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
              buttonText: "Dodaj obavještenje",
              onPress: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => ObavjestenjaDetailsScreen(),
                  ),
                );
              },
            ),
          ],
        ),
      ),
    );
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
          await _obavjestenjeProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali obavještenje ID $id."),
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
      content:
          Text("Da li ste sigurni da želite da obrišete obavještenje ID $id ?"),
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

  DataRow _buildDataRow(Obavjestenje e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.naslov),
        buildDataCell(e.podnaslov),
        buildDataCell(e.datumKreiranja != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumKreiranja!)
            : "N/A"),
        buildDataCell(e.datumZavrsetka != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumZavrsetka!)
            : "N/A"),
        DataCell(
          Badge(
            padding:
                const EdgeInsets.only(left: 5, right: 5, top: 4, bottom: 4),
            label: Text(VoznjaStatus.fromString(e.stateMachine)?.naziv ?? ""),
            backgroundColor:
                VoznjaStatus.fromString(e.stateMachine)?.boja ?? Colors.red,
          ),
        ),
        buildDataCell("${e.korisnik?.ime ?? ""} ${e.korisnik?.prezime ?? ""}"),
        DataCell(Row(
          children: [
            if (e.stateMachine == 'completed' || e.stateMachine == 'draft')
              IconButton(
                iconSize: 17,
                onPressed: () {
                  showAlertDialog(context, e.id ?? 0);
                },
                icon: const Icon(Icons.delete),
              ),
            if (e.stateMachine != 'completed')
              IconButton(
                onPressed: () {
                  Navigator.of(context)
                      .push(
                        MaterialPageRoute(
                          builder: (context) =>
                              ObavjestenjaDetailsScreen(obavjestenje: e),
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
        obavjestenjeResult != null &&
        obavjestenjeResult?.count == 0) {
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
                        rows: obavjestenjeResult?.result
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
            if (obavjestenjeResult != null) ...[
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
