import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/models/voznja.dart';
import 'package:ridewithme_admin/providers/gradovi_provider.dart';
import 'package:ridewithme_admin/providers/korisnik_provider.dart';
import 'package:ridewithme_admin/providers/voznje_provider.dart';
import 'package:ridewithme_admin/screens/voznje_list_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';
import '../models/search_result.dart';

class VoznjeDetailsScreen extends StatefulWidget {
  Voznja? voznja;
  VoznjeDetailsScreen({super.key, this.voznja});

  @override
  State<VoznjeDetailsScreen> createState() => _VoznjeDetailsScreenState();
}

class _VoznjeDetailsScreenState extends State<VoznjeDetailsScreen> {
  late VoznjeProvider _voznjeProvider;
  late GradoviProvider _gradoviProvider;
  late KorisnikProvider _korisnikProvider;

  SearchResult<Gradovi>? gradoviResult;
  SearchResult<Korisnik>? korisniciResult;
  List<String>? allowedActions;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  @override
  void initState() {
    _voznjeProvider = context.read<VoznjeProvider>();
    _gradoviProvider = context.read<GradoviProvider>();
    _korisnikProvider = context.read<KorisnikProvider>();
    super.initState();

    _initialValue = {
      'napomena': widget.voznja?.napomena,
      'cijena': widget.voznja?.cijena.toString(),
      'gradOdId': widget.voznja?.gradOd?.id,
      'gradDoId': widget.voznja?.gradDo?.id,
      'datumVrijemePocetka': widget.voznja?.datumVrijemePocetka,
      'vozacId': widget.voznja?.vozac?.id
    };

    initForm();
  }

  Future initForm() async {
    gradoviResult = await _gradoviProvider.get();
    korisniciResult = await _korisnikProvider.get();
    if (widget.voznja != null) {
      allowedActions =
          await _voznjeProvider.allowedActions(widget.voznja?.id ?? 0);
    }

    setState(() {
      isLoading = false;
    });
  }

  void executeAction(String name) async {
    try {
      switch (name) {
        case "Hide":
          {
            await _voznjeProvider.hide(widget.voznja?.id ?? 0);

            showSnackBar("Uspješno ste sakrili vožnju.");
            break;
          }
        case "Edit":
          {
            await _voznjeProvider.edit(widget.voznja?.id ?? 0);

            showSnackBar("Uspješno ste vratili Draft status vožnji.");
            break;
          }
        case "Activate":
          {
            await _voznjeProvider.activate(widget.voznja?.id ?? 0);

            showSnackBar("Uspješno ste aktivirali vožnju.");
            break;
          }
        default:
      }

      setState(() {
        isLoading = true;
      });

      initForm();
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 3,
      backButton: VoznjeListScreen(),
      headerTitle:
          widget.voznja != null ? "Detalji vožnje" : "Kreiranje vožnje",
      headerDescription: widget.voznja != null
          ? "Ovdje možete pogledati detalje o vožnji."
          : "Ovdje možete kreirati novu vožnju",
      child: Column(
        children: [
          _buildActions(),
          isLoading ? LoadingSpinnerWidget() : _buildForm(),
          _save()
        ],
      ),
    );
  }

  Widget _buildActions() {
    return Column(
      children: [
        Row(
          spacing: 10,
          mainAxisAlignment: MainAxisAlignment.end,
          children: (allowedActions ?? [])
              .where((e) =>
                  VoznjaActions.fromString(e)?.naziv.isNotEmpty ??
                  false) // Filtriranje praznih
              .map((e) {
            final action = VoznjaActions.fromString(e);
            return CustomButtonWidget(
              buttonText: action!.naziv,
              onPress: () => executeAction(e),
              buttonColor: action.boja,
            );
          }).toList(),
        ),
        SizedBox(
          height: 20,
        )
      ],
    );
  }

