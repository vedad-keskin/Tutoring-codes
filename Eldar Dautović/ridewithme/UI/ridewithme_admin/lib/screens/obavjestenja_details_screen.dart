import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/models/obavjestenje.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/providers/korisnik_provider.dart';
import 'package:ridewithme_admin/providers/obavjestenja_provider.dart';
import 'package:ridewithme_admin/screens/obavjestenja_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class ObavjestenjaDetailsScreen extends StatefulWidget {
  Obavjestenje? obavjestenje;
  ObavjestenjaDetailsScreen({super.key, this.obavjestenje});

  @override
  State<ObavjestenjaDetailsScreen> createState() =>
      _ObavjestenjaDetailsScreenState();
}

class _ObavjestenjaDetailsScreenState extends State<ObavjestenjaDetailsScreen> {
  late ObavjestenjaProvider _obavjestenjaProvider;
  late KorisnikProvider _korisnikProvider;

  SearchResult<Korisnik>? korisniciResult;
  List<String>? allowedActions;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  @override
  void initState() {
    super.initState();

    _obavjestenjaProvider = context.read<ObavjestenjaProvider>();
    _korisnikProvider = context.read<KorisnikProvider>();

    _initialValue = {
      'naslov': widget.obavjestenje?.naslov,
      'podnaslov': widget.obavjestenje?.podnaslov,
      'opis': widget.obavjestenje?.opis,
      'datumZavrsetka': widget.obavjestenje?.datumZavrsetka
    };

    initForm();
  }

  Future initForm() async {
    korisniciResult = await _korisnikProvider.get();
    if (widget.obavjestenje != null) {
      allowedActions = await _obavjestenjaProvider
          .allowedActions(widget.obavjestenje?.id ?? 0);
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
            await _obavjestenjaProvider.hide(widget.obavjestenje?.id ?? 0);

            showSnackBar("Uspješno ste sakrili obavještenje.");
            break;
          }
        case "Edit":
          {
            await _obavjestenjaProvider.edit(widget.obavjestenje?.id ?? 0);

            showSnackBar("Uspješno ste vratili Draft status obavještenju.");
            break;
          }
        case "Activate":
          {
            await _obavjestenjaProvider.activate(widget.obavjestenje?.id ?? 0);

            showSnackBar("Uspješno ste aktivirali obavještenje.");
            break;
          }
        case "Complete":
          {
            await _obavjestenjaProvider.complete(widget.obavjestenje?.id ?? 0);

            showSnackBar("Uspješno ste aktivirali obavještenje.");
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
      if (request['datumZavrsetka'] is DateTime) {
        request['datumZavrsetka'] =
            (request['datumZavrsetka'] as DateTime).toIso8601String();
      }

      if (widget.obavjestenje == null) {
        await _obavjestenjaProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novo obavještenje.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const ObavjestenjaScreen(),
          ),
        );
      } else {
        await _obavjestenjaProvider.update(widget.obavjestenje!.id!, request);
        await showSnackBar("Uspješno ste izmjenili obavještenje.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const ObavjestenjaScreen(),
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
        selectedIndex: 8,
        backButton: ObavjestenjaScreen(),
        headerTitle: widget.obavjestenje != null
            ? "Detalji obavještenja"
            : "Kreiranje obavještenja",
        headerDescription: widget.obavjestenje != null
            ? "Ovdje možete pogledati detalje o obavještenju."
            : "Ovdje možete kreirati novo obavještenje",
        child: Column(
          children: [
            isLoading ? LoadingSpinnerWidget() : _buildActions(),
            isLoading ? LoadingSpinnerWidget() : _buildForm(),
            _save()
          ],
        ));
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
                      widget.obavjestenje == null,
                  name: "naslov",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['naslov'],
                  decoration: InputDecoration(
                    label: Text("Naslov"),
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
                      widget.obavjestenje == null,
                  name: "podnaslov",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['podnaslov'],
                  decoration: InputDecoration(
                    label: Text("Podnaslov"),
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
                  enabled: (allowedActions?.contains("Update") ?? false) ||
                      widget.obavjestenje == null,
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
              children: [
                Expanded(
                    child: FormBuilderDateTimePicker(
                        name: "datumZavrsetka",
                        enabled:
                            (allowedActions?.contains("Update") ?? false) ||
                                widget.obavjestenje == null,
                        initialValue: _initialValue['datumZavrsetka'],
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: 'Ovo polje je obavezno.'),
                          (value) {
                            if (value == null) return null;
                            if (value.isBefore(DateTime.now())) {
                              return 'Datum završetka ne može biti u prošlosti.';
                            }

                            return null;
                          },
                        ]),
                        decoration: buildTextFieldDecoration(
                            labelText: "Datum završetka",
                            hintText: "Datum završetka",
                            prefixIcon: Icon(Icons.date_range_rounded)))),
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
              isDisabled: !(allowedActions?.contains("Update") ?? false) &&
                  widget.obavjestenje != null,
              buttonText: "Sačuvaj",
              onPress: () async {
                await handleFormSubmit();
              } // Promenite zaobljenost ivica
              ),
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
                  ObavjestenjaActions.fromString(e)?.naziv.isNotEmpty ??
                  false) // Filtriranje praznih
              .map((e) {
            final action = ObavjestenjaActions.fromString(e);
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
}
