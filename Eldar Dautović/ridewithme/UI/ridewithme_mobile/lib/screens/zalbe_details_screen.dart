import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/zalba.dart';
import 'package:ridewithme_mobile/screens/zalbe_screen.dart';

class ZalbeDetailsScreen extends StatefulWidget {
  Zalba zalba;

  ZalbeDetailsScreen({super.key, required this.zalba});

  @override
  State<ZalbeDetailsScreen> createState() => _ZalbeDetailsScreenState();
}

class _ZalbeDetailsScreenState extends State<ZalbeDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterLayout(
        selectedIndex: 4,
        backButton: ZalbeScreen(),
        header: widget.zalba.naslov,
        headerDescription: "Pregled žalbe",
        headerColor: Color(0xFF7463DE),
        child: Flexible(
          child: SingleChildScrollView(
            child: Column(
              spacing: 10,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [_buildDetails(), _buildComplaintBody()],
            ),
          ),
        ));
  }

  Widget _buildDetails() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Column(
        spacing: 5,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _buildDoubleTextLabel(
              strongText: "Podnio:",
              text:
                  "${widget.zalba.korisnik?.ime} ${widget.zalba.korisnik?.prezime}"),
          _buildDoubleTextLabel(
              strongText: "Vrsta žalbe:",
              text: widget.zalba.vrstaZalbe?.naziv ?? ''),
          _buildDoubleTextLabel(
              strongText: "Datum kreiranja:",
              text: DateFormat("dd.MM.yyyy u HH:mm")
                  .format(widget.zalba.datumKreiranja ?? DateTime.now())),
        ],
      ),
    );
  }

  Widget _buildComplaintBody() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          spacing: 10,
          children: [
            Container(
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(15),
                  color: Color(0xFF7463DE).withAlpha(50)),
              child: Padding(
                padding: const EdgeInsets.all(15.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  spacing: 5,
                  children: [
                    _buildDoubleTextLabel(
                        strongText: "Naslov:",
                        text: widget.zalba.naslov ?? '',
                        fontSize: 13),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      spacing: 5,
                      children: [
                        Text(
                          "Sadržaj žalbe: ",
                          style: _buildBoldTextStyle(bold: true, fontSize: 12),
                        ),
                        Container(
                          width: double.infinity,
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(5),
                              color: Color(0xFF7463DE).withAlpha(50)),
                          child: Padding(
                            padding: const EdgeInsets.all(15.0),
                            child: Text(
                              widget.zalba.sadrzaj ?? '',
                              style: _buildBoldTextStyle(
                                  bold: false, fontSize: 12),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(
              height: 10,
            ),
            if (widget.zalba.stateMachine != "active") ...[
              Container(
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(15),
                    color: Color(0xFF39D5C3).withAlpha(50)),
                child: Padding(
                  padding: const EdgeInsets.all(15.0),
                  child: Column(
                    spacing: 5,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      if (widget.zalba.stateMachine != "active") ...[
                        _buildDoubleTextLabel(
                            strongText:
                                widget.zalba.stateMachine == 'processing'
                                    ? "Obrađuje:"
                                    : "Obradio:",
                            text:
                                "${widget.zalba.administrator?.ime} ${widget.zalba.administrator?.prezime}"),
                        _buildDoubleTextLabel(
                            strongText: "Datum preuzimanja:",
                            text: DateFormat("dd.MM.yyyy u HH:mm").format(
                                widget.zalba.datumPreuzimanja ??
                                    DateTime.now())),
                        _buildDoubleTextLabel(
                            strongText: "Administrator:",
                            text:
                                "${widget.zalba.administrator?.ime} ${widget.zalba.administrator?.prezime}"),
                      ],
                      if (widget.zalba.stateMachine == 'completed') ...[
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          spacing: 5,
                          children: [
                            Text(
                              "Odgovor na žalbu: ",
                              style:
                                  _buildBoldTextStyle(bold: true, fontSize: 12),
                            ),
                            Container(
                              width: double.infinity,
                              decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(5),
                                  color: Color(0xFF39D5C3).withAlpha(50)),
                              child: Padding(
                                padding: const EdgeInsets.all(15.0),
                                child: Text(
                                  widget.zalba.odgovorNaZalbu ?? '',
                                  style: _buildBoldTextStyle(
                                      bold: false, fontSize: 12),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ]
                    ],
                  ),
                ),
              )
            ],
          ]),
    );
  }

  TextStyle _buildBoldTextStyle(
      {bool bold = true, Color color = Colors.black, int fontSize = 12}) {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: fontSize.toDouble(),
        color: color,
        fontWeight: bold ? FontWeight.bold : FontWeight.normal);
  }

  Widget _buildDoubleTextLabel(
      {String strongText = '',
      String text = '',
      int fontSize = 12,
      Color textColor = Colors.black}) {
    return RichText(
      text: TextSpan(
          text: strongText,
          children: [
            TextSpan(
                text: " $text",
                style: _buildBoldTextStyle(
                    bold: false, color: textColor, fontSize: fontSize))
          ],
          style: _buildBoldTextStyle(fontSize: fontSize)),
    );
  }
}
