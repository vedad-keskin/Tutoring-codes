import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/vrsta_zalbe.dart';
import 'package:ridewithme_admin/providers/vrsta_zalbe_provider.dart';
import 'package:ridewithme_admin/screens/vrsta_zalbe_screen.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class VrstaZalbeDetailsScreen extends StatefulWidget {
  VrstaZalbe? vrstaZalbe;
  VrstaZalbeDetailsScreen({super.key, this.vrstaZalbe});

  @override
  State<VrstaZalbeDetailsScreen> createState() =>
      _VrstaZalbeDetailsScreenState();
}

class _VrstaZalbeDetailsScreenState extends State<VrstaZalbeDetailsScreen> {
  late VrstaZalbeProvider _vrstaZalbeProvider;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();

    _vrstaZalbeProvider = context.read<VrstaZalbeProvider>();

    _initialValue = {
      "naziv": widget.vrstaZalbe?.naziv,
    };
  }

  Future<void> handleFormSubmit() async {
    try {
      if (!_formKey.currentState!.saveAndValidate()) {
        return;
      }

      var request = Map.from(_formKey.currentState!.value);

      if (widget.vrstaZalbe == null) {
        await _vrstaZalbeProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novu vrstu žalbe.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const VrstaZalbeScreen(),
          ),
        );
      } else {
        await _vrstaZalbeProvider.update(widget.vrstaZalbe!.id!, request);
        await showSnackBar("Uspješno ste izmjenili vrstu žalbe.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const VrstaZalbeScreen(),
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
      selectedIndex: 10,
      backButton: VrstaZalbeScreen(),
      headerTitle: widget.vrstaZalbe != null
          ? "Detalji vrste žalbe"
          : "Dodavanje vrste žalbe",
      headerDescription: widget.vrstaZalbe != null
          ? "Ovdje možete da uredite ili pregledate detalje vrste žalbe"
          : "Ovdje možete da kreirate novu vrstu žalbe.",
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
