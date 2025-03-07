import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:ridewithme_mobile/models/zalba.dart';
import 'package:ridewithme_mobile/screens/zalbe_details_screen.dart';

class ComplaintWidgetDetailed extends StatefulWidget {
  ComplaintWidgetDetailed(
      {super.key, required this.zalba, required this.boxColor});
  final Zalba zalba;
  final Color boxColor;

  @override
  State<ComplaintWidgetDetailed> createState() =>
      _ComplaintWidgetDetailedState();
}

class _ComplaintWidgetDetailedState extends State<ComplaintWidgetDetailed> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(
              builder: (context) => ZalbeDetailsScreen(
                    zalba: widget.zalba,
                  )),
        );
      },
      child: Container(
        decoration: BoxDecoration(
            color: widget.boxColor.withAlpha(60),
            borderRadius: BorderRadius.circular(15)),
        child: Padding(
          padding: const EdgeInsets.all(13.0),
          child: Stack(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    spacing: 10,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        widget.zalba.naslov ?? '',
                        style: _buildTextStyle(),
                      ),
                      _buildDoubleTextLabel(
                          strongText: "Vrsta žalbe:",
                          text: widget.zalba.vrstaZalbe?.naziv ?? ''),
                      _buildDoubleTextLabel(
                          strongText: "Datum kreiranja:",
                          text: DateFormat("dd.MM.yyyy u HH:mm").format(
                              widget.zalba.datumKreiranja ?? DateTime.now())),
                    ],
                  ),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }

  TextStyle _buildTextStyle() {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: 17,
        color: Colors.black,
        fontWeight: FontWeight.bold);
  }

  TextStyle _buildBoldTextStyle(
      {bool bold = true, Color color = Colors.black}) {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: 12,
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
