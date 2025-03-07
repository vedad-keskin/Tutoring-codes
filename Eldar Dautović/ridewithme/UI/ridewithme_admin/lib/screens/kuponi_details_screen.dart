import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/kupon.dart';
import 'package:ridewithme_admin/providers/kuponi_provider.dart';
import 'package:ridewithme_admin/screens/kuponi_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class KuponiDetailsScreen extends StatefulWidget {
  Kupon? kupon;
  KuponiDetailsScreen({super.key, this.kupon});

  @override
  State<KuponiDetailsScreen> createState() => _KuponiDetailsScreenState();
}

class _KuponiDetailsScreenState extends State<KuponiDetailsScreen> {
  late KuponiProvider _kuponiProvider;

  List<String>? allowedActions;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  @override
  void initState() {
    super.initState();

    _kuponiProvider = context.read<KuponiProvider>();

    _initialValue = {
      "kod": widget.kupon?.kod,
      "naziv": widget.kupon?.naziv,
      "datumPocetka": widget.kupon?.datumPocetka,
      "brojIskoristivosti": widget.kupon?.brojIskoristivosti.toString(),
      "popust": widget.kupon?.popust.toString()
    };

    initForm();
  }

  Future initForm() async {
    if (widget.kupon != null) {
      allowedActions =
          await _kuponiProvider.allowedActions(widget.kupon?.id ?? 0);
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
            await _kuponiProvider.hide(widget.kupon?.id ?? 0);

            showSnackBar("Uspješno ste sakrili kupon.");
            break;
          }
        case "Edit":
          {
            await _kuponiProvider.edit(widget.kupon?.id ?? 0);

            showSnackBar("Uspješno ste vratili Draft status kuponu.");
            break;
          }
        case "Activate":
          {
            await _kuponiProvider.activate(widget.kupon?.id ?? 0);

            showSnackBar("Uspješno ste aktivirali kupon.");
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
      if (request['datumPocetka'] is DateTime) {
        request['datumPocetka'] =
            (request['datumPocetka'] as DateTime).toIso8601String();
      }

      if (widget.kupon == null) {
        await _kuponiProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novo obavještenje.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const KuponiScreen(),
          ),
        );
      } else {
        await _kuponiProvider.update(widget.kupon!.id!, request);
        await showSnackBar("Uspješno ste izmjenili kupon.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const KuponiScreen(),
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
      selectedIndex: 5,
      backButton: KuponiScreen(),
      headerTitle: widget.kupon != null ? "Detalji kupona" : "Kreiranje kupona",
      headerDescription: widget.kupon != null
          ? "Ovdje možete da pregledate detalje kupona."
          : "Ovdje možete da kreirate novi kupon.",
      child: Column(
        children: [
          isLoading ? LoadingSpinnerWidget() : _buildActions(),
          isLoading ? LoadingSpinnerWidget() : _buildForm(),
          _save(),
        ],
      ),
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
                      widget.kupon == null,
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
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.kupon == null,
                  name: "kod",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.match(RegExp(r'^[^\s]*$'),
                        errorText:
                            'Razmak riječi u kodu mora biti izražen sa "-"'),
                    FormBuilderValidators.minLength(5,
                        errorText: 'Kod mora biti minimalno 5 karaktera dug.'),
                    FormBuilderValidators.uppercase(
                        errorText:
                            'Kod mora biti sastavljen od velikih slova.'),
                  ]),
                  initialValue: _initialValue['kod'],
                  decoration: InputDecoration(
                    label: Text("Kod"),
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
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.kupon == null,
                  name: "brojIskoristivosti",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.integer(
                        errorText: 'Ovo polje mora biti broj.')
                  ]),
                  valueTransformer: (value) {
                    if (value != null) {
                      return int.tryParse(value);
                    }
                  },
                  initialValue: _initialValue['brojIskoristivosti'],
                  decoration: InputDecoration(
                    label: Text("Broj iskoristivosti"),
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
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.kupon == null,
                  name: "popust",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.float(
                        errorText: 'Ovo polje mora biti broj.'),
                    FormBuilderValidators.max(1,
                        errorText: 'Popust moze biti do 1.0 (100%).')
                  ]),
                  valueTransformer: (value) {
                    if (value != null) {
                      return double.tryParse(value);
                    }
                  },
                  initialValue: _initialValue['popust'],
                  decoration: InputDecoration(
                    label: Text("Popust"),
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
                    child: FormBuilderDateTimePicker(
                        name: "datumPocetka",
                        enabled:
                            (allowedActions?.contains("Update") ?? false) ||
                                widget.kupon == null,
                        initialValue: _initialValue['datumPocetka'],
                        decoration: buildTextFieldDecoration(
                          labelText: "Datum početka",
                          hintText: "Datum početka",
                        ))),
              ],
            )
          ],
        ));
  }

  Widget _buildActions() {
    return Column(
      children: [
        Row(
          spacing: 10,
          mainAxisAlignment: MainAxisAlignment.end,
          children: (allowedActions ?? [])
              .where((e) =>
                  KuponiActions.fromString(e)?.naziv.isNotEmpty ??
                  false) // Filtriranje praznih
              .map((e) {
            final action = KuponiActions.fromString(e);
            return CustomButtonWidget(
              buttonText: action!.naziv,
              onPress: () => executeAction(e),
              buttonColor: action.boja,
              textColor: action.textBoja,
            );
          }).toList(),
        ),
        SizedBox(
          height: 20,
        )
      ],
    );
  }

  Widget _save() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          CustomButtonWidget(
              isDisabled: !(allowedActions?.contains("Update") ?? false) &&
                  widget.kupon != null,
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
