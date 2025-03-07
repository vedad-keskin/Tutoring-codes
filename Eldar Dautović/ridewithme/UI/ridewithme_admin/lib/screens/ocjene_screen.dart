import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/recenzija.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/recenzije_provider.dart';
import 'package:ridewithme_admin/screens/ocjene_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class OcjeneScreen extends StatefulWidget {
  const OcjeneScreen({super.key});

  @override
  State<OcjeneScreen> createState() => _OcjeneScreenState();
}

class _OcjeneScreenState extends State<OcjeneScreen> {
  late RecenzijeProvider _recenzijeProvider;

  final _formKey = GlobalKey<FormBuilderState>();

  SearchResult<Recenzija>? recenzijaResult;

  bool isLoading = true;

  Map<String, dynamic> _initialValue = {};

  final _horizontalScrollController = ScrollController();

  final List<Map<String, dynamic>> columnData = [
    {"label": "Broj vožnje", "numeric": true},
    {"label": "Klijent ime"},
    {"label": "Vozač ime"},
    {"label": "Ocjena", "numeric": true},
    {"label": "Datum ostavljanja ocjene"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _recenzijeProvider = context.read<RecenzijeProvider>();

    _initialValue = {
      'OrderBy': 'VoznjaId ASC',
      'KorisnikGTE': null,
      'VoznjaId': null
    };

    initTable();
  }

  Future initTable() async {
    String orderByField = _formKey.currentState?.value['OrderByField'] ?? "id";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "ASC";

    recenzijaResult = await _recenzijeProvider.get(filter: {
      'OrderBy': "$orderByField $orderByDirection",
      'KorisnikGTE': _formKey.currentState?.value['KorisnikGTE'],
      'VoznjaId': _formKey.currentState?.value['VoznjaId'],
      "Page": _pageNumber,
      "PageSize": _pageSize
    });

    _totalPages = ((recenzijaResult?.count ?? 1) / _pageSize).ceil();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 12,
      headerTitle: "Ocjene",
      headerDescription:
          "Ovdje možete pregledati ocjene koje su korisnici ostavili vozačima",
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _buildSearch(),
          isLoading ? LoadingSpinnerWidget() : _buildResultView()
        ],
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
      child: Padding(
        padding: const EdgeInsets.only(bottom: 20),
        child: SizedBox(
          width: MediaQuery.of(context).size.width / 3,
          child: Row(
            spacing: 10,
            children: [
              Expanded(
                  child: FormBuilderTextField(
                name: "KorisnikGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Korisničko ime...",
                    labelText: "Korisničko ime",
                    prefixIcon: Icon(Icons.abc_rounded)),
              )),
              Expanded(
                  child: FormBuilderTextField(
                name: "VoznjaId",
                keyboardType: TextInputType.number,
                valueTransformer: (value) {
                  if (value != null) {
                    return int.tryParse(value);
                  }
                },
                validator: FormBuilderValidators.compose([
                  FormBuilderValidators.float(
                    errorText: 'Ovo polje mora biti broj.',
                  ),
                ]),
                initialValue: _initialValue['VoznjaId'],
                decoration: buildTextFieldDecoration(
                    hintText: "Broj vožnje...",
                    labelText: "Broj vožnje",
                    prefixIcon: Icon(Icons.numbers_rounded)),
              )),
              Expanded(
                child: buildDropdown(
                  name: "OrderByField",
                  labelText: "Sortiraj po",
                  initialValue: "VoznjaId",
                  prefixIcon: Icon(Icons.sort_by_alpha_rounded),
                  items: const [
                    DropdownMenuItem(
                        value: "VoznjaId", child: Text("Broj vožnje")),
                    DropdownMenuItem(value: "Ocjena", child: Text("Ocjena")),
                    DropdownMenuItem(
                        value: "DatumKreiranja",
                        child: Text("Datum ostavljanja ocjene")),
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
          await _recenzijeProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali grad."),
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
      content: Text("Jeste li sigurni da želite ovu recenziju?"),
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

  DataRow _buildDataRow(Recenzija e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell("#${e.voznja?.id?.toString()}"),
        buildDataCell(e.korisnik?.korisnickoIme),
        buildDataCell(e.voznja?.vozac?.korisnickoIme),
        buildDataCell(e.ocjena.toString()),
        buildDataCell(e.datumKreiranja != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumKreiranja!)
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
                        builder: (context) => OcjeneDetailsScreen(
                          recenzija: e,
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
    if (isLoading == false &&
        recenzijaResult != null &&
        recenzijaResult?.count == 0) {
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
                          maxWidth: 700,
                          minWidth: 700,
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
                        rows: recenzijaResult?.result
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
            if (recenzijaResult != null) ...[
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
