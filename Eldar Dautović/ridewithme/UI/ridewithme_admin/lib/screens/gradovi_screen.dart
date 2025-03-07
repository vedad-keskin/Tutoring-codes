import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/gradovi_provider.dart';
import 'package:ridewithme_admin/screens/gradovi_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class GradoviScreen extends StatefulWidget {
  const GradoviScreen({super.key});

  @override
  State<GradoviScreen> createState() => _GradoviScreenState();
}

class _GradoviScreenState extends State<GradoviScreen> {
  late GradoviProvider _gradoviProvider;

  SearchResult<Gradovi>? gradoviResult;

  final _formKey = GlobalKey<FormBuilderState>();

  bool isLoading = true;

  final _horizontalScrollController = ScrollController();

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  final List<Map<String, dynamic>> columnData = [
    {"label": "Naziv"},
    {"label": "Geo. dužina"},
    {"label": "Geo. širina"},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _gradoviProvider = context.read<GradoviProvider>();

    initTable();
  }

  Future initTable() async {
    gradoviResult = await _gradoviProvider.get(filter: {
      "NazivGTE": _formKey.currentState?.value['NazivGTE'],
      "Page": _pageNumber,
      "PageSize": _pageSize
    });

    _totalPages = ((gradoviResult?.count ?? 1) / _pageSize).ceil();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      headerTitle: "Gradovi",
      headerDescription:
          "Ovdje možete da pregledate i dodate nove/postojeće gradove.",
      selectedIndex: 9,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _buildSearch(),
          isLoading ? LoadingSpinnerWidget() : _buildResultView(),
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
                buttonText: "Dodaj grad",
                onPress: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => GradoviDetailsScreen(),
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
          await _gradoviProvider.delete(id);

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
          "Jeste li sigurni da želite obrisati ovaj grad?\nAko nastavite, sve vožnje koje uključuju ovaj grad bit će ažurirane tako da im se zamjenska\nvrijednost postavi na prvi dostupni grad i budu vraćene u status 'Draft'."),
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

  DataRow _buildDataRow(Gradovi e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell(e.naziv.toString()),
        buildDataCell(e.longitude.toString()),
        buildDataCell(e.latitude.toString()),
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
                        builder: (context) => GradoviDetailsScreen(
                          grad: e,
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
        gradoviResult != null &&
        gradoviResult?.count == 0) {
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
                        rows: gradoviResult?.result
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
            if (gradoviResult != null) ...[
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
