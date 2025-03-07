import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/korisnik_provider.dart';
import 'package:ridewithme_admin/screens/korisnici_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class KorisniciScreen extends StatefulWidget {
  const KorisniciScreen({super.key});

  @override
  State<KorisniciScreen> createState() => _KorisniciScreenState();
}

class _KorisniciScreenState extends State<KorisniciScreen> {
  late KorisnikProvider _korisnikProvider;

  bool isLoading = true;

  final _formKey = GlobalKey<FormBuilderState>();

  SearchResult<Korisnik>? korisnikResults;

  final _horizontalScrollController = ScrollController();

  Map<String, dynamic> _initialValue = {};

  final List<Map<String, dynamic>> columnData = [
    {"label": "Ime"},
    {"label": "Prezime"},
    {"label": "Korisničko ime"},
    {"label": "E-mail"},
    {"label": "Datum kreiranja"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _korisnikProvider = context.read<KorisnikProvider>();

    _initialValue = {
      'OrderBy': 'DatumKreiranja DESC',
      'KorisnickoIme': null,
      'IsKorisniciIncluded': true,
      'IsDostignucaIncluded': true
    };

    initTable();
  }

  Future initTable() async {
    String orderByField =
        _formKey.currentState?.value['OrderByField'] ?? "DatumKreiranja";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "DESC";

    korisnikResults = await _korisnikProvider.get(filter: {
      'OrderBy': "$orderByField $orderByDirection",
      'KorisnickoIme': _formKey.currentState?.value['KorisnickoIme'],
      'IsKorisniciIncluded': true,
      'IsDostignucaIncluded': true,
      "Page": _pageNumber,
      "PageSize": _pageSize
    });

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        selectedIndex: 2,
        headerTitle: "Korisnici",
        headerDescription: "Ovdje možete da pregledate listu korisnika.",
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
                child: FormBuilderTextField(
              name: "KorisnickoIme",
              initialValue: _initialValue['KorisnickoImeGTE'],
              decoration: buildTextFieldDecoration(
                  hintText: "Korisničko ime...",
                  labelText: "Korisničko ime",
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
                      value: "DatumKreiranja", child: Text("Datum kreiranja"))
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
              buttonText: "Dodaj korisnika",
              onPress: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => KorisniciDetailsScreen(),
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
    if (id == Authorization.id) {
      return ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          behavior: SnackBarBehavior.floating,
          content: Text("Ne možete obrisati samog sebe."),
          action: SnackBarAction(
            label: "U redu",
            onPressed: () =>
                ScaffoldMessenger.of(context)..removeCurrentSnackBar(),
          ),
        ),
      );
    }

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
          await _korisnikProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali korisnika."),
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
      content: Text(
          "Jeste li sigurni da želite obrisati ovog korisnika?\nAko nastavite, svaka veza koju korisnik ima sa ostalim stavkama će također biti obrisana/modifikovana."),
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

  DataRow _buildDataRow(Korisnik e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.ime),
        buildDataCell(e.prezime),
        buildDataCell(e.korisnickoIme),
        buildDataCell(e.email),
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
                        builder: (context) => KorisniciDetailsScreen(
                          korisnik: e,
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
        korisnikResults != null &&
        korisnikResults?.count == 0) {
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
                          minWidth: 800,
                          maxWidth: 800,
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
                        rows: korisnikResults?.result
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
            if (korisnikResults != null) ...[
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
