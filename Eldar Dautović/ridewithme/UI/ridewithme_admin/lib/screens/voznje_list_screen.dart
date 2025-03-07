import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/models/voznja.dart';
import 'package:ridewithme_admin/providers/gradovi_provider.dart';
import 'package:ridewithme_admin/providers/voznje_provider.dart';
import 'package:ridewithme_admin/screens/voznje_details_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/table_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class VoznjeListScreen extends StatefulWidget {
  const VoznjeListScreen({super.key});

  @override
  State<VoznjeListScreen> createState() => _VoznjeListScreenState();
}

class _VoznjeListScreenState extends State<VoznjeListScreen> {
  late VoznjeProvider _voznjeProvider;
  late GradoviProvider _gradoviProvider;

  SearchResult<Voznja>? result;
  SearchResult<Gradovi>? gradoviResult;

  final _horizontalScrollController = ScrollController();

  Map<String, dynamic> _initialValue = {};

  final List<Map<String, dynamic>> columnData = [
    {"label": "Broj vožnje", "numeric": true},
    {"label": "Grad od"},
    {"label": "Grad do"},
    {"label": "Vozač"},
    {"label": "Klijent"},
    {"label": "Status"},
    {"label": "Početak"},
    {"label": "Završetak"},
    {"label": "Cijena", "numeric": true},
    {"label": "", "numeric": true}, // Prazna kolona za dugmad
  ];

  int _pageNumber = 1;
  final int _pageSize = 10;
  int _totalPages = 1;

  bool isLoading = true;

  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    super.initState();
    _voznjeProvider = context.read<VoznjeProvider>();
    _gradoviProvider = context.read<GradoviProvider>();

    _initialValue = {
      'IsGradoviIncluded': true,
      'IsKorisniciIncluded': true,
      'GradOdId': null,
      'GradDoId': null,
      'OrderBy': 'id ASC',
      'Status': null
    };

    initTable();
    initDropdowns();
  }

  Future initDropdowns() async {
    gradoviResult = await _gradoviProvider.get();
  }

  Future initTable() async {
    String orderByField = _formKey.currentState?.value['OrderByField'] ?? "id";
    String orderByDirection =
        _formKey.currentState?.value['OrderByDirection'] ?? "ASC";

    result = await _voznjeProvider.get(filter: {
      'IsGradoviIncluded': true,
      'IsKorisniciIncluded': true,
      'GradOdId': _formKey.currentState?.value['gradOdId'],
      'GradDoId': _formKey.currentState?.value['gradDoId'],
      'OrderBy': "$orderByField $orderByDirection",
      'Status': _formKey.currentState?.value['status'],
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
        Navigator.pop(context);
      },
    );
    Widget continueButton = TextButton(
      child: Text("Da"),
      onPressed: () async {
        try {
          await _voznjeProvider.delete(id);

          Navigator.pop(context);

          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              behavior: SnackBarBehavior.floating,
              content: Text("Uspješno ste obrisali vožnju ID $id."),
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
      content: Text("Da li ste sigurni da želite da obrišete vožnju ID $id ?"),
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
        selectedIndex: 3,
        headerTitle: "Vožnje",
        headerDescription: "Ovdje možete pronaći listu vožnji.",
        child: Container(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildSearch(),
              isLoading ? LoadingSpinnerWidget() : _buildResultView()
            ],
          ),
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
              child: buildDropdown(
                name: "gradOdId",
                labelText: "Grad od",
                prefixIcon: Icon(Icons.location_city_rounded),
                items: _buildGradoviDropdownItems(),
                onClear: () {
                  _formKey.currentState!.fields['gradOdId']?.reset();
                },
              ),
            ),
            Expanded(
              child: buildDropdown(
                name: "gradDoId",
                labelText: "Grad do",
                hintText: "Grad do",
                prefixIcon: Icon(Icons.location_city_rounded),
                items: _buildGradoviDropdownItems(),
                onClear: () {
                  _formKey.currentState!.fields['gradDoId']?.reset();
                },
              ),
            ),
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
                  ...VoznjaStatus.values
                      .map((status) => DropdownMenuItem(
                            value: status.name,
                            child: Text(status.naziv),
                          ))
                      .toList(),
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
                initialValue: "id",
                prefixIcon: Icon(Icons.sort_by_alpha_rounded),
                items: const [
                  DropdownMenuItem(value: "id", child: Text("Broj vožnje")),
                  DropdownMenuItem(
                      value: "DatumVrijemePocetka",
                      child: Text("Datum početka")),
                  DropdownMenuItem(
                      value: "DatumVrijemeZavrsetka",
                      child: Text("Datum završetka")),
                  DropdownMenuItem(value: "Cijena", child: Text("Cijena")),
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
              buttonText: "Dodaj vožnju",
              onPress: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => VoznjeDetailsScreen(),
                  ),
                );
              },
            ),
          ],
        ),
      ),
    );
  }

  List<DropdownMenuItem<String>> _buildGradoviDropdownItems() {
    final items = (gradoviResult?.result ?? [])
        .map((e) => DropdownMenuItem(
              value: e.id.toString(),
              child: Text(
                e.naziv ?? "",
                style: const TextStyle(color: Colors.black),
              ),
            ))
        .toList();

    // Dodaj opciju "Odaberi" s null vrijednošću
    items.insert(
      0,
      const DropdownMenuItem(
        value: null,
        child: Text(
          'Odaberi',
          style: TextStyle(color: Colors.black),
        ),
      ),
    );

    return items;
  }

  DataRow _buildDataRow(Voznja e, BuildContext context) {
    return DataRow(
      cells: [
        buildDataCell("#${e.id?.toString()}"),
        buildDataCell(e.gradOd?.naziv),
        buildDataCell(e.gradDo?.naziv),
        buildDataCell("${e.vozac?.ime ?? ""} ${e.vozac?.prezime ?? ""}"),
        buildDataCell(e.klijent != null
            ? "${e.klijent?.ime} ${e.klijent?.prezime}"
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
        buildDataCell(e.datumVrijemePocetka != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumVrijemePocetka!)
            : "N/A"),
        buildDataCell(e.datumVrijemeZavrsetka != null
            ? DateFormat('dd/MM/yyyy HH:mm').format(e.datumVrijemeZavrsetka!)
            : "N/A"),
        buildDataCell("${e.cijena} KM"),
        DataCell(Row(
          children: [
            if (e.stateMachine == 'draft' || e.stateMachine == 'completed') ...[
              IconButton(
                iconSize: 17,
                onPressed: () {
                  showAlertDialog(context, e.id ?? 0);
                },
                icon: const Icon(Icons.delete),
              )
            ],
            IconButton(
              onPressed: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => VoznjeDetailsScreen(voznja: e),
                  ),
                );
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
    if (isLoading == false && result != null && result?.count == 0) {
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
                        rows: result?.result
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
            if (result != null) ...[
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
