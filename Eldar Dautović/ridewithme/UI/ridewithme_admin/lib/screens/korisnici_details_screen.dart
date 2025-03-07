import 'dart:convert';
import 'dart:io';

import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/models/search_result.dart';
import 'package:ridewithme_admin/models/uloga.dart';
import 'package:ridewithme_admin/providers/korisnik_provider.dart';
import 'package:ridewithme_admin/providers/uloga_provider.dart';
import 'package:ridewithme_admin/screens/korisnici_screen.dart';
import 'package:ridewithme_admin/utils/input_utils.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class KorisniciDetailsScreen extends StatefulWidget {
  Korisnik? korisnik;
  KorisniciDetailsScreen({super.key, this.korisnik});

  @override
  State<KorisniciDetailsScreen> createState() => _KorisniciDetailsScreenState();
}

class _KorisniciDetailsScreenState extends State<KorisniciDetailsScreen> {
  late KorisnikProvider _korisnikProvider;
  late UlogaProvider _ulogaProvider;

  SearchResult<Uloga>? ulogaResults;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  File? _image;
  final _base64Placeholder =
      "iVBORw0KGgoAAAANSUhEUgAAAbUAAADnCAYAAACZm8iVAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAANhSURBVHhe7dVBEQAwEAOh+hcbC1cfOzzQwNt2AFAgNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAGRIDYAMqQGQITUAMqQGQIbUAMiQGgAZUgMgQ2oAZEgNgAypAZAhNQAypAZAhtQAyJAaABlSAyBDagBkSA2ADKkBkCE1ADKkBkCG1ADIkBoAGVIDIENqAETsPkrQ65jNFb26AAAAAElFTkSuQmCC";

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _korisnikProvider = context.read<KorisnikProvider>();
    _ulogaProvider = context.read<UlogaProvider>();

    _initialValue = {
      'ime': widget.korisnik?.ime,
      'prezime': widget.korisnik?.prezime,
      'korisnickoIme': widget.korisnik?.korisnickoIme,
      'email': widget.korisnik?.email,
      'lozinka': null,
      'lozinkaPotvrda': null,
      "slika": widget.korisnik?.slika != null
          ? widget.korisnik?.slika.toString()
          : _base64Placeholder,
      "ulogaId": widget.korisnik?.korisniciUloge?[0].uloga?.naziv
    };

    initUloges();
  }

  Future initUloges() async {
    ulogaResults = await _ulogaProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      backButton: KorisniciScreen(),
      selectedIndex: 2,
      headerTitle: widget.korisnik != null
          ? "Uređivanje korisnika"
          : "Kreiranje korisnika",
      headerDescription: widget.korisnik != null
          ? "Ovdje možete urediti korisnika."
          : "Ovdje možete kreirati korisnika.",
      child: Flexible(
          child: SingleChildScrollView(
              child: Column(
        children: [isLoading ? Container() : _buildForm(), _save()],
      ))),
    );
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

  Widget _buildForm() {
    return FormBuilder(
        key: _formKey,
        initialValue: _initialValue,
        child: Column(
          children: [
            Row(
              spacing: 20,
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  name: "ime",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['ime'],
                  decoration: InputDecoration(
                    label: Text("Ime"),
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
                Expanded(
                    child: FormBuilderTextField(
                  name: "prezime",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['prezime'],
                  decoration: InputDecoration(
                    label: Text("Prezime"),
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
              spacing: 20,
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  name: "korisnickoIme",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                  ]),
                  initialValue: _initialValue['korisnickoIme'],
                  decoration: InputDecoration(
                    label: Text("Korisničko ime"),
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
                Expanded(
                    child: FormBuilderTextField(
                  name: "email",
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                      errorText: 'Ovo polje je obavezno.',
                    ),
                    FormBuilderValidators.email(
                      errorText: 'Ovo polje mora biti validna e-mail adresa.',
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
              spacing: 20,
              children: [
                Expanded(
                    child: FormBuilderTextField(
                  name: "lozinka",
                  obscureText: true,
                  initialValue: _initialValue['lozinka'],
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  validator: (value) {
                    if (value != null && value.isNotEmpty ||
                        widget.korisnik == null) {
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
                    label: Text("Lozinka"),
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
                Expanded(
                    child: FormBuilderTextField(
                  name: "lozinkaPotvrda",
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  obscureText: true,
                  initialValue: _initialValue['lozinkaPotvrda'],
                  validator: (value) {
                    if (value != null && value.isNotEmpty ||
                        widget.korisnik == null) {
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
                ))
              ],
            ),
            SizedBox(
              height: 10,
            ),
            Row(
              spacing: 20,
              children: [
                Expanded(
                    child: buildDropdown(
                  name: 'ulogaId',
                  labelText: "Uloga",
                  hintText: "Uloga",
                  prefixIcon: Icon(Icons.admin_panel_settings_rounded),
                  initialValue:
                      widget.korisnik?.korisniciUloge?[0].uloga?.id.toString(),
                  items: [
                        DropdownMenuItem(
                          value: null,
                          child: Text("Odaberi"),
                        ),
                        ...ulogaResults!.result
                            .map((e) => DropdownMenuItem(
                                  value: e.id.toString(),
                                  child: Text(
                                    e.naziv ?? "",
                                  ),
                                ))
                            .toList()
                      ] ??
                      [],
                )),
              ],
            ),
            SizedBox(
              height: 10,
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Align(
                  alignment: Alignment.centerLeft,
                  child: Container(
                    alignment: Alignment.centerLeft,
                    constraints: BoxConstraints(maxWidth: 450),
                    decoration: BoxDecoration(
                      color: Color(0xFFF3FCFC),
                      border: Border.all(color: Color(0xFFE3E3E3)),
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Row(
                        children: [
                          Container(
                            height: 150,
                            width: 150,
                            decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(10.0),
                            ),
                            child: ClipRRect(
                              borderRadius: BorderRadius.circular(10),
                              child: Image.memory(
                                _initialValue['slika'] == null
                                    ? base64Decode(_base64Placeholder)
                                    : base64Decode(_initialValue['slika']),
                                fit: BoxFit.cover,
                              ),
                            ),
                          ),
                          Expanded(
                            child: FormBuilderField(
                              name: "slika",
                              builder: (field) {
                                return InputDecorator(
                                  decoration: commonDecoration.copyWith(),
                                  child: ListTile(
                                    leading: const Icon(Icons.image),
                                    title: const Text("Odaberite sliku"),
                                    trailing: const Icon(Icons.file_upload),
                                    onTap: getImage,
                                  ),
                                );
                              },
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                ),
              ],
            ),
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

      if (widget.korisnik == null) {
        await _korisnikProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novog korisnika.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const KorisniciScreen(),
          ),
        );
      } else {
        if (request['slika'] == _base64Placeholder) {
          request['slika'] = null;
        }

        await _korisnikProvider.update(widget.korisnik!.id!, request);
        await showSnackBar("Uspješno ste izmjenili korisnika.");
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const KorisniciScreen(),
          ),
        );
      }
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
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
