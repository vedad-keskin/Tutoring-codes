import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/models/zalba.dart';
import 'package:ridewithme_admin/providers/zalbe_provider.dart';
import 'package:ridewithme_admin/screens/zalbe_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class ZalbeScreen extends StatefulWidget {
  const ZalbeScreen({super.key});

  @override
  State<ZalbeScreen> createState() => _ZalbeScreenState();
}

class _ZalbeScreenState extends State<ZalbeScreen> {
  late ZalbaProvider _zalbaProvider;

  SearchResult<Zalba>? zalbeResult;

  final _horizontalScrollController = ScrollController();

  final _formKey = GlobalKey<FormBuilderState>();

  Map<String, dynamic> _initialValue = {};

  bool isLoading = false;

  final List<Map<String, dynamic>> columnData = [
    {"label": "Broj žalbe", "numeric": true},
    {"label": "Naslov"},
    {"label": "Datum kreiranja"},
    {"label": "Datum preuzimanja"},
    {"label": "Vrsta žalbe"},
    {"label": "Podnio"},
    {"label": "Preuzeo"},
    {"label": "Status"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  @override
  void initState() {
    super.initState();

    _zalbaProvider = context.read<ZalbaProvider>();

    _initialValue = {
      'OrderBy': 'id ASC',
      'NaslovGTE': null,
      'DatumPreuzimanja': null,
      'VrstaZalbeGTE': null,
      'KorisnickoImeAdministratorGTE': null,
      'KorisnickoImeKorisnikGTE': null,
      'Status': null,
    };

    initTable();
  }

  Future initTable() async {
    String orderByField = _formKey.currentState?.value['OrderByField'] ?? "id";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "ASC";

    zalbeResult = await _zalbaProvider.get(filter: {
      'OrderBy': "$orderByField $orderByDirection",
      'Status': _formKey.currentState?.value['Status'],
      'DatumPreuzimanja': _formKey.currentState?.value['DatumPreuzimanja'],
      'NaslovGTE': _formKey.currentState?.value['NaslovGTE'],
      'VrstaZalbeGTE': _formKey.currentState?.value['VrstaZalbeGTE'],
      'KorisnickoImeAdministratorGTE':
          _formKey.currentState?.value['KorisnickoImeAdministratorGTE'],
      'KorisnickoImeKorisnikGTE':
          _formKey.currentState?.value['KorisnickoImeKorisnikGTE'],
      'IsKorisnikIncluded': true,
      'IsAdministratorIncluded': true,
      'IsVrstaZalbeIncluded': true,
      "Page": _pageNumber,
      "PageSize": _pageSize
    });
    _totalPages = ((zalbeResult?.count ?? 1) / _pageSize).ceil();

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
          await _zalbaProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali žalbu."),
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
      content: Text("Da li ste sigurni da želite da obrišete žalbu?"),
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
        selectedIndex: 6,
        headerTitle: "Žalbe",
        headerDescription:
            "Ovdje možete da pregledate i odgovorite na eventualne žalbe.",
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
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.only(bottom: 20),
        child: Row(
          spacing: 10,
          children: [
            Expanded(
                child: FormBuilderDateTimePicker(
                    name: "DatumPreuzimanja",
                    decoration: buildTextFieldDecoration(
                        labelText: "Datum preuzimanja",
                        hintText: "Datum preuzimanja",
                        prefixIcon: Icon(Icons.date_range_rounded),
                        onClear: () => _formKey
                            .currentState!.fields['DatumPreuzimanja']
                            ?.reset()))),
            Expanded(
                child: FormBuilderTextField(
              name: "KorisnickoImeAdministratorGTE",
              initialValue: _initialValue['KorisnickoImeAdministratorGTE'],
              decoration: buildTextFieldDecoration(
                  hintText: "Administrator...",
                  labelText: "Administrator",
                  prefixIcon: Icon(Icons.abc_rounded)),
            )),
            Expanded(
                child: FormBuilderTextField(
              name: "KorisnickoImeKorisnikGTE",
              initialValue: _initialValue['KorisnickoImeKorisnikGTE'],
              decoration: buildTextFieldDecoration(
                  hintText: "Korisnik...",
                  labelText: "Korisnik",
                  prefixIcon: Icon(Icons.abc_rounded)),
            )),
            Expanded(
              child: buildDropdown(
                name: "Status",
                labelText: "Status",
                prefixIcon: Icon(Icons.flag),
                items: [
                  DropdownMenuItem(
                    value: null,
                    child: Text("Odaberi"),
                  ),
                  ...ZalbeStatus.values
                      .map((status) => DropdownMenuItem(
                            value: status.name,
                            child: Text(status.naziv),
                          ))
                      .toList()
                ],
                onClear: () {
                  _formKey.currentState!.fields['Status']?.reset();
                },
              ),
            ),
            Expanded(
              child: buildDropdown(
                name: "OrderByField",
                labelText: "Sortiraj po",
                initialValue: "id",
                prefixIcon: Icon(Icons.sort_by_alpha_rounded),
                items: const [
                  DropdownMenuItem(value: "id", child: Text("Broj žalbe")),
                  DropdownMenuItem(
                      value: "DatumPreuzimanja",
                      child: Text("Datum preuzimanja")),
                  DropdownMenuItem(
                      value: "DatumKreiranja", child: Text("Datum kreiranja")),
                  DropdownMenuItem(
                      value: "DatumIzmjene", child: Text("Datum izmjene")),
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
          ],
        ),
      ),
    );
  }

  DataRow _buildDataRow(Zalba e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell("#${e.id?.toString()}"),
        buildDataCell(e.naslov),
        buildDataCell(e.datumKreiranja != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumKreiranja!)
            : "N/A"),
        buildDataCell(e.datumPreuzimanja != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumPreuzimanja!)
            : "N/A"),
        buildDataCell(e.vrstaZalbe?.naziv),
        buildDataCell("${e.korisnik?.ime ?? ""} ${e.korisnik?.prezime ?? ""}"),
        if (e.administrator != null)
          buildDataCell(
              "${e.administrator?.ime ?? ""} ${e.administrator?.prezime ?? ""}"),
        if (e.administrator == null) buildDataCell("N/A"),
        DataCell(
          Badge(
            padding:
                const EdgeInsets.only(left: 5, right: 5, top: 4, bottom: 4),
            label: Text(ZalbeStatus.fromString(e.stateMachine)?.naziv ?? ""),
            backgroundColor:
                ZalbeStatus.fromString(e.stateMachine)?.boja ?? Colors.red,
          ),
        ),
        DataCell(Row(
          children: [
            if (e.stateMachine == 'completed')
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
                          builder: (context) => ZalbeDetailsScreen(
                            zalba: e,
                          ),
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
    if (isLoading == false && zalbeResult != null && zalbeResult?.count == 0) {
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
                        rows: zalbeResult?.result
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
            if (zalbeResult != null) ...[
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
