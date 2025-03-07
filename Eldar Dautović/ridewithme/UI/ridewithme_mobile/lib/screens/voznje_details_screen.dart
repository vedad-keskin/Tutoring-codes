import 'dart:convert';

import 'package:carousel_slider/carousel_slider.dart';
import 'package:custom_rating_bar/custom_rating_bar.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/kupon_check.dart';
import 'package:ridewithme_mobile/models/recenzija.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/korisnik_provider.dart';
import 'package:ridewithme_mobile/providers/kuponi_provider.dart';
import 'package:ridewithme_mobile/providers/recenzije_provider.dart';
import 'package:ridewithme_mobile/providers/voznje_provider.dart';
import 'package:ridewithme_mobile/screens/payment_success.dart';
import 'package:ridewithme_mobile/screens/rate_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_create_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_screen.dart';
import 'package:ridewithme_mobile/screens/your_rides_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/utils/enums_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/custom_input_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';
import 'package:http/http.dart' as http;
import 'package:ridewithme_mobile/widgets/ride_widget.dart';

class VoznjeDetailsScreen extends StatefulWidget {
  Voznja voznja;
  VoznjeDetailsScreen({super.key, required this.voznja});

  @override
  State<VoznjeDetailsScreen> createState() => _VoznjeDetailsScreenState();
}

class _VoznjeDetailsScreenState extends State<VoznjeDetailsScreen> {
  late KorisnikProvider _korisnikProvider;
  late VoznjeProvider _voznjeProvider;
  late KuponiProvider _kuponiProvider;
  late RecenzijeProvider _recenzijeProvider;

  TextEditingController _kuponController = TextEditingController();

  bool recommendationsLoading = true;
  bool isLoading = true;

  bool isTrusted = false;
  bool isDriver = false;
  bool isClient = false;

  SearchResult<Recenzija>? recenzijeResult;
  List<Voznja>? recommendedRides;

  int brojVoznji = 0;
  int brojVoznjiKlijenta = 0;
  List<String>? allowedActions;

  IspravanKupon? isCouponCorrect;

  double totalPrice = 0.0;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _korisnikProvider = context.read<KorisnikProvider>();
    _kuponiProvider = context.read<KuponiProvider>();
    _voznjeProvider = context.read<VoznjeProvider>();
    _recenzijeProvider = context.read<RecenzijeProvider>();

    totalPrice = (widget.voznja.cijena ?? 0) + 2.0;
    isDriver = Authorization.id == widget.voznja.vozac?.id;
    isClient = Authorization.id == widget.voznja.klijent?.id;

    initTrusted();

