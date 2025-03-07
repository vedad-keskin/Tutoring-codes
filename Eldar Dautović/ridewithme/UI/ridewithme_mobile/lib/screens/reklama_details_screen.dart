import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/reklama.dart';
import 'package:ridewithme_mobile/screens/home_screen.dart';

class ReklamaDetailsScreen extends StatefulWidget {
  ReklamaDetailsScreen({super.key, required this.reklama});

  Reklama reklama;

  @override
  State<ReklamaDetailsScreen> createState() => _ReklamaDetailsScreenState();
}

class _ReklamaDetailsScreenState extends State<ReklamaDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 0,
      backButton: HomeScreen(),
      header: widget.reklama.nazivKampanje,
      headerDescription: widget.reklama.nazivKlijenta,
      headerColor: Colors.greenAccent,
      headerTextColor: Colors.black,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        spacing: 10,
        children: [_buildCoverPhoto(), _buildMainContent(), _buildTimestamp()],
      ),
    );
  }

  Widget _buildCoverPhoto() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Container(
          width: double.infinity,
          height: 150,
          decoration: BoxDecoration(
              color: Colors.white, borderRadius: BorderRadius.circular(100)),
          child: widget.reklama.slika != null
              ? ClipRRect(
                  borderRadius: BorderRadius.circular(5),
                  child: Image.memory(
                    base64Decode(widget.reklama.slika ?? ''),
                    fit: BoxFit.cover,
                  ),
                )
              : Icon(
                  Icons.account_circle,
                  size: 40,
                  color: Colors.blueGrey,
                )),
    );
  }

  Widget _buildMainContent() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Text(
        widget.reklama.sadrzajKampanje ?? '',
        style: TextStyle(fontFamily: 'Inter', fontSize: 16),
        textAlign: TextAlign.justify,
      ),
    );
  }

  Widget _buildTimestamp() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          Text(
            " ${DateFormat("dd.MM.yyyy u HH:mm").format(widget.reklama.datumKreiranja ?? DateTime.now())}",
            style: TextStyle(
                fontFamily: 'Inter', fontSize: 14, fontWeight: FontWeight.w600),
          ),
        ],
      ),
    );
  }
}
