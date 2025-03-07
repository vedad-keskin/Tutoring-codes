import 'package:flutter/material.dart';
import 'package:ridewithme_mobile/models/reklama.dart';
import 'package:ridewithme_mobile/screens/reklama_details_screen.dart';

class ReklamaWidget extends StatelessWidget {
  ReklamaWidget({super.key, required this.reklama, required this.boxColor});
  final Reklama reklama;
  final Color boxColor;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => ReklamaDetailsScreen(reklama: reklama),
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
                        Icons.campaign,
                        color: Color(0xFF072220),
                        size: 30,
                      ),
                      Text(
                        "Reklama",
                        style: TextStyle(
                            fontFamily: "Inter",
                            color: Color(0xFF072220),
                            fontSize: 13),
                      )
                    ],
                  ),
                  Text(
                    reklama.nazivKampanje ?? '',
                    style: TextStyle(
                        fontFamily: "Inter",
                        color: Color(0xFF072220),
                        fontSize: 20,
                        fontWeight: FontWeight.w900),
                  ),
                  Text(
                    reklama.nazivKlijenta ?? '',
                    style: TextStyle(
                        fontFamily: "Inter",
                        color: Color(0xFF072220),
                        fontSize: 12,
                        fontWeight: FontWeight.w500),
                  ),
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
