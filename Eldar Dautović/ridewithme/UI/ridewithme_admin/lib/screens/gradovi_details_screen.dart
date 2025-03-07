import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/providers/gradovi_provider.dart';
import 'package:ridewithme_admin/screens/gradovi_screen.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class GradoviDetailsScreen extends StatefulWidget {
  Gradovi? grad;
  GradoviDetailsScreen({super.key, this.grad});

  @override
  State<GradoviDetailsScreen> createState() => _GradoviDetailsScreenState();
}

class _GradoviDetailsScreenState extends State<GradoviDetailsScreen> {
  late GradoviProvider _gradoviProvider;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();

    _gradoviProvider = context.read<GradoviProvider>();

    _initialValue = {
      "naziv": widget.grad?.naziv,
      "longitude": widget.grad?.longitude.toString(),
      "latitude": widget.grad?.latitude.toString(),
    };
  }

  Future<void> handleFormSubmit() async {
    try {
      if (!_formKey.currentState!.saveAndValidate()) {
        return;
      }

      var request = Map.from(_formKey.currentState!.value);

      if (widget.grad == null) {
        await _gradoviProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novi grad.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const GradoviScreen(),
          ),
        );
      } else {
        await _gradoviProvider.update(widget.grad!.id!, request);
        await showSnackBar("Uspješno ste izmjenili grad.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const GradoviScreen(),
          ),
        );
      }
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

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 9,
      backButton: GradoviScreen(),
      headerTitle: widget.grad != null ? "Detalji grada" : "Dodavanje grada",
      headerDescription: widget.grad != null
          ? "Ovdje možete da uredite ili pregledate detalje grada"
          : "Ovdje možete da kreirate novi grad.",
      child: Column(
        children: [_buildForm(), _save()],
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
                  name: "longitude",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.float(
                        errorText: 'Ovo polje mora biti broj.')
                  ]),
                  valueTransformer: (value) {
                    if (value != null) {
                      return double.tryParse(value);
                    }
                  },
                  initialValue: _initialValue['longitude'],
                  decoration: InputDecoration(
                    label: Text("Geo. dužina"),
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
                  name: "latitude",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.float(
                        errorText: 'Ovo polje mora biti broj.')
                  ]),
                  valueTransformer: (value) {
                    if (value != null) {
                      return double.tryParse(value);
                    }
                  },
                  initialValue: _initialValue['latitude'],
                  decoration: InputDecoration(
                    label: Text("Geo. širina"),
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
