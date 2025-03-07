import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/models/grad.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/providers/gradovi_provider.dart';
import 'package:ridewithme_mobile/utils/input_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class RidesFilterWidget extends StatefulWidget {
  Map<String, dynamic> initialFilters;
  RidesFilterWidget({super.key, required this.initialFilters});

  @override
  State<RidesFilterWidget> createState() => _RidesFilterWidgetState();
}

class _RidesFilterWidgetState extends State<RidesFilterWidget> {
  late GradoviProvider _gradoviProvider;

  SearchResult<Gradovi>? gradoviResults;

  bool isLoading = true;

  Map<String, dynamic> _initialValue = {};

  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _gradoviProvider = context.read<GradoviProvider>();

    _initialValue = {
      'IsGradoviIncluded': widget.initialFilters['IsGradoviIncluded'],
      'IsKorisniciIncluded': widget.initialFilters['IsKorisniciIncluded'],
      'GradOdId': widget.initialFilters['GradOdId']?.toString(),
      'GradDoId': widget.initialFilters['GradDoId']?.toString(),
      'OrderBy': widget.initialFilters['OrderBy'] ?? "DatumVrijemePocetka ASC",
      'Status': widget.initialFilters['Status'] ?? 'active'
    };

    initFilters();
  }

  Future initFilters() async {
    gradoviResults = await _gradoviProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            isLoading ? LoadingSpinnerWidget(height: 20) : _buildSearch()
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      onChanged: () {
        _formKey.currentState?.save();
      },
      child: Padding(
        padding: const EdgeInsets.only(bottom: 20),
        child: Column(
          spacing: 10,
          children: [
            buildDropdown(
              name: "GradOdId",
              labelText: "Grad od",
              prefixIcon: Icon(Icons.location_city_rounded),
              initialValue: _initialValue['GradOdId']?.toString(),
              items: _buildGradoviDropdownItems(),
            ),
            buildDropdown(
              name: "GradDoId",
              labelText: "Grad do",
              hintText: "Grad do",
              initialValue: _initialValue['GradDoId']?.toString(),
              prefixIcon: Icon(Icons.location_city_rounded),
              items: _buildGradoviDropdownItems(),
            ),
            buildDropdown(
              name: "OrderByField",
              labelText: "Sortiraj po",
              initialValue: "DatumVrijemePocetka",
              prefixIcon: Icon(Icons.sort_by_alpha_rounded),
              items: const [
                DropdownMenuItem(
                    value: "DatumVrijemePocetka", child: Text("Datum početka")),
                DropdownMenuItem(
                    value: "DatumVrijemeZavrsetka",
                    child: Text("Datum završetka")),
                DropdownMenuItem(value: "Cijena", child: Text("Cijena")),
              ],
            ),
            buildDropdown(
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
            Row(
              spacing: 10,
              children: [
                CustomButtonWidget(
                  fontSize: 14,
                  buttonText: "Pretraga",
                  onPress: () {
                    String orderByField =
                        _formKey.currentState?.value['OrderByField'] ?? "id";
                    String orderByDirection =
                        _formKey.currentState?.value['OrderByDirection'] ??
                            "ASC";

                    Navigator.pop(context, {
                      'IsGradoviIncluded': true,
                      'IsKorisniciIncluded': true,
                      'GradOdId': _formKey.currentState?.value['GradOdId'],
                      'GradDoId': _formKey.currentState?.value['GradDoId'],
                      'OrderBy': "$orderByField $orderByDirection",
                      'Status': 'active',
                    });
                  },
                ),
                CustomButtonWidget(
                  fontSize: 14,
                  buttonText: "Očisti filtere",
                  buttonColor: Colors.white,
                  onPress: () {
                    Navigator.pop(context, {
                      'IsGradoviIncluded': true,
                      'IsKorisniciIncluded': true,
                      'GradOdId': null,
                      'GradDoId': null,
                      'OrderBy': 'id ASC',
                      'Status': 'active'
                    });
                  },
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }

  List<DropdownMenuItem<String>> _buildGradoviDropdownItems() {
    final items = (gradoviResults?.result ?? [])
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
}
