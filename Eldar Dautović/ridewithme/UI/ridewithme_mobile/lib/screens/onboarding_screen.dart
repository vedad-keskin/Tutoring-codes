import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:localstorage/localstorage.dart';
import 'package:ridewithme_mobile/screens/login_screen.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({super.key});

  @override
  State<OnboardingScreen> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  final LocalStorage storage = new LocalStorage("local_app");

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _initOnboarding();
  }

  Future _initOnboarding() async {
    var onBoardedValue = await storage.getItem("onBoarded");

    if (onBoardedValue != null && int.tryParse(onBoardedValue) == 1) {
      Navigator.of(context).pushReplacement(
        MaterialPageRoute(
          builder: (context) => LoginPage(),
        ),
      );
    }

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Positioned(
            top: 0,
            right: 0,
            child: SvgPicture.asset(
              "assets/images/logo.svg",
              width: 500,
              height: 400,
            ),
          ),
          Positioned(
            top: 190,
            right: 100,
            child: Container(
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(100),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withValues(alpha: 0.25),
                      spreadRadius: 2,
                      blurRadius: 4,
                      offset: Offset(0, 5), // changes position of shadow
                    ),
                  ]),
              child: ClipRRect(
                borderRadius: BorderRadius.circular(100),
                child: Image.asset(
                  "assets/images/people-happy.png",
                  width: 140,
                  height: 140,
                  fit: BoxFit.cover,
                ),
              ),
            ),
          ),
          Positioned(
            top: 35,
            right: 30,
            child: Container(
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(100),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withValues(alpha: 0.25),
                      spreadRadius: 2,
                      blurRadius: 4,
                      offset: Offset(0, 5), // changes position of shadow
                    ),
                  ]),
              child: ClipRRect(
                borderRadius: BorderRadius.circular(100),
                child: Image.asset(
                  "assets/images/people-happy2.png",
                  width: 150,
                  height: 150,
                  fit: BoxFit.cover,
                ),
              ),
            ),
          ),
          Positioned(
              top: 80,
              left: 20,
              child: Text(
                "ridewithme",
                style: TextStyle(
                    fontFamily: "Inter",
                    fontSize: 32,
                    fontWeight: FontWeight.bold,
                    color: Color(0xFF072220)),
              )),
          Positioned(
              left: 30,
              bottom: 20,
              child: Container(
                constraints: BoxConstraints(maxWidth: 350),
                child: Column(
                  spacing: 10,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    SizedBox(
                      width: 350,
                      child: Text(
                        "Hajde da počnemo.",
                        softWrap: true,
                        style: TextStyle(
                            fontFamily: "Inter",
                            fontSize: 50,
                            fontWeight: FontWeight.w900,
                            color: Color(0xFF072220)),
                      ),
                    ),
                    Text(
                      "Spajajmo ljude i destinacije!",
                      style: TextStyle(
                          fontFamily: "Inter",
                          fontSize: 24,
                          fontWeight: FontWeight.normal,
                          color: Color(0xFF072220)),
                    ),
                    Container(
                      constraints: BoxConstraints(maxWidth: 350),
                      child: CustomButtonWidget(
                          isFullWidth: true,
                          padding: EdgeInsets.symmetric(vertical: 20),
                          buttonText: "Nastavi",
                          onPress: () async {
                            await storage.setItem("onBoarded", '1');
                            Navigator.of(context).pushReplacement(
                              MaterialPageRoute(
                                builder: (context) => LoginPage(),
                              ),
                            );
                          }),
                    )
                  ],
                ),
              )),
        ],
      ),
    );
  }
}
