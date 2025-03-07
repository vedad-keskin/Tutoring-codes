import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/faq.dart';
import 'package:ridewithme_admin/providers/faq_provider.dart';
import 'package:ridewithme_admin/screens/faq_screen.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class FaqDetailsScreen extends StatefulWidget {
  FAQ? faq;
  FaqDetailsScreen({super.key, this.faq});

  @override
  State<FaqDetailsScreen> createState() => _FaqDetailsScreenState();
}

class _FaqDetailsScreenState extends State<FaqDetailsScreen> {
  late FaqProvider _faqProvider;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();

    _faqProvider = context.read<FaqProvider>();

    _initialValue = {
      "pitanje": widget.faq?.pitanje,
      "odgovor": widget.faq?.odgovor,
    };
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 11,
      backButton: FaqScreen(),
      headerTitle: widget.faq != null ? "Detalji FAQ" : "Dodavanje FAQ",
      headerDescription: widget.faq != null
          ? "Ovdje možete da pregledate/izmjenite FAQ."
          : "Ovdje možete da dodate novi FAQ.",
      child: Column(
        children: [_buildForm(), _save()],
      ),
    );
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

      if (widget.faq == null) {
        await _faqProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novi FAQ.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const FaqScreen(),
          ),
        );
      } else {
        await _faqProvider.update(widget.faq!.id!, request);
        await showSnackBar("Uspješno ste izmjenili FAQ.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const FaqScreen(),
          ),
        );
      }
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
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
                  name: "pitanje",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  keyboardType: TextInputType.multiline,
                  maxLines: null,
                  minLines: 3,
                  initialValue: _initialValue['pitanje'],
                  decoration: InputDecoration(
                    label: Text("Pitanje"),
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
                  name: "odgovor",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['odgovor'],
                  keyboardType: TextInputType.multiline,
                  maxLines: null,
                  minLines: 3,
                  decoration: InputDecoration(
                    label: Text("Odgovor"),
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
