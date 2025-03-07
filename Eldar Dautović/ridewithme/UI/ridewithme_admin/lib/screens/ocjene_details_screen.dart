import 'package:custom_rating_bar/custom_rating_bar.dart';
import 'package:flutter/material.dart';
import 'package:ridewithme_admin/models/recenzija.dart';
import 'package:ridewithme_admin/screens/ocjene_screen.dart';
import 'package:ridewithme_admin/widgets/master_screen.dart';

class OcjeneDetailsScreen extends StatefulWidget {
  Recenzija recenzija;

  OcjeneDetailsScreen({super.key, required this.recenzija});

  @override
  State<OcjeneDetailsScreen> createState() => _OcjeneDetailsScreenState();
}

class _OcjeneDetailsScreenState extends State<OcjeneDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      selectedIndex: 12,
      headerTitle: "Ocjena detalji",
      headerDescription: "Ovdje možete da pregledate detalje ocjene.",
      backButton: OcjeneScreen(),
      child: Column(
        children: [_buildReview()],
      ),
    );
  }

  Widget _buildReview() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Row(
          spacing: 20,
          children: [
            namedColumn(
                Text("${widget.recenzija.voznja?.id ?? 'N/A'}"), "Broj vožnje"),
          ],
        ),
        SizedBox(height: 15),
        Text(
          "Komentar:",
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.w900,
            color: Colors.black87,
            fontFamily: "Inter",
          ),
        ),
        SizedBox(height: 4),
        Container(
            padding: const EdgeInsets.all(12),
            decoration: BoxDecoration(
              color: Colors.grey[200],
              borderRadius: BorderRadius.circular(8),
            ),
            child: Text(
              widget.recenzija.komentar ?? 'Nema komentara.',
              style: TextStyle(
                fontSize: 14,
                color: Colors.black87,
                height: 1.5,
                fontFamily: "Inter",
              ),
            )),
        SizedBox(height: 15),
        Text(
          "Ocjena:",
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.w900,
            color: Colors.black87,
            fontFamily: "Inter",
          ),
        ),
        RatingBar.readOnly(
          alignment: Alignment.centerLeft,
          filledIcon: Icons.star_rounded,
          emptyIcon: Icons.star_border_rounded,
          initialRating: widget.recenzija.ocjena!.toDouble(),
          maxRating: 5,
          size: 40,
        ),
      ],
    );
  }

  Widget namedColumn(Widget rightSide, String name) {
    return Row(
      spacing: 5,
      children: [
        Text(
          "$name:",
          style: TextStyle(
              fontSize: 16,
              color: Colors.black87,
              height: 1.5,
              fontFamily: "Inter",
              fontWeight: FontWeight.w900),
        ),
        rightSide
      ],
    );
  }
}
