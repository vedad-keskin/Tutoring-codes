import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/vrsta_zalbe.dart';
import 'package:ridewithme_mobile/providers/vrste_zalbe_provider.dart';
import 'package:ridewithme_mobile/providers/zalbe_provider.dart';
import 'package:ridewithme_mobile/screens/zalbe_details_screen.dart';
import 'package:ridewithme_mobile/screens/zalbe_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/utils/input_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class ZalbeCreateScreen extends StatefulWidget {
  const ZalbeCreateScreen({super.key});

  @override
  State<ZalbeCreateScreen> createState() => _ZalbeCreateScreenState();
}

class _ZalbeCreateScreenState extends State<ZalbeCreateScreen> {
  late ZalbeProvider _zalbeProvider;
  late VrsteZalbeProvider _vrsteZalbeProvider;

  SearchResult<VrstaZalbe>? vrsteZalbeResults;

  final _formKey = GlobalKey<FormBuilderState>();

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _zalbeProvider = context.read<ZalbeProvider>();
    _vrsteZalbeProvider = context.read<VrsteZalbeProvider>();
    initForm();
  }

  Future initForm() async {
    vrsteZalbeResults = await _vrsteZalbeProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
        selectedIndex: 4,
        child: Flexible(
          child: SingleChildScrollView(
            child: Column(
              children: [_buildHeader(), _buildForm(), _save()],
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
            spacing: 10,
            children: [
              isLoading
                  ? LoadingSpinnerWidget(height: 50)
                  : buildDropdown(
                      name: "vrstaZalbeId",
                      labelText: "Vrsta žalbe",
                      prefixIcon: Icon(Icons.sticky_note_2_rounded),
                      initialValue: vrsteZalbeResults?.result[0].id.toString(),
                      items: _buildVrsteZalbeDropdownMenu(),
                    ),
              FormBuilderTextField(
                  name: "naslov",
                  keyboardType: TextInputType.number,
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  decoration: buildTextFieldDecoration(
                    labelText: "Naslov",
                    hintText: "Naslov",
                  )),
              FormBuilderTextField(
                name: "sadrzaj",
                validator: FormBuilderValidators.compose([
                  FormBuilderValidators.required(
                    errorText: 'Ovo polje je obavezno.',
                  ),
                ]),
                keyboardType: TextInputType.multiline,
                maxLines: null,
                minLines: 3,
                decoration: buildTextFieldDecoration(
                    hintText: "Sadržaj...", labelText: "Sadržaj žalbe"),
              )
            ],
          )),
    );
  }

  Widget _buildHeader() {
    return Container(
      margin: EdgeInsets.all(20),
      decoration: BoxDecoration(
          color: Color(0xFF7463DE).withAlpha(60),
          borderRadius: BorderRadius.circular(15)),
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          spacing: 20,
          children: [
            Row(
              spacing: 10,
              children: [
                SizedBox(
                  height: 150,
                  width: 10,
                  child: DecoratedBox(
                      decoration: BoxDecoration(color: Color(0xFF7463DE))),
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Kreiranje',
                      style: _buildTextStyle(),
                    ),
                    Text(
                      "nove",
                      style: _buildTextStyle(),
                    ),
                    Text('žalbe', style: _buildTextStyle())
                  ],
                )
              ],
            ),
          ],
        ),
      ),
    );
  }

  TextStyle _buildTextStyle() {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: 30,
        color: Color(0xFF072220),
        fontWeight: FontWeight.w900);
  }

  List<DropdownMenuItem<String>> _buildVrsteZalbeDropdownMenu() {
    return (vrsteZalbeResults?.result ?? [])
        .map((e) => DropdownMenuItem(
              value: e.id.toString(),
              child: Text(
                e.naziv ?? "",
                style: const TextStyle(color: Colors.black),
              ),
            ))
        .toList();
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

      var result = await _zalbeProvider.insert({
        "vrstaZalbeId": request['vrstaZalbeId'],
        "naslov": request['naslov'],
        "sadrzaj": request['sadrzaj'],
        "korisnikId": Authorization.id ?? 0,
      });

      await showSnackBar("Uspješno ste podnijeli žalbu.");

      Navigator.of(context).push(
        MaterialPageRoute(
          builder: (context) => ZalbeDetailsScreen(
            zalba: result,
          ),
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
          buttonText: "Podnesi žalbu",
          onPress: () async {
            await handleFormSubmit();
          } // Promenite zaobljenost ivica
          ),
    );
  }
}
