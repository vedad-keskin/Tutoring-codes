import 'package:flutter/material.dart';
import 'package:ridewithme_mobile/models/obavjestenje.dart';
import 'package:ridewithme_mobile/screens/obavjestenja_details.dart';

class NoticeWidget extends StatelessWidget {
  NoticeWidget({super.key, required this.obavjestenje, required this.boxColor});
  final Obavjestenje obavjestenje;
  final Color boxColor;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) =>
                ObavjestenjaDetails(obavjestenje: obavjestenje),
          ),
        );
      },
      child: Container(
        height: 200,
        margin: EdgeInsets.symmetric(horizontal: 10),
        width: double.infinity,
        decoration: BoxDecoration(
            color: boxColor.withAlpha(60),
            borderRadius: BorderRadius.circular(15)),
        child: Stack(
          children: [
            Padding(
              padding: const EdgeInsets.all(15.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                spacing: 5,
                children: [
                  Row(
                    spacing: 5,
                    children: [
                      Icon(
                        Icons.info,
                        color: Color(0xFF072220),
                        size: 30,
                      ),
                      Text(
                        "Obavještenje",
                        style: TextStyle(
                            fontFamily: "Inter",
                            color: Color(0xFF072220),
                            fontSize: 13),
                      )
                    ],
                  ),
                  Text(
                    obavjestenje.naslov ?? '',
                    style: TextStyle(
                        fontFamily: "Inter",
                        color: Color(0xFF072220),
                        fontSize: 20,
                        fontWeight: FontWeight.w900),
                  ),
                  Text(
                    obavjestenje.podnaslov ?? '',
                    style: TextStyle(
                        fontFamily: "Inter",
                        color: Color(0xFF072220),
                        fontSize: 12,
                        fontWeight: FontWeight.w500),
                  )
                ],
              ),
            ),
            Positioned(
              bottom: 10,
              right: 20,
              child: Icon(
                Icons.chevron_right,
                size: 30,
                color: Color(0xFF000C3C).withAlpha(50),
              ),
            )
          ],
        ),
      ),
    );
  }
}
