import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/providers/dogadjaji_provider.dart';
import 'package:ridewithme_admin/providers/faq_provider.dart';
import 'package:ridewithme_admin/providers/gradovi_provider.dart';
import 'package:ridewithme_admin/providers/korisnik_provider.dart';
import 'package:ridewithme_admin/providers/kuponi_provider.dart';
import 'package:ridewithme_admin/providers/obavjestenja_provider.dart';
import 'package:ridewithme_admin/providers/recenzije_provider.dart';
import 'package:ridewithme_admin/providers/reklame_provider.dart';
import 'package:ridewithme_admin/providers/statistika_provider.dart';
import 'package:ridewithme_admin/providers/uloga_provider.dart';
import 'package:ridewithme_admin/providers/voznje_provider.dart';
import 'package:ridewithme_admin/providers/vrsta_zalbe_provider.dart';
import 'package:ridewithme_admin/providers/zalbe_provider.dart';
import 'package:ridewithme_admin/screens/home_screen.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/custom_input_widget.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => VoznjeProvider()),
      ChangeNotifierProvider(create: (_) => GradoviProvider()),
      ChangeNotifierProvider(create: (_) => StatistikaProvider()),
      ChangeNotifierProvider(create: (_) => KorisnikProvider()),
      ChangeNotifierProvider(create: (_) => ObavjestenjaProvider()),
      ChangeNotifierProvider(create: (_) => KuponiProvider()),
      ChangeNotifierProvider(create: (_) => ZalbaProvider()),
      ChangeNotifierProvider(create: (_) => VrstaZalbeProvider()),
      ChangeNotifierProvider(create: (_) => ReklameProvider()),
      ChangeNotifierProvider(create: (_) => DogadjajiProvider()),
      ChangeNotifierProvider(create: (_) => FaqProvider()),
      ChangeNotifierProvider(create: (_) => RecenzijeProvider()),
      ChangeNotifierProvider(create: (_) => UlogaProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ridewithme',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Color(0xFF39D5C3)),
        useMaterial3: true,
      ),
      home: LoginPage(),
    );
  }
}

class LoginPage extends StatelessWidget {
  LoginPage({super.key});

  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late KorisnikProvider _korisnikProvider;

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    _korisnikProvider = context.read<KorisnikProvider>();
    return Scaffold(
      body: Stack(
        children: [
          Positioned(
            top: 0,
            right: 0,
            child: SvgPicture.asset(
              "assets/images/logo.svg",
              width: 1000,
              height: 650,
            ),
          ),
          Positioned(
            bottom: 0,
            left: 0,
            child: SvgPicture.asset(
              "assets/images/left-border.svg",
              width: 1000,
              height: 700,
            ),
          ),
          Center(
            child: Container(
              constraints: BoxConstraints(maxHeight: 500, maxWidth: 400),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                      constraints:
                          BoxConstraints(maxHeight: 180, maxWidth: 400),
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
                                    fontWeight: FontWeight.w700,
                                    color: Color(0xFF072220)),
                              ),
                              Text(
                                "Unesite korisničko ime i lozinku",
                                textAlign: TextAlign.right,
                                style: TextStyle(
                                    fontFamily: "Inter",
                                    fontSize: 15,
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
                              buttonText: "Prijavi se",
                              onPress: () async {
                                if (_formKey.currentState!.validate()) {
                                  var username = _usernameController.text;
                                  var password = _passwordController.text;

                                  Authorization.username = username;
                                  Authorization.password = password;

                                  try {
                                    Korisnik result = await _korisnikProvider
                                        .login(username, password);

                                    bool? hasAdminRole = result.korisniciUloge
                                        ?.any((korisnikUloga) =>
                                            korisnikUloga.uloga?.naziv ==
                                            "Administrator");

                                    if (hasAdminRole != true) {
                                      ScaffoldMessenger.of(context)
                                          .showSnackBar(
                                        SnackBar(
                                          behavior: SnackBarBehavior.floating,
                                          content: Text(
                                              "Nemate administratorska ovlaštenja."),
                                          action: SnackBarAction(
                                            label: "U redu",
                                            onPressed: () =>
                                                ScaffoldMessenger.of(context)
                                                    .removeCurrentSnackBar(),
                                          ),
                                        ),
                                      );

                                      return;
                                    }

                                    Authorization.fullName =
                                        "${result.ime} ${result.prezime}";

                                    Authorization.id = result.id;

                                    Navigator.of(context).push(
                                      MaterialPageRoute(
                                        builder: (context) =>
                                            const HomeScreen(),
                                      ),
                                    );

                                    ScaffoldMessenger.of(context).showSnackBar(
                                      SnackBar(
                                        behavior: SnackBarBehavior.floating,
                                        content: Text("Uspješna prijava."),
                                        action: SnackBarAction(
                                            label: "U redu",
                                            onPressed: () =>
                                                ScaffoldMessenger.of(context)
                                                  ..removeCurrentSnackBar()),
                                      ),
                                    );
                                  } on Exception catch (e) {
                                    ScaffoldMessenger.of(context).showSnackBar(
                                      SnackBar(
                                        behavior: SnackBarBehavior.floating,
                                        content:
                                            Text("Neispravni kredencijali."),
                                        action: SnackBarAction(
                                            label: "U redu",
                                            onPressed: () =>
                                                ScaffoldMessenger.of(context)
                                                  ..removeCurrentSnackBar()),
                                      ),
                                    );
                                  }
                                }
                              },
                            ),
                          ],
                        )),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
