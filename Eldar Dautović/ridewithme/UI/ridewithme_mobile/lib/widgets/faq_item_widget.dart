import 'package:flutter/material.dart';

class FaqItemWidget extends StatelessWidget {
  final String question;
  final String answer;

  const FaqItemWidget({
    Key? key,
    required this.question,
    required this.answer,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      margin: EdgeInsets.only(right: 20, left: 20, bottom: 10),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      child: ExpansionTile(
        title: Text(
          question,
          style:
              const TextStyle(fontWeight: FontWeight.bold, fontFamily: "Inter"),
        ),
        tilePadding: const EdgeInsets.symmetric(horizontal: 20, vertical: 8),
        childrenPadding:
            const EdgeInsets.symmetric(horizontal: 20, vertical: 8),
        expandedCrossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            height: 100,
            width: double.infinity,
            child: Text(
              answer,
              softWrap: true, // Omogućava višeredni prikaz
              style: const TextStyle(fontSize: 15, fontFamily: "Inter"),
            ),
          ),
        ],
      ),
    );
  }
}