    initRecommendations();
  }

  Future initRecommendations() async {
    recommendedRides = await _voznjeProvider.recommend(widget.voznja.id ?? 0);

    setState(() {
      recommendationsLoading = false;
    });
  }

  Future initTrusted() async {
    var result = await _korisnikProvider.trusted(
        widget.voznja.vozac?.id ?? 0, Authorization.id ?? 0);

    recenzijeResult =
        await _recenzijeProvider.get(filter: {"VoznjaId": widget.voznja.id});

    if (result.brojObavljenihVoznjiVozaca > 0) {
      isTrusted = true;
      brojVoznji = result.brojObavljenihVoznjiVozaca;
    }

    brojVoznjiKlijenta = result.brojObavljenihVoznjiKlijenta;

    if (result.brojObavljenihVoznjiKlijenta >= 10) {
      totalPrice = totalPrice - (widget.voznja.cijena! * 0.1);
    }

    if ((isDriver == true && widget.voznja.stateMachine != 'completed') ||
        (isClient == true &&
            widget.voznja.stateMachine == 'completed' &&
            recenzijeResult?.result.isEmpty == true)) {
      allowedActions =
          await _voznjeProvider.allowedActions(widget.voznja.id ?? 0);
    }

    setState(() {
      isLoading = false;
    });
  }

  void executeAction(String name) async {
    try {
      switch (name) {
        case "Hide":
          {
            await _voznjeProvider.hide(widget.voznja.id ?? 0);

            showSnackBar("Uspješno ste sakrili vožnju.");
            Navigator.of(context).pushReplacement(
              CupertinoPageRoute(
                builder: (context) => YourRidesScreen(),
              ),
            );
            break;
          }
        case "Edit":
          {
            await _voznjeProvider.edit(widget.voznja.id ?? 0);

            showSnackBar("Uspješno ste omogućili uređivanje vožnji.");
            Navigator.of(context).pushReplacement(
              CupertinoPageRoute(
                builder: (context) => YourRidesScreen(),
              ),
            );
            break;
          }
        case "Activate":
          {
            await _voznjeProvider.activate(widget.voznja.id ?? 0);

            showSnackBar("Uspješno ste aktivirali vožnju.");
            Navigator.of(context).pushReplacement(
              CupertinoPageRoute(
                builder: (context) => YourRidesScreen(),
              ),
            );
            break;
          }
        case "Start":
          {
            await _voznjeProvider.start(widget.voznja.id ?? 0, {});

            showSnackBar("Uspješno ste započeli vožnju.");
            Navigator.of(context).pushReplacement(
              CupertinoPageRoute(
                builder: (context) => YourRidesScreen(),
              ),
            );
            break;
          }
        case "Complete":
          {
            await _voznjeProvider.complete(widget.voznja.id ?? 0, {});

            showSnackBar("Uspješno ste završili vožnju.");
            Navigator.of(context).pushReplacement(
              CupertinoPageRoute(
                builder: (context) => YourRidesScreen(),
              ),
            );
            break;
          }
        case "Rate":
          {
            Navigator.of(context).push(
              CupertinoPageRoute(
                builder: (context) => RateScreen(
                  voznja: widget.voznja,
                ),
              ),
            );
            break;
          }
        case "Update":
          {
            Navigator.of(context).push(
              CupertinoPageRoute(
                builder: (context) => VoznjeCreateScreen(
                  voznja: widget.voznja,
                ),
              ),
            );
          }
        default:
      }

      setState(() {
        isLoading = true;
      });
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  Future<void> showSnackBar(String message) async {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        behavior: SnackBarBehavior.floating,
        content: Text(message),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 1,
      backButton: VoznjeScreen(),
      child: Flexible(
        child: SingleChildScrollView(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              if (isDriver ||
                  (isClient == true &&
                      widget.voznja.stateMachine == 'completed')) ...[
                _buildAllowedActions()
              ],
              _buildHeader(),
              _buildInfo(),
              if (isLoading) LoadingSpinnerWidget(height: 50),
              if (!isDriver && !isClient && !isLoading) ...[
                _buildTrusted(),
                _buildCouponCheck(),
                _buildPrices(),
                _pay(),
              ],
              if (!isClient && !isDriver && !isLoading) ...[
                _buildRecommendedRides()
              ]
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildRecommendedRides() {
    if (recommendedRides != null && recommendedRides!.isEmpty) {
      return Container();
    }

    return Container(
      margin: EdgeInsets.symmetric(vertical: 20),
      child: Column(
        spacing: 10,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.only(bottom: 10.0, top: 10),
            child: Text(
              "Vožnje koje bi vas mogle zanimati:",
              style: TextStyle(
                  fontFamily: "Inter",
                  color: Colors.black,
                  fontSize: 15,
                  fontWeight: FontWeight.w500),
            ),
          ),
          recommendationsLoading
              ? LoadingSpinnerWidget(
                  height: 160,
                )
              : CarouselSlider(
                  options: CarouselOptions(
                    height: 160,
                    enableInfiniteScroll: true,
                    autoPlay: false,
                    viewportFraction: 0.55,
                    enlargeStrategy: CenterPageEnlargeStrategy.scale,
                  ),
                  items: recommendedRides?.map((voznja) {
                        return RideWidget(
                          voznja: voznja,
                          boxColor: Color(0xFF7463DE),
                        );
                      }).toList() ??
                      [],
                ),
        ],
      ),
    );
  }

  Widget _buildAllowedActions() {
    return Column(
      children: [
        Row(
          spacing: 10,
          mainAxisAlignment: MainAxisAlignment.end,
          children: (allowedActions ?? [])
              .where((e) =>
                  VoznjaActions.fromString(e)?.naziv.isNotEmpty ??
                  false) // Filtriranje praznih
              .map((e) {
            final action = VoznjaActions.fromString(e);
            return CustomButtonWidget(
              fontSize: 12,
              padding: EdgeInsets.symmetric(horizontal: 30, vertical: 10),
              buttonText: action!.naziv,
              onPress: () => executeAction(e),
              buttonColor: action.boja,
            );
          }).toList(),
        ),
        SizedBox(
          height: 20,
        )
      ],
    );
  }

  Widget _buildHeader() {
    return Container(
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
                      widget.voznja.gradOd?.naziv ?? '',
                      style: _buildTextStyle(),
                    ),
                    Text(
                      "Do",
                      style: _buildTextStyle(),
                    ),
                    Text(widget.voznja.gradDo?.naziv ?? '',
                        style: _buildTextStyle())
                  ],
                )
              ],
            ),
            Row(
              children: [
                Text("Vozač: ",
                    style: TextStyle(
                        fontFamily: "Inter",
                        fontSize: 12,
                        color: Colors.black,
                        fontWeight: FontWeight.bold)),
                SizedBox(
                  width: 5,
                ),
                Container(
                    width: 25,
                    height: 25,
                    decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(100)),
                    child: widget.voznja.vozac?.slika != null
                        ? ClipRRect(
                            borderRadius: BorderRadius.circular(100),
                            child: Image.memory(
                              base64Decode(widget.voznja.vozac!.slika ?? ''),
                              fit: BoxFit.cover,
                            ),
                          )
                        : Icon(
                            Icons.account_circle,
                            size: 25,
                            color: Colors.blueGrey,
                          )),
                SizedBox(
                  width: 5,
                ),
                Text(
                  "${widget.voznja.vozac?.ime ?? ''} ${widget.voznja.vozac?.prezime ?? ''}",
                  overflow: TextOverflow.ellipsis,
                  style: TextStyle(
                      fontFamily: "Inter",
                      fontSize: 12,
                      color: Colors.black,
                      fontWeight: FontWeight.normal),
                ),
                SizedBox(
                  width: 20,
                ),
              ],
            )
          ],
        ),
      ),
    );
  }

  Widget _buildInfo() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        SizedBox(
          height: 20,
        ),
        _buildDoubleTextLabel(
            strongText: "Polazak:",
            text:
                " ${DateFormat("dd.MM.yyyy u HH:mm").format(widget.voznja.datumVrijemePocetka ?? DateTime.now())} sati"),
        if (widget.voznja.datumVrijemeZavrsetka != null) ...[
          _buildDoubleTextLabel(
              strongText: "Završetak:",
              text:
                  " ${DateFormat("dd.MM.yyyy u HH:mm").format(widget.voznja.datumVrijemeZavrsetka ?? DateTime.now())} sati"),
        ],
        if (Authorization.id == widget.voznja.vozac?.id)
          _buildDoubleTextLabel(
              strongText: "Cijena:", text: " ${widget.voznja.cijena} KM"),
        SizedBox(
          height: 10,
        ),
        if (Authorization.id == widget.voznja.vozac?.id) ...[
          Text("Vi ste vozač ove vožnje.",
              style: TextStyle(
                  fontFamily: "Inter",
                  fontSize: 13,
                  color: Colors.black,
                  fontWeight: FontWeight.bold)),
          if (widget.voznja.stateMachine == 'completed')
            Text("Ova vožnja je završena.",
                style: TextStyle(
                    fontFamily: "Inter",
                    fontSize: 13,
                    color: Colors.black,
                    fontWeight: FontWeight.bold)),
        ],
        if (isClient) ...[
          Text("Vi ste putnik ove vožnje.",
              style: TextStyle(
                  fontFamily: "Inter",
                  fontSize: 13,
                  color: Colors.black,
                  fontWeight: FontWeight.bold)),
          if (widget.voznja.stateMachine == 'completed')
            Text("Ova vožnja je završena.",
                style: TextStyle(
                    fontFamily: "Inter",
                    fontSize: 13,
                    color: Colors.black,
                    fontWeight: FontWeight.bold)),
          if (widget.voznja.stateMachine == 'inprogress')
            Text("Ova vožnja je u toku.",
                style: TextStyle(
                    fontFamily: "Inter",
                    fontSize: 13,
                    color: Colors.black,
                    fontWeight: FontWeight.bold)),
          if (widget.voznja.stateMachine == 'booked')
            Text("Ova vožnja je zakazana.",
                style: TextStyle(
                    fontFamily: "Inter",
                    fontSize: 13,
                    color: Colors.black,
                    fontWeight: FontWeight.bold)),
        ],
        if (recenzijeResult?.result.isNotEmpty == true) ...[
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              SizedBox(
                height: 20,
              ),
              Text("Ocjena vožnje:",
                  style: TextStyle(
                      fontFamily: "Inter",
                      fontSize: 13,
                      color: Colors.black,
                      fontWeight: FontWeight.bold)),
              RatingBar.readOnly(
                alignment: Alignment.center,
                filledIcon: Icons.star_rounded,
                emptyIcon: Icons.star_border_rounded,
                initialRating:
                    recenzijeResult?.result[0].ocjena?.toDouble() ?? 0.0,
                maxRating: 5,
                size: 40,
              ),
              SizedBox(
                height: 10,
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text("Komentar:",
                      style: TextStyle(
                          fontFamily: "Inter",
                          fontSize: 13,
                          color: Colors.black,
                          fontWeight: FontWeight.bold)),
                  Text(recenzijeResult?.result[0].komentar ?? '',
                      style: TextStyle(
                          fontFamily: "Inter",
                          fontSize: 13,
                          color: Colors.black,
                          fontWeight: FontWeight.normal)),
                ],
              ),
            ],
          ),
        ]
      ],
    );
  }

  Widget _buildTrusted() {
    return Container(
        width: double.infinity,
        decoration: BoxDecoration(
            color: isTrusted
                ? Color(0xFF39D5C3).withAlpha(60)
                : Color(0xFFE14040).withAlpha(40),
            borderRadius: BorderRadius.circular(15)),
        child: Stack(
          children: [
            Positioned(
              bottom: -20,
              right: 10,
              child: Icon(
                isTrusted
                    ? Icons.sentiment_satisfied_rounded
                    : Icons.sentiment_dissatisfied_rounded,
                size: 100,
                color: Colors.black.withAlpha(20),
              ),
            ),
            Padding(
              padding: const EdgeInsets.only(
                  top: 20, left: 15, right: 15, bottom: 20),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                spacing: 5,
                children: [
                  Text(
                    isTrusted ? "Provjeren vozač" : "Neprovjeren vozač",
                    style: TextStyle(
                        fontFamily: "Inter",
                        fontSize: 16,
                        color: Colors.black,
                        fontWeight: FontWeight.bold),
                  ),
                  Text(
                    isTrusted
                        ? "Ovaj vozač ima $brojVoznji uspješnih vožnji"
                        : "Ovaj vozač nema nijednu završenu vožnju.",
                    style: TextStyle(
                        fontFamily: "Inter",
                        fontSize: 13,
                        color: Colors.black,
                        fontWeight: FontWeight.normal),
                  ),
                ],
              ),
            )
          ],
        ));
  }

  Widget _buildPrices() {
    return Container(
      margin: EdgeInsets.only(top: 20),
      child: Column(
        spacing: 12,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _buildDoubleTextLabel(
              strongText: "Cijena:",
              text: " ${widget.voznja.cijena!.toStringAsFixed(2)} KM"),
          if (isCouponCorrect?.ispravanKupon == true &&
              isCouponCorrect?.kupon != null)
            _buildDoubleTextLabel(
                strongText: "Popust na kupon:",
                text:
                    " -${(widget.voznja.cijena! - (widget.voznja.cijena! * (1 - (isCouponCorrect?.kupon?.popust ?? 0)))).toStringAsFixed(2)} KM",
                textColor: Color(0xFFE14040)),
          if (brojVoznjiKlijenta >= 10) ...[
            _buildDoubleTextLabel(
                strongText: "Popust na Rank:",
                text:
                    " -${(widget.voznja.cijena! * 0.1).toStringAsFixed(2)} KM",
                textColor: Color(0xFFE14040)),
          ],
          _buildDoubleTextLabel(
              strongText: "Provizija na pronalazak:", text: " 2.00 KM"),
          SizedBox(
            width: double.infinity,
            height: 2,
            child: Container(
              decoration: BoxDecoration(color: Colors.black),
            ),
          ),
          _buildDoubleTextLabel(
              strongText: "Ukupno:",
              text: " ${totalPrice.toStringAsFixed(2)} KM")
        ],
      ),
    );
  }

  Widget _pay() {
    return Container(
      margin: EdgeInsets.only(top: 40),
      child: CustomButtonWidget(
        isFullWidth: true,
        buttonText: "Plati vožnju",
        onPress: () {
          makePayment();
        },
        fontSize: 12,
      ),
    );
  }

  Widget _buildCouponCheck() {
    return Container(
      margin: EdgeInsets.only(top: 20),
      constraints: BoxConstraints(maxWidth: double.infinity),
      child: SizedBox(
        child: Column(
          children: [
            SizedBox(
              height: 30,
              child: Row(
                children: [
                  Expanded(
                    // Ograničava širinu unutar Row
                    child: CustomInputField(
                      labelText: "Kupon",
                      fontSize: 10,
                      controller: _kuponController,
                    ),
                  ),
                  SizedBox(width: 10), // Razmak između inputa i dugmeta
                  SizedBox(
                    width: 100,
                    child: CustomButtonWidget(
                      buttonText: "Provjeri",
                      padding: const EdgeInsets.symmetric(
                          vertical: 5, horizontal: 24),
                      onPress: () async {
                        isCouponCorrect =
                            await _kuponiProvider.check(_kuponController.text);

                        if (isCouponCorrect?.kupon != null) {
                          totalPrice = totalPrice -
                              (widget.voznja.cijena! -
                                  (widget.voznja.cijena! *
                                      (1 -
                                          (isCouponCorrect?.kupon?.popust ??
                                              0))));
                        } else {
                          totalPrice = widget.voznja.cijena! + 2;
                        }

                        setState(() {});
                      },
                      fontSize: 10,
                    ),
                  ),
                ],
              ),
            ),
            _kuponController.text.isNotEmpty && isCouponCorrect != null
                ? Container(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      isCouponCorrect!.ispravanKupon
                          ? "Kupon je uredan."
                          : "Kupon nije uredan.",
                      style: TextStyle(fontSize: 12),
                    ),
                  )
                : Container()
          ],
        ),
      ),
    );
  }

  Future<void> makePayment() async {
    try {
      var paymentIntent =
          await createPaymentIntent((totalPrice).toStringAsFixed(2), "BAM");

      await Stripe.instance.initPaymentSheet(
        paymentSheetParameters: SetupPaymentSheetParameters(
          paymentIntentClientSecret: paymentIntent['client_secret'],
          merchantDisplayName: "ridewithme",
        ),
      );

      await Stripe.instance.presentPaymentSheet();

      await _voznjeProvider.book(widget.voznja.id ?? 0, {
        "kod": _kuponController.text.isEmpty ? null : _kuponController.text,
        'payment_id': paymentIntent['id']
      });

      Navigator.of(context).pushReplacement(
        CupertinoPageRoute(
          builder: (context) => PaymentSuccess(),
        ),
      );
    } catch (e) {
      if (e is StripeException) {
        return;
      }

      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          behavior: SnackBarBehavior.floating,
          content: Text(e.toString()),
        ),
      );
    }
  }

  Future<Map<String, dynamic>> createPaymentIntent(
      String amount, String currency) async {
    try {
      String secretKey = dotenv.env["STRIPE__SECRETKEY"]!;

      final response = await http.post(
        Uri.parse("https://api.stripe.com/v1/payment_intents"),
        headers: {
          "Authorization": "Bearer $secretKey",
          "Content-Type": "application/x-www-form-urlencoded",
        },
        body: {
          "amount": ((double.parse(amount) * 100).toInt()).toString(),
          "currency": currency,
          "payment_method_types[]": "card",
        },
      );

      return json.decode(response.body);
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          behavior: SnackBarBehavior.floating,
          content: Text("Interna greška servera, pokušajte ponovo."),
        ),
      );
      throw Exception(e);
    }
  }

  TextStyle _buildTextStyle() {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: 30,
        color: Color(0xFF7463DE),
        fontWeight: FontWeight.w900);
  }

  TextStyle _buildBoldTextStyle(
      {bool bold = true, Color color = Colors.black}) {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: 13,
        color: color,
        fontWeight: bold ? FontWeight.bold : FontWeight.normal);
  }

  Widget _buildDoubleTextLabel(
      {String strongText = '',
      String text = '',
      Color textColor = Colors.black}) {
    return RichText(
      text: TextSpan(
          text: strongText,
          children: [
            TextSpan(
                text: " $text",
                style: _buildBoldTextStyle(bold: false, color: textColor))
          ],
          style: _buildBoldTextStyle()),
    );
  }
}
