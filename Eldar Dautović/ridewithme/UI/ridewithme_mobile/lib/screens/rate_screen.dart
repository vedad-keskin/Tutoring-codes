import 'package:custom_rating_bar/custom_rating_bar.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/recenzije_provider.dart';
import 'package:ridewithme_mobile/screens/voznje_details_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/utils/input_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';

class RateScreen extends StatefulWidget {
  Voznja voznja;
  RateScreen({super.key, required this.voznja});

  @override
  State<RateScreen> createState() => _RateScreenState();
}

class _RateScreenState extends State<RateScreen> {
  late RecenzijeProvider _recenzijeProvider;
  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _recenzijeProvider = context.read<RecenzijeProvider>();

    checkIfRated();
  }

  Future checkIfRated() async {
    var results =
        await _recenzijeProvider.get(filter: {"VoznjaId": widget.voznja.id});

    if (results.result.isNotEmpty) {
      Navigator.of(context).push(
        MaterialPageRoute(
          builder: (context) => VoznjeDetailsScreen(voznja: widget.voznja),
        ),
      );

      showSnackBar("Na ovu vožnju je već ostavljena recenzija.");
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
        selectedIndex: 3,
        header: "Ocjena",
        headerDescription: "Ovdje možete da ostavite ocjenu vožnje",
        headerColor: Color(0xFF39D5C3),
        headerTextColor: Colors.black,
        child: Flexible(
          child: SingleChildScrollView(
            child: Column(
              children: [_buildForm(), _save()],
            ),
          ),
        ));
  }

  Widget _buildForm() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: FormBuilder(
        key: _formKey,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Container(
              child: Text("Ocjena:",
                  style: TextStyle(
                      fontFamily: "Inter",
                      fontSize: 12,
                      color: Colors.black,
                      fontWeight: FontWeight.bold)),
            ),
            SizedBox(
              height: 10,
            ),
            FormBuilderField(
                name: "ocjena",
                builder: (field) {
                  return Container(
                    padding: EdgeInsets.symmetric(vertical: 40),
                    decoration: BoxDecoration(
                        color: Color(0xFFF3FCFC),
                        border: Border.all(color: Color(0xFFE3E3E3)),
                        borderRadius: BorderRadius.circular(5)),
                    child: RatingBar(
                      alignment: Alignment.center,
                      filledIcon: Icons.star_rounded,
                      emptyIcon: Icons.star_border_rounded,
                      onRatingChanged: (value) => ratingChanged(value),
                      initialRating: 0,
                      maxRating: 5,
                      size: 40,
                    ),
                  );
                }),
            SizedBox(
              height: 10,
            ),
            Container(
              child: Text("Napomena:",
                  style: TextStyle(
                      fontFamily: "Inter",
                      fontSize: 12,
                      color: Colors.black,
                      fontWeight: FontWeight.bold)),
            ),
            SizedBox(
              height: 10,
            ),
            Row(
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  name: "komentar",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  keyboardType: TextInputType.multiline,
                  maxLines: null,
                  minLines: 3,
                  decoration: buildTextFieldDecoration(
                      hintText: "Napomena...", labelText: "Napomena"),
                )),
              ],
            ),
          ],
        ),
      ),
    );
  }

  void ratingChanged(double value) {
    _formKey.currentState?.patchValue({"ocjena": value.toInt()});
    setState(() {});
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

      await _recenzijeProvider.insert({
        "ocjena": request['ocjena'],
        "komentar": request['komentar'],
        "korisnikId": Authorization.id ?? 0,
        "voznjaId": widget.voznja.id
      });

      await showSnackBar("Uspješno ste ocjenili vožnju.");

      Navigator.of(context).push(
        MaterialPageRoute(
          builder: (context) => VoznjeDetailsScreen(voznja: widget.voznja),
        ),
      );
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  Widget _save() {
    return Container(
      margin: EdgeInsets.only(top: 40, left: 20, right: 20),
      child: CustomButtonWidget(
          isFullWidth: true,
          padding: EdgeInsets.symmetric(vertical: 20),
          buttonText: "Ostavi ocjenu",
          onPress: () async {
            await handleFormSubmit();
          } // Promenite zaobljenost ivica
          ),
    );
  }
}
