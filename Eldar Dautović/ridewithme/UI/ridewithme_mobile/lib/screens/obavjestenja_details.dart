import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/obavjestenje.dart';
import 'package:ridewithme_mobile/screens/home_screen.dart';

class ObavjestenjaDetails extends StatefulWidget {
  ObavjestenjaDetails({super.key, required this.obavjestenje});

  Obavjestenje obavjestenje;

  @override
  State<ObavjestenjaDetails> createState() => _ObavjestenjaDetailsState();
}

class _ObavjestenjaDetailsState extends State<ObavjestenjaDetails> {
  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 0,
      backButton: HomeScreen(),
      header: widget.obavjestenje.naslov,
      headerDescription: widget.obavjestenje.podnaslov,
      headerColor: Color(0xFFFCFC00),
      headerTextColor: Colors.black,
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            children: [_buildMainContent(), _buildTimestamp()],
          ),
        ),
      ),
    );
  }

  Widget _buildMainContent() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Text(
        widget.obavjestenje.opis ?? '',
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
            " ${DateFormat("dd.MM.yyyy u HH:mm").format(widget.obavjestenje.datumKreiranja ?? DateTime.now())}",
            style: TextStyle(
                fontFamily: 'Inter', fontSize: 14, fontWeight: FontWeight.w600),
          ),
        ],
      ),
    );
  }
}
