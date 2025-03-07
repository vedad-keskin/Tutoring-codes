import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';

class AvatarWidget extends StatelessWidget {
  const AvatarWidget({super.key, required this.korisnik});

  final Korisnik korisnik;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: 50,
          height: 50,
          decoration: BoxDecoration(
              color: Colors.white, borderRadius: BorderRadius.circular(100)),
          child: korisnik.slika != null
              ? Icon(
                  Icons.account_circle,
                  size: 25,
                  color: Colors.blueGrey,
                )
              : Icon(
                  Icons.account_circle,
                  size: 25,
                  color: Colors.blueGrey,
                ),
        ),
        Text(
          "${korisnik.ime ?? ''}  ${korisnik.prezime ?? ''}",
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
