import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/faq.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/faq_provider.dart';
import 'package:ridewithme_admin/screens/faq_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class FaqScreen extends StatefulWidget {
  const FaqScreen({super.key});

  @override
  State<FaqScreen> createState() => _FaqScreenState();
}

class _FaqScreenState extends State<FaqScreen> {
  late FaqProvider _faqProvider;

  bool isLoading = true;

  SearchResult<FAQ>? faqResults;

  final _formKey = GlobalKey<FormBuilderState>();

  final _horizontalScrollController = ScrollController();

  Map<String, dynamic> _initialValue = {};

  final List<Map<String, dynamic>> columnData = [
    {"label": "Pitanje"},
    {"label": "Kreirao"},
    {"label": "Datum kreiranja"},
    {"label": "Datum izmjene"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];
  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  @override
  void initState() {
    super.initState();
    _faqProvider = context.read<FaqProvider>();

    _initialValue = {
      'OrderBy': 'VoznjaId ASC',
      'KorisnikGTE': null,
      'VoznjaId': null
    };

    initTable();
  }

  Future initTable() async {
    String orderByField =
        _formKey.currentState?.value['OrderByField'] ?? "DatumKreiranja";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "ASC";

    faqResults = await _faqProvider.get(filter: {
      "PitanjeGTE": _formKey.currentState?.value['PitanjeGTE'],
      "OrderBy": "$orderByField $orderByDirection",
      "IsKorisnikIncluded": true,
      "Page": _pageNumber,
      "PageSize": _pageSize
    });

    _totalPages = ((faqResults?.count ?? 1) / _pageSize).ceil();

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
          await _faqProvider.delete(id);

          Navigator.pop(context, true);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali FAQ ID $id."),
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
      content: Text("Da li ste sigurni da želite da obrišete FAQ ID $id ?"),
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
      selectedIndex: 11,
      headerTitle: "FAQ",
      headerDescription: "Ovdje možete da pregledate FAQ.",
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
          child: Row(
            spacing: 10,
            children: [
              Expanded(
                  child: FormBuilderTextField(
                name: "PitanjeGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Pitanje...",
                    labelText: "Pitanje",
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
                buttonText: "Dodaj FAQ",
                onPress: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => FaqDetailsScreen(),
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

  DataRow _buildDataRow(FAQ e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.pitanje),
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
                        builder: (context) => FaqDetailsScreen(
                          faq: e,
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
    if (isLoading == false && faqResults != null && faqResults?.count == 0) {
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
                          maxWidth: 1500,
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
                        rows: faqResults?.result
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
            if (faqResults != null) ...[
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
