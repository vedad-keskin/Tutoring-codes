import 'package:flutter/material.dart';
import 'package:ridewithme_mobile/models/grad.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';

class TownWidget extends StatelessWidget {
  const TownWidget({super.key, required this.grad});

  final Gradovi grad;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        ClipRRect(
            borderRadius: BorderRadius.circular(100),
            child: Container(
              width: 50,
              height: 50,
              child: Icon(
                Icons.location_city,
                size: 50,
                color: Colors.blueGrey,
              ),
            )),
        Text(
          grad.naziv ?? '',
          style: TextStyle(
              fontFamily: "Inter",
              color: Colors.black,
              fontSize: 10,
              fontWeight: FontWeight.w500),
        )
      ],
    );
  }
}
