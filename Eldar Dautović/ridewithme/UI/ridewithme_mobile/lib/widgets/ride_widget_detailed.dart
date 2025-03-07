import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/screens/chat_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_details_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';

class RideWidgetDetailed extends StatefulWidget {
  RideWidgetDetailed(
      {super.key, required this.voznja, required this.boxColor, this.rating});
  final Voznja voznja;
  final Color boxColor;
  bool? rating = false;

  @override
  State<RideWidgetDetailed> createState() => _RideWidgetDetailedState();
}

class _RideWidgetDetailedState extends State<RideWidgetDetailed> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(
          CupertinoPageRoute(
            builder: (context) => VoznjeDetailsScreen(
              voznja: widget.voznja,
            ),
          ),
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
              if (widget.voznja.klijent != null &&
                  widget.rating == false &&
                  widget.voznja.stateMachine == "booked") ...[
                Positioned(
                  top: 10,
                  right: 10,
                  child: GestureDetector(
                    onTap: () {
                      Navigator.of(context).push(
                        CupertinoPageRoute(
                          builder: (context) => ChatScreen(
                            sender:
                                Authorization.id == widget.voznja.klijent?.id
                                    ? widget.voznja.vozac!
                                    : widget.voznja.klijent!,
                          ),
                        ),
                      );
                    },
                    child: Icon(
                      Icons.mail,
                      color: widget.boxColor,
                    ),
                  ),
                )
              ],
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Row(
                    spacing: 10,
                    children: [
                      SizedBox(
                        height: 100,
                        width: 7,
                        child: DecoratedBox(
                            decoration: BoxDecoration(color: widget.boxColor)),
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
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    spacing: 8,
                    children: [
                      _buildDoubleTextLabel(
                          strongText: "Cijena:",
                          text: "${widget.voznja.cijena} KM"),
                      _buildDoubleTextLabel(
                          strongText: "Polazak:",
                          text: DateFormat("dd.MM.yyyy u HH:mm").format(
                              widget.voznja.datumVrijemePocetka ??
                                  DateTime.now())),
                      widget.voznja.klijent != null
                          ? _buildDoubleTextLabel(
                              strongText: "Klijent:",
                              text:
                                  "${widget.voznja.klijent?.ime} ${widget.voznja.klijent?.prezime}")
                          : Container()
                    ],
                  )
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
        fontWeight: FontWeight.w500);
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
