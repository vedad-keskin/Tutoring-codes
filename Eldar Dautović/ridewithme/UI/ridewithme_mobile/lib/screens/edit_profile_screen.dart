import 'dart:convert';
import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/providers/korisnik_provider.dart';
import 'package:ridewithme_mobile/screens/profile_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:file_picker/file_picker.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';

class EditProfileScreen extends StatefulWidget {
  const EditProfileScreen({super.key});

  @override
  State<EditProfileScreen> createState() => _EditProfileScreenState();
}

class _EditProfileScreenState extends State<EditProfileScreen> {
  late KorisnikProvider _korisnikProvider;

  Map<String, dynamic> _initialValue = {};
  final _formKey = GlobalKey<FormBuilderState>();

  File? _image;
  final _base64Placeholder =
      "iVBORw0KGgoAAAANSUhEUgAAAbUAAADnCAYAAACZm8iVAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAANhSURBVHhe7dVBEQAwEAOh+hcbC1cfOzzQwNt2AFAgNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAETsPkrQ65jNFb26AAAAAElFTkSuQmCC";

  @override
  void initState() {
    super.initState();

    _korisnikProvider = context.read<KorisnikProvider>();

    _initialValue = {
      "slika": Authorization.slika,
      "email": Authorization.email,
    };
  }

  final commonDecoration = InputDecoration(
    border: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10.0),
      borderSide: BorderSide.none,
    ),
    focusedBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10.0),
      borderSide: const BorderSide(color: Colors.blue),
    ),
  );

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
        selectedIndex: 4,
        backButton: ProfileScreen(),
        header: "Uređivanje",
        headerDescription: "Ovdje možete da uredite vaš profil",
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
          initialValue: _initialValue,
          child: Column(
            children: [
              FormBuilderField(
                name: 'slika',
                builder: (field) {
                  return GestureDetector(
                    onTap: () => getImage(),
                    child: Stack(
                      children: [
                        Container(
                          height: 150,
                          width: 150,
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(100.0),
                          ),
                          child: ClipRRect(
                            borderRadius: BorderRadius.circular(100),
                            child: Image.memory(
                              _initialValue['slika'] == null
                                  ? base64Decode(_base64Placeholder)
                                  : base64Decode(_initialValue['slika']),
                              fit: BoxFit.cover,
                            ),
                          ),
                        ),
                        Positioned(
                          top: 0,
                          bottom: 0,
                          right: 0,
                          left: 0,
                          child: Container(
                            decoration: BoxDecoration(
                                color: Colors.black38,
                                borderRadius: BorderRadius.circular(100)),
                            child: Icon(
                              Icons.file_upload_outlined,
                              size: 50,
                              color: Colors.white,
                            ),
                          ),
                        )
                      ],
                    ),
                  );
                },
              ),
              SizedBox(
                height: 20,
              ),
              Row(
                children: [
                  Expanded(
                      child: FormBuilderTextField(
                    name: "email",
                    validator: FormBuilderValidators.compose([
                      FormBuilderValidators.required(
                        errorText: 'Ovo polje je obavezno.',
                      ),
                    ]),
                    initialValue: _initialValue['email'],
                    decoration: InputDecoration(
                      label: Text("E-mail"),
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
                    name: "lozinka",
                    autovalidateMode: AutovalidateMode.onUserInteraction,
                    obscureText: true,
                    validator: (value) {
                      if (value != null && value.isNotEmpty) {
                        return FormBuilderValidators.compose([
                          FormBuilderValidators.password(
                            errorText:
                                'Lozinka: 8-32 karaktera, 1 veliko, 1 malo slovo, broj i spec. znak.',
                          ),
                        ])(value);
                      }
                      return null;
                    },
                    decoration: InputDecoration(
                      label: Text("Nova lozinka"),
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
                    name: "lozinkaPotvrda",
                    obscureText: true,
                    validator: (value) {
                      if (value != null && value.isNotEmpty) {
                        if (value !=
                            _formKey.currentState?.fields['lozinka']?.value) {
                          return 'Lozinke se ne podudaraju';
                        }
                      }
                      return null;
                    },
                    decoration: InputDecoration(
                      label: Text("Potvrda lozinke"),
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
            ],
          )),
    );
  }

  void getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if (result != null && result.files.single.path != null) {
      _image = File(result.files.single.path!);
      _initialValue['slika'] = base64Encode(_image!.readAsBytesSync());
      _formKey.currentState
          ?.patchValue({"slika": base64Encode(_image!.readAsBytesSync())});
    }

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

      var result =
          await _korisnikProvider.update(Authorization.id ?? 0, request);

      if (_formKey.currentState?.value['lozinka'] != null) {
        Authorization.password = _formKey.currentState?.value['lozinka'];
      }

      await showSnackBar("Uspješno ste izmjenili Vaš profil.");

      Authorization.email = result.email;

      Authorization.slika = result.slika;

      Navigator.of(context).push(
        MaterialPageRoute(
          builder: (context) => const ProfileScreen(),
        ),
      );
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  Widget _save() {
    return Container(
      margin: EdgeInsets.only(top: 10, left: 20, right: 20),
      child: CustomButtonWidget(
          isFullWidth: true,
          padding: EdgeInsets.symmetric(vertical: 20),
          buttonText: "Sačuvaj",
          onPress: () async {
            await handleFormSubmit();
          } // Promenite zaobljenost ivica
          ),
    );
  }
}
