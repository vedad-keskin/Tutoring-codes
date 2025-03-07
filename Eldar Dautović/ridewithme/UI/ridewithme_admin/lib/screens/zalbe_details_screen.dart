import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_admin/models/zalba.dart';
import 'package:ridewithme_admin/providers/zalbe_provider.dart';
import 'package:ridewithme_admin/screens/zalbe_screen.dart';
import 'package:ridewithme_admin/utils/util.dart';
import 'package:ridewithme_admin/widgets/custom_button_widget.dart';
import 'package:ridewithme_admin/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class ZalbeDetailsScreen extends StatefulWidget {
  Zalba zalba;
  ZalbeDetailsScreen({super.key, required this.zalba});

  @override
  State<ZalbeDetailsScreen> createState() => _ZalbeDetailsScreenState();
}

class _ZalbeDetailsScreenState extends State<ZalbeDetailsScreen> {
  late ZalbaProvider _zalbaProvider;

  List<String>? allowedActions;

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _zalbaProvider = context.read<ZalbaProvider>();

    initForm();
  }

  Future initForm() async {
    allowedActions = await _zalbaProvider.allowedActions(widget.zalba.id ?? 0);

    setState(() {
      isLoading = false;
    });
  }

  void executeAction(String name) async {
    try {
      switch (name) {
        case "Processing":
          {
            await _zalbaProvider.process(widget.zalba.id ?? 0);

            showSnackBar("Uspješno ste preuzeli žalbu.");

            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => const ZalbeScreen(),
              ),
            );

            break;
          }
        case "Complete":
          {
            if (Authorization.id != widget.zalba.administrator?.id) {
              return showSnackBar("Vi niste preuzeli žalbu.");
            }

            String? odgovorNaZalbu = await showDialog<String>(
              context: context,
              builder: (context) {
                TextEditingController controller = TextEditingController();
                return AlertDialog(
                  title: Text("Unesite odgovor na žalbu"),
                  content: TextField(
                    controller: controller,
                    decoration: InputDecoration(
                      hintText: 'Unesite odgovor...',
                    ),
                  ),
                  actions: <Widget>[
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).pop();
                      },
                      child: Text("Odustani"),
                    ),
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).pop(controller.text);
                      },
                      child: Text("Pošaljite"),
                    ),
                  ],
                );
              },
            );

            if (odgovorNaZalbu != null && odgovorNaZalbu.isNotEmpty) {
              await _zalbaProvider.complete(
                  widget.zalba.id ?? 0, {"odgovorNaZalbu": odgovorNaZalbu});

              showSnackBar("Uspješno ste odgovorili na žalbu.");

              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => const ZalbeScreen(),
                ),
              );
            }
            break;
          }
        default:
      }
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
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

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 6,
      headerTitle: "Detalji žalbe",
      headerDescription: "Ovdje možete pregledati detalje žalbe.",
      backButton: ZalbeScreen(),
      child: Column(
        children: [
          isLoading ? LoadingSpinnerWidget() : _buildActions(),
          isLoading ? LoadingSpinnerWidget() : _buildComplaint()
        ],
      ),
    );
  }

  Widget _buildComplaint() {
    final zalba = widget.zalba;

    return Column(
      spacing: 15,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Row(
          spacing: 20,
          children: [
            namedColumn(Text("${zalba.id ?? 'N/A'}"), "Broj žalbe"),
            namedColumn(Text("${zalba.korisnik?.korisnickoIme}"), "Korisnik"),
            namedColumn(
                Text(
                    "${DateFormat('dd/MM/yyyy HH:mm').format(zalba.datumKreiranja!)}"),
                "Datum kreiranja"),
          ],
        ),
        SizedBox(height: 15),
        Text(
          "Opis žalbe:",
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.w900,
            color: Colors.black87,
            fontFamily: "Inter",
          ),
        ),
        SizedBox(height: 4),
        Container(
          padding: const EdgeInsets.all(12),
          decoration: BoxDecoration(
            color: Colors.grey[200],
            borderRadius: BorderRadius.circular(8),
          ),
          child: Text(
            zalba.sadrzaj ?? 'Nema opisa.',
            style: TextStyle(
              fontSize: 14,
              color: Colors.black87,
              height: 1.5,
              fontFamily: "Inter",
            ),
          ),
        ),
        SizedBox(height: 16),
        namedColumn(
            Badge(
              padding:
                  const EdgeInsets.only(left: 5, right: 5, top: 4, bottom: 4),
              label:
                  Text(ZalbeStatus.fromString(zalba.stateMachine)?.naziv ?? ""),
              backgroundColor:
                  ZalbeStatus.fromString(zalba.stateMachine)?.boja ??
                      Colors.red,
            ),
            "Status"),
        SizedBox(height: 8),
        namedColumn(
            Text(
              "${zalba.administrator?.korisnickoIme ?? 'N/A'}",
            ),
            "Odgovorno lice")
      ],
    );
  }

  Widget namedColumn(Widget rightSide, String name) {
    return Row(
      spacing: 5,
      children: [
        Text(
          "$name:",
          style: TextStyle(
              fontSize: 16,
              color: Colors.black87,
              height: 1.5,
              fontFamily: "Inter",
              fontWeight: FontWeight.w900),
        ),
        rightSide
      ],
    );
  }

  Widget _buildActions() {
    return Column(
      children: [
        Row(
          spacing: 10,
          mainAxisAlignment: MainAxisAlignment.end,
          children: (allowedActions ?? [])
              .where((e) =>
                  ZalbeActions.fromString(e)?.naziv.isNotEmpty ??
                  false) // Filtriranje praznih
              .map((e) {
            final action = ZalbeActions.fromString(e);
            return CustomButtonWidget(
              buttonText: action!.naziv,
              onPress: () => executeAction(e),
              buttonColor: action.boja,
              textColor: action.textBoja,
            );
          }).toList(),
        ),
        SizedBox(
          height: 20,
        )
      ],
    );
  }
}
