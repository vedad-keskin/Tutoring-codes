import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/providers/chat_provider.dart';
import 'package:ridewithme_mobile/providers/dogadjaji_provider.dart';
import 'package:ridewithme_mobile/providers/faq_provider.dart';
import 'package:ridewithme_mobile/providers/gradovi_provider.dart';
import 'package:ridewithme_mobile/providers/korisnik_provider.dart';
import 'package:ridewithme_mobile/providers/kuponi_provider.dart';
import 'package:ridewithme_mobile/providers/obavjestenja_provider.dart';
import 'package:ridewithme_mobile/providers/recenzije_provider.dart';
import 'package:ridewithme_mobile/providers/reklame_provider.dart';
import 'package:ridewithme_mobile/providers/voznje_provider.dart';
import 'package:ridewithme_mobile/providers/vrste_zalbe_provider.dart';
import 'package:ridewithme_mobile/providers/zalbe_provider.dart';
import 'package:ridewithme_mobile/screens/onboarding_screen.dart';

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await dotenv.load(fileName: "assets/.env");
  Stripe.publishableKey = dotenv.env["STRIPE__PUBKEY"]!;
  Stripe.merchantIdentifier = 'merchant.flutter.stripe.test';
  Stripe.urlScheme = 'flutterstripe';
  await Stripe.instance.applySettings();

  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => KorisnikProvider()),
      ChangeNotifierProvider(create: (_) => VoznjeProvider()),
      ChangeNotifierProvider(create: (_) => ObavjestenjaProvider()),
      ChangeNotifierProvider(create: (_) => GradoviProvider()),
      ChangeNotifierProvider(create: (_) => KuponiProvider()),
      ChangeNotifierProvider(create: (_) => RecenzijeProvider()),
      ChangeNotifierProvider(create: (_) => FaqProvider()),
      ChangeNotifierProvider(create: (_) => ZalbeProvider()),
      ChangeNotifierProvider(create: (_) => VrsteZalbeProvider()),
      ChangeNotifierProvider(create: (_) => DogadjajiProvider()),
      ChangeNotifierProvider(create: (_) => ReklameProvider()),
      ChangeNotifierProvider(create: (_) => ChatProvider()),
    ],
    child: const RideWithMeMobile(),
  ));
}

class RideWithMeMobile extends StatelessWidget {
  const RideWithMeMobile({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ridewithme',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Color(0xFF39D5C3)),
        useMaterial3: true,
      ),
      home: OnboardingScreen(),
    );
  }
}
