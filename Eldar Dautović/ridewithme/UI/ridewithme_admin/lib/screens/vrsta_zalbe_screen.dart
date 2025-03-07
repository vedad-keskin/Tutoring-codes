import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/models/vrsta_zalbe.dart';
import 'package:ridewithme_admin/providers/vrsta_zalbe_provider.dart';
import 'package:ridewithme_admin/screens/vrsta_zalbe_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class VrstaZalbeScreen extends StatefulWidget {
  const VrstaZalbeScreen({super.key});

  @override
  State<VrstaZalbeScreen> createState() => _VrstaZalbeScreenState();
}

class _VrstaZalbeScreenState extends State<VrstaZalbeScreen> {
  late VrstaZalbeProvider _vrstaZalbeProvider;

  SearchResult<VrstaZalbe>? vrsteZalbeResult;

  final _horizontalScrollController = ScrollController();

  final _formKey = GlobalKey<FormBuilderState>();

  bool isLoading = true;

  final List<Map<String, dynamic>> columnData = [
    {"label": "Naziv"},
    {"label": "Datum izmjene"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  @override
  void initState() {
    super.initState();

    _vrstaZalbeProvider = context.read<VrstaZalbeProvider>();

    initTable();
  }

  Future initTable() async {
    vrsteZalbeResult = await _vrstaZalbeProvider.get(filter: {
      "NazivGTE": _formKey.currentState?.value['NazivGTE'],
      "Page": _pageNumber,
      "PageSize": _pageSize
    });

    _totalPages = ((vrsteZalbeResult?.count ?? 1) / _pageSize).ceil();

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
          await _vrstaZalbeProvider.delete(id);

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
      content: Text(
          "Jeste li sigurni da želite obrisati ovu vrstu žalbe?\nAko nastavite, žalbe koje uključuju ovu vrstu žalbe će biti obrisane."),
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
      selectedIndex: 10,
      headerTitle: "Vrste žalbe",
      headerDescription: "Ovdje možete pogledati vrste žalbe.",
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
                name: "NazivGTE",
                decoration: buildTextFieldDecoration(
                    hintText: "Naziv...",
                    labelText: "Naziv",
                    prefixIcon: Icon(Icons.abc_rounded)),
              )),
              CustomButtonWidget(
                buttonText: "Dodaj vrstu žalbe",
                onPress: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => VrstaZalbeDetailsScreen(),
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

  DataRow _buildDataRow(VrstaZalbe e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.naziv.toString()),
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
                        builder: (context) => VrstaZalbeDetailsScreen(
                          vrstaZalbe: e,
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
        vrsteZalbeResult != null &&
        vrsteZalbeResult?.count == 0) {
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
                        rows: vrsteZalbeResult?.result
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
            if (vrsteZalbeResult != null) ...[
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
