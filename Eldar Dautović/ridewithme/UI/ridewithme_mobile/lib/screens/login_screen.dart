import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:localstorage/localstorage.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';
import 'package:ridewithme_mobile/providers/korisnik_provider.dart';
import 'package:ridewithme_mobile/screens/home_screen.dart';
import 'package:ridewithme_mobile/screens/register_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/custom_input_widget.dart';

class LoginPage extends StatelessWidget {
  LoginPage({super.key});

  final LocalStorage storage = new LocalStorage("local_app");

  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late KorisnikProvider _korisnikProvider;

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    _korisnikProvider = context.read<KorisnikProvider>();
    return PopScope(
      canPop: false,
      child: Scaffold(
        body: Stack(
          children: [
            Positioned(
              top: 0,
              right: 0,
              child: SvgPicture.asset(
                "assets/images/logo.svg",
                width: 1000,
                height: 400,
              ),
            ),
            Positioned(
              bottom: 0,
              left: 0,
              child: SvgPicture.asset(
                "assets/images/left-border.svg",
                width: 800,
                height: 350,
              ),
            ),
            Center(
              child: Container(
                constraints: BoxConstraints(maxHeight: 650, maxWidth: 400),
                child: Padding(
                  padding: const EdgeInsets.all(15.0),
                  child: SingleChildScrollView(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Container(
                            constraints:
                                BoxConstraints(maxHeight: 200, maxWidth: 400),
                            child: Align(
                                alignment: Alignment.topLeft,
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      "ridewithme.",
                                      style: TextStyle(
                                          fontFamily: "Inter",
                                          fontSize: 50,
                                          fontWeight: FontWeight.w900),
                                    ),
                                    SizedBox(
                                      height: 30,
                                    ),
                                    Text(
                                      "Dobrodošli nazad!",
                                      textAlign: TextAlign.right,
                                      style: TextStyle(
                                          fontFamily: "Inter",
                                          fontSize: 30,
                                          fontWeight: FontWeight.w800,
                                          color: Color(0xFF072220)),
                                    ),
                                    Text(
                                      "Unesite korisničko ime i lozinku",
                                      textAlign: TextAlign.right,
                                      style: TextStyle(
                                          fontFamily: "Inter",
                                          fontSize: 16,
                                          color: Color(0xFF072220)),
                                    ),
                                  ],
                                ))),
                        SizedBox(height: 10),
                        Container(
                          child: Form(
                              key: _formKey,
                              child: Column(
                                mainAxisSize: MainAxisSize.min,
                                children: [
                                  CustomInputField(
                                    labelText: "Korisničko ime",
                                    controller: _usernameController,
                                    prefixIcon: Icons.verified_user_rounded,
                                    validator: (value) {
                                      if (value == null || value.isEmpty) {
                                        return 'Korisničko ime je obavezno';
                                      }
                                      return null;
                                    },
                                  ),
                                  SizedBox(height: 20),
                                  CustomInputField(
                                    labelText: "Lozinka",
                                    controller: _passwordController,
                                    prefixIcon: Icons.password_rounded,
                                    obscuredText: true,
                                    validator: (value) {
                                      if (value == null || value.isEmpty) {
                                        return 'Lozinka je obavezna.';
                                      }
                                      return null;
                                    },
                                  ),
                                  SizedBox(height: 30),
                                  CustomButtonWidget(
                                    isFullWidth: true,
                                    padding: EdgeInsets.symmetric(vertical: 20),
                                    buttonText: "Prijavi se",
                                    onPress: () async {
                                      if (_formKey.currentState!.validate()) {
                                        var username = _usernameController.text;
                                        var password = _passwordController.text;

                                        Authorization.username = username;
                                        Authorization.password = password;

                                        try {
                                          Korisnik result =
                                              await _korisnikProvider.login(
                                                  username, password);

                                          Authorization.fullName =
                                              "${result.ime} ${result.prezime}";

                                          Authorization.id = result.id;

                                          Authorization.email = result.email;

                                          Authorization.slika = result.slika;

                                          Navigator.of(context).pushReplacement(
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
                                              content:
                                                  Text("Uspješna prijava."),
                                            ),
                                          );
                                        } on Exception catch (e) {
                                          ScaffoldMessenger.of(context)
                                              .showSnackBar(
                                            SnackBar(
                                              behavior:
                                                  SnackBarBehavior.floating,
                                              content: Text(
                                                  "Neispravni kredencijali."),
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
                                    },
                                  ),
                                  TextButton(
                                      onPressed: () {
                                        Navigator.of(context).pushReplacement(
                                          MaterialPageRoute(
                                            builder: (context) =>
                                                const RegisterScreen(),
                                          ),
                                        );
                                      },
                                      child: Text(
                                        "Nemate nalog?",
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
