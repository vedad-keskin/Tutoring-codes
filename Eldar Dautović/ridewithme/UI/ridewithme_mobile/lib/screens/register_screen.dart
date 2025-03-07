import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_svg/svg.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';
import 'package:ridewithme_mobile/providers/korisnik_provider.dart';
import 'package:ridewithme_mobile/screens/home_screen.dart';
import 'package:ridewithme_mobile/screens/login_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({super.key});

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  final _formKey = GlobalKey<FormBuilderState>();

  late KorisnikProvider _korisnikProvider;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _korisnikProvider = context.read<KorisnikProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return PopScope(
      canPop: false,
      child: Scaffold(
        body: Stack(
          children: [
            Positioned(
              top: 0,
              right: 0,
              left: 0,
              bottom: 0,
              child: SvgPicture.asset(
                "assets/images/middle.svg",
                width: 1500,
                height: 1000,
              ),
            ),
            Center(
              child: Container(
                constraints: BoxConstraints(maxHeight: 800, maxWidth: 400),
                child: Padding(
                  padding: const EdgeInsets.all(15.0),
                  child: SingleChildScrollView(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Container(
                            constraints:
                                BoxConstraints(maxHeight: 50, maxWidth: 400),
                            child: Align(
                                alignment: Alignment.topLeft,
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      "Kreirajte Vaš nalog",
                                      textAlign: TextAlign.right,
                                      style: TextStyle(
                                          fontFamily: "Inter",
                                          fontSize: 30,
                                          fontWeight: FontWeight.w800,
                                          color: Color(0xFF072220)),
                                    ),
                                  ],
                                ))),
                        Container(
                          child: FormBuilder(
                              key: _formKey,
                              child: Column(
                                mainAxisSize: MainAxisSize.min,
                                children: [
                                  FormBuilderTextField(
                                    name: "email",
                                    validator: FormBuilderValidators.compose([
                                      FormBuilderValidators.required(
                                        errorText: 'Ovo polje je obavezno.',
                                      ),
                                      FormBuilderValidators.email(
                                          errorText:
                                              'Morate unijeti validnu e-mail adresu.')
                                    ]),
                                    decoration: InputDecoration(
                                      label: Text("E-mail"),
                                      labelStyle: TextStyle(
                                          fontSize: 14, fontFamily: "Inter"),
                                      filled: true,
                                      fillColor: Color(0xFFF3FCFC),
                                      border: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                      enabledBorder: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                    ),
                                  ),
                                  SizedBox(height: 20),
                                  FormBuilderTextField(
                                    name: "korisnickoIme",
                                    validator: FormBuilderValidators.compose([
                                      FormBuilderValidators.required(
                                        errorText: 'Ovo polje je obavezno.',
                                      ),
                                      FormBuilderValidators.username(
                                          errorText:
                                              'Koristite slova (a-z), brojeve, tačke i donje crte.',
                                          allowDots: true,
                                          allowNumbers: true,
                                          allowUnderscore: true),
                                    ]),
                                    decoration: InputDecoration(
                                      label: Text("Korisničko ime"),
                                      labelStyle: TextStyle(
                                          fontSize: 14, fontFamily: "Inter"),
                                      filled: true,
                                      fillColor: Color(0xFFF3FCFC),
                                      border: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                      enabledBorder: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                    ),
                                  ),
                                  SizedBox(height: 20),
                                  FormBuilderTextField(
                                    name: "ime",
                                    validator: FormBuilderValidators.compose([
                                      FormBuilderValidators.required(
                                        errorText: 'Ovo polje je obavezno.',
                                      ),
                                      FormBuilderValidators.firstName(
                                          errorText:
                                              'Ovo polje mora biti validno ime.'),
                                    ]),
                                    decoration: InputDecoration(
                                      label: Text("Ime"),
                                      labelStyle: TextStyle(
                                          fontSize: 14, fontFamily: "Inter"),
                                      filled: true,
                                      fillColor: Color(0xFFF3FCFC),
                                      border: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                      enabledBorder: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                    ),
                                  ),
                                  SizedBox(height: 20),
                                  FormBuilderTextField(
                                    name: "prezime",
                                    validator: FormBuilderValidators.compose([
                                      FormBuilderValidators.required(
                                        errorText: 'Ovo polje je obavezno.',
                                      ),
                                      FormBuilderValidators.lastName(
                                          errorText:
                                              'Ovo polje mora biti validno prezime.'),
                                    ]),
                                    decoration: InputDecoration(
                                      label: Text("Prezime"),
                                      labelStyle: TextStyle(
                                          fontSize: 14, fontFamily: "Inter"),
                                      filled: true,
                                      fillColor: Color(0xFFF3FCFC),
                                      border: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                      enabledBorder: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                    ),
                                  ),
                                  SizedBox(height: 20),
                                  FormBuilderTextField(
                                    name: "lozinka",
                                    obscureText: true,
                                    autovalidateMode:
                                        AutovalidateMode.onUserInteraction,
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
                                        label: Text("Lozinka"),
                                        labelStyle: TextStyle(
                                            fontSize: 14, fontFamily: "Inter"),
                                        filled: true,
                                        fillColor: Color(0xFFF3FCFC),
                                        border: OutlineInputBorder(
                                          borderSide: BorderSide(
                                              color: Color(0xFFE3E3E3)),
                                        ),
                                        enabledBorder: OutlineInputBorder(
                                          borderSide: BorderSide(
                                              color: Color(0xFFE3E3E3)),
                                        ),
                                        errorMaxLines: 2),
                                  ),
                                  SizedBox(height: 20),
                                  FormBuilderTextField(
                                    name: "lozinkaPotvrda",
                                    obscureText: true,
                                    autovalidateMode:
                                        AutovalidateMode.onUserInteraction,
                                    validator: (value) {
                                      if (value != null && value.isNotEmpty) {
                                        if (value !=
                                            _formKey.currentState
                                                ?.fields['lozinka']?.value) {
                                          return 'Lozinke se ne podudaraju';
                                        }
                                      }
                                      return null;
                                    },
                                    decoration: InputDecoration(
                                      label: Text("Potvrda lozinke"),
                                      labelStyle: TextStyle(
                                          fontSize: 14, fontFamily: "Inter"),
                                      filled: true,
                                      fillColor: Color(0xFFF3FCFC),
                                      border: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                      enabledBorder: OutlineInputBorder(
                                        borderSide: BorderSide(
                                            color: Color(0xFFE3E3E3)),
                                      ),
                                      errorMaxLines:
                                          2, // Omogućava prelazak u novi red
                                      // Smanjuje padding i povećava prostor za error tekst
                                    ),
                                  ),
                                  SizedBox(height: 30),
                                  CustomButtonWidget(
                                      isFullWidth: true,
                                      padding:
                                          EdgeInsets.symmetric(vertical: 20),
                                      buttonText: "Registruj se",
                                      onPress: () async {
                                        if (_formKey.currentState!
                                            .saveAndValidate()) {
                                          try {
                                            var request = Map.from(
                                                _formKey.currentState!.value);

                                            Korisnik result =
                                                await _korisnikProvider
                                                    .insert(request);

                                            Authorization.username =
                                                request['korisnickoIme'];
                                            Authorization.password =
                                                request['lozinka'];

                                            Authorization.email =
                                                request['email'];

                                            Authorization.fullName =
                                                "${result.ime} ${result.prezime}";

                                            Authorization.id = result.id;

                                            Navigator.of(context)
                                                .pushReplacement(
                                              MaterialPageRoute(
                                                builder: (context) =>
                                                    const HomeScreen(),
                                              ),
                                            );

                                            ScaffoldMessenger.of(context)
                                                .showSnackBar(
                                              SnackBar(
                                                behavior:
                                                    SnackBarBehavior.floating,
                                                content: Text(
                                                    "Uspješna registracija."),
                                              ),
                                            );
                                          } on Exception catch (e) {
                                            ScaffoldMessenger.of(context)
                                                .showSnackBar(
                                              SnackBar(
                                                behavior:
                                                    SnackBarBehavior.floating,
                                                content: Text(e.toString()),
                                                action: SnackBarAction(
                                                    label: "U redu",
                                                    onPressed: () =>
                                                        ScaffoldMessenger.of(
                                                            context)
                                                          ..removeCurrentSnackBar()),
                                              ),
                                            );
                                          }
                                        }
                                      }),
                                  SizedBox(
                                    height: 10,
                                  ),
                                  TextButton(
                                      onPressed: () {
                                        Navigator.of(context).pushReplacement(
                                          MaterialPageRoute(
                                            builder: (context) => LoginPage(),
                                          ),
                                        );
                                      },
                                      child: Text(
                                        "Imate nalog?",
                                        style: TextStyle(
                                            fontFamily: "Inter",
                                            color: Color(0xFF072220),
                                            fontSize: 14),
                                      ))
                                ],
                              )),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