  Widget _buildForm() {
    return FormBuilder(
        key: _formKey,
        initialValue: _initialValue,
        child: Column(
          children: [
            Row(
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.voznja == null,
                  name: "cijena",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.integer(
                        errorText: "Ovo polje mora biti broj.")
                  ]),
                  initialValue: _initialValue['cijena'],
                  decoration: InputDecoration(
                    prefixIcon: Icon(Icons.attach_money_rounded),
                    label: Text("Cijena"),
                    labelStyle: TextStyle(fontSize: 14, fontFamily: "Inter"),
                    filled: true,
                    fillColor: Color(0xFFF3FCFC),
                    border: OutlineInputBorder(
                      borderSide: BorderSide(color: Color(0xFFE3E3E3)),
                    ),
                    enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Color(0xFFE3E3E3)),
                    ),
                  ),
                )),
              ],
            ),
            SizedBox(
              height: 10,
            ),
            Row(
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  name: "napomena",
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.voznja == null,
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['napomena'],
                  keyboardType: TextInputType.multiline,
                  maxLines: null,
                  minLines: 3,
                  decoration: buildTextFieldDecoration(
                      hintText: "Napomena...", labelText: "Napomena"),
                )),
              ],
            ),
            SizedBox(
              height: 10,
            ),
            Row(
              children: [
                Expanded(
                    child: buildDropdown(
                  name: 'gradOdId',
                  labelText: "Grad od",
                  prefixIcon: Icon(Icons.location_city_rounded),
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.voznja == null,
                  initialValue: widget.voznja?.gradOd?.id.toString(),
                  items: [
                    DropdownMenuItem(
                      value: null,
                      child: Text("Odaberi"),
                    ),
                    ...gradoviResult!.result
                        .map((e) => DropdownMenuItem(
                              value: e.id.toString(),
                              child: Text(
                                e.naziv ?? "",
                              ),
                            ))
                        .toList()
                  ],
                )),
                SizedBox(
                  width: 10,
                ),
                Expanded(
                    child: buildDropdown(
                  name: 'gradDoId',
                  labelText: "Grad do",
                  hintText: "Grad do",
                  prefixIcon: Icon(Icons.location_city_rounded),
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.voznja == null,
                  initialValue: widget.voznja?.gradDo?.id.toString(),
                  items: [
                    DropdownMenuItem(
                      value: null,
                      child: Text("Odaberi"),
                    ),
                    ...gradoviResult!.result
                        .map((e) => DropdownMenuItem(
                              value: e.id.toString(),
                              child: Text(
                                e.naziv ?? "",
                              ),
                            ))
                        .toList()
                  ],
                )),
                SizedBox(
                  width: 10,
                ),
                Expanded(
                    child: FormBuilderDateTimePicker(
                        name: "datumVrijemePocetka",
                        enabled:
                            (allowedActions?.contains("Update") ?? false) ||
                                widget.voznja == null,
                        initialValue: _initialValue['datumVrijemePocetka'],
                        decoration: buildTextFieldDecoration(
                            labelText: "Datum vrijeme početka",
                            hintText: "Datum vrijeme početka",
                            prefixIcon: Icon(Icons.date_range_rounded)))),
              ],
            ),
            SizedBox(
              height: 10,
            ),
            Row(children: [
              Expanded(
                  child: buildDropdown(
                name: 'vozacId',
                labelText: "Vozač",
                prefixIcon: Icon(Icons.person),
                enabled: (allowedActions?.contains("Update") ?? false) ||
                    widget.voznja == null,
                items: korisniciResult?.result
                        .map((e) => DropdownMenuItem(
                              value: e.id,
                              child: Text(
                                e.korisnickoIme ?? "",
                              ),
                            ))
                        .toList() ??
                    [],
              )),
            ])
          ],
        ));
  }

  Future<void> showSnackBar(String message) async {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        behavior: SnackBarBehavior.floating,
        content: Text(message),
        action: SnackBarAction(
          label: "U redu",
          onPressed: () =>
              ScaffoldMessenger.of(context)..removeCurrentSnackBar(),
        ),
      ),
    );
  }

  Future<void> handleFormSubmit() async {
    try {
      if (!_formKey.currentState!.saveAndValidate()) {
        return;
      }

      var request = Map.from(_formKey.currentState!.value);
      if (request['datumVrijemePocetka'] is DateTime) {
        request['datumVrijemePocetka'] =
            (request['datumVrijemePocetka'] as DateTime).toIso8601String();
      }

      if (widget.voznja == null) {
        await _voznjeProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novu vožnju.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const VoznjeListScreen(),
          ),
        );
      } else {
        await _voznjeProvider.update(widget.voznja!.id!, request);
        await showSnackBar("Uspješno ste izmjenili vožnju.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const VoznjeListScreen(),
          ),
        );
      }
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  Widget _save() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          CustomButtonWidget(
              isDisabled: !(allowedActions?.contains("Update") ?? false) &&
                  widget.voznja != null,
              buttonText: "Sačuvaj",
              onPress: () async {
                await handleFormSubmit();
              } // Promenite zaobljenost ivica
              ),
        ],
      ),
    );
  }
}
