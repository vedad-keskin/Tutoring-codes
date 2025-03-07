import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/dogadjaj.dart';
import 'package:ridewithme_admin/providers/dogadjaji_provider.dart';
import 'package:ridewithme_admin/screens/dogadjaji_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class DogadjajiDetailsScreen extends StatefulWidget {
  Dogadjaj? dogadjaj;

  DogadjajiDetailsScreen({super.key, this.dogadjaj});

  @override
  State<DogadjajiDetailsScreen> createState() => _DogadjajiDetailsScreenState();
}

class _DogadjajiDetailsScreenState extends State<DogadjajiDetailsScreen> {
  late DogadjajiProvider _dogadjajiProvider;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _dogadjajiProvider = context.read<DogadjajiProvider>();

    _initialValue = {
      "naziv": widget.dogadjaj?.naziv,
      "opis": widget.dogadjaj?.opis,
      "datumPocetka": widget.dogadjaj?.datumPocetka,
      "datumZavrsetka": widget.dogadjaj?.datumZavrsetka
    };
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
      if (request['datumZavrsetka'] is DateTime) {
        request['datumZavrsetka'] =
            (request['datumZavrsetka'] as DateTime).toIso8601String();
      }
      if (request['datumPocetka'] is DateTime) {
        request['datumPocetka'] =
            (request['datumPocetka'] as DateTime).toIso8601String();
      }

      if (widget.dogadjaj == null) {
        await _dogadjajiProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novi događaj.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const DogadjajiScreen(),
          ),
        );
      } else {
        await _dogadjajiProvider.update(widget.dogadjaj!.id!, request);
        await showSnackBar("Uspješno ste izmjenili događaj.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const DogadjajiScreen(),
          ),
        );
      }
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        selectedIndex: 4,
        backButton: DogadjajiScreen(),
        headerTitle:
            widget.dogadjaj != null ? "Detalji događaja" : "Kreiranje događaja",
        headerDescription: widget.dogadjaj != null
            ? "Ovdje možete da pregledate/izmjenite događaj."
            : "Ovdje možete da kreirate događaj.",
        child: Column(children: [_buildForm(), _save()]));
  }

  Widget _buildForm() {
    return FormBuilder(
        key: _formKey,
        initialValue: _initialValue,
        child: Column(
          children: [
            SizedBox(
              height: 10,
            ),
            Row(
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  name: "naziv",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['naziv'],
                  decoration: InputDecoration(
                    label: Text("Naziv"),
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
                  name: "opis",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['opis'],
                  keyboardType: TextInputType.multiline,
                  maxLines: null,
                  minLines: 3,
                  decoration: buildTextFieldDecoration(
                      hintText: "Opis...", labelText: "Opis"),
                )),
              ],
            ),
            SizedBox(
              height: 10,
            ),
            Row(
              spacing: 10,
              children: [
                Expanded(
                  child: FormBuilderDateTimePicker(
                    name: "datumPocetka",
                    initialValue: _initialValue['datumPocetka'],
                    validator: FormBuilderValidators.compose([
                      FormBuilderValidators.required(
                          errorText: 'Ovo polje je obavezno.'),
                      (value) {
                        if (value == null) return null;
                        if (value.isBefore(DateTime.now())) {
                          return 'Datum početka ne može biti u prošlosti.';
                        }
                        final datumZavrsetka = _formKey
                            .currentState?.fields['datumZavrsetka']?.value;
                        if (datumZavrsetka != null) {
                          if (value.isAfter(datumZavrsetka)) {
                            return 'Datum početka ne može biti nakon datuma završetka.';
                          }
                          if (value.isAtSameMomentAs(datumZavrsetka)) {
                            return 'Datum početka i datum završetka ne mogu biti isti.';
                          }
                        }
                        return null;
                      },
                    ]),
                    decoration: buildTextFieldDecoration(
                      labelText: "Datum početka",
                      hintText: "Datum početka",
                      prefixIcon: Icon(Icons.date_range_rounded),
                    ),
                  ),
                ),
                Expanded(
                  child: FormBuilderDateTimePicker(
                    name: "datumZavrsetka",
                    initialValue: _initialValue['datumZavrsetka'],
                    validator: FormBuilderValidators.compose([
                      FormBuilderValidators.required(
                          errorText: 'Ovo polje je obavezno.'),
                      (value) {
                        if (value == null) return null;
                        if (value.isBefore(DateTime.now())) {
                          return 'Datum završetka ne može biti u prošlosti.';
                        }
                        final datumPocetka = _formKey
                            .currentState?.fields['datumPocetka']?.value;
                        if (datumPocetka != null) {
                          if (value.isBefore(datumPocetka)) {
                            return 'Datum završetka ne može biti prije datuma početka.';
                          }
                          if (value.isAtSameMomentAs(datumPocetka)) {
                            return 'Datum početka i datum završetka ne mogu biti isti.';
                          }
                        }
                        return null;
                      },
                    ]),
                    decoration: buildTextFieldDecoration(
                      labelText: "Datum završetka",
                      hintText: "Datum završetka",
                      prefixIcon: Icon(Icons.date_range_rounded),
                    ),
                  ),
                ),
              ],
            )
          ],
        ));
  }

  Widget _save() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          CustomButtonWidget(
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
