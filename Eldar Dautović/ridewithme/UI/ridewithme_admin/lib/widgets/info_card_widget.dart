import 'package:flutter/material.dart';

class InfoCardWidget extends StatefulWidget {
  final String? cardTitle;
  final String? cardValue;
  final String? cardSubtitle;

  InfoCardWidget(
      {this.cardTitle, this.cardValue, this.cardSubtitle, super.key});

  @override
  State<InfoCardWidget> createState() => _InfoCardWidgetState();
}

class _InfoCardWidgetState extends State<InfoCardWidget> {
  @override
  Widget build(BuildContext context) {
    return Container(
        width: 300,
        height: 150,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(10), color: Color(0x998E9EE6)),
        child: Padding(
            padding: EdgeInsets.only(left: 30, top: 12),
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Text(
                    widget.cardTitle ?? '',
                    style: TextStyle(
                        fontFamily: "Inter",
                        fontSize: MediaQuery.of(context).size.width * 0.009,
                        fontWeight: FontWeight.w300),
                  ),
                  Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          widget.cardValue ?? '',
                          style: TextStyle(
                              fontFamily: "Inter",
                              fontSize:
                                  MediaQuery.of(context).size.width * 0.02,
                              fontWeight: FontWeight.w800),
                        ),
                        Text(
                          widget.cardSubtitle ?? '',
                          style: TextStyle(
                              fontFamily: "Inter",
                              fontSize:
                                  MediaQuery.of(context).size.width * 0.008,
                              fontWeight: FontWeight.w500,
                              color: Color(0xFF7463DE)),
                        ),
                      ])
                ])));
  }
}
