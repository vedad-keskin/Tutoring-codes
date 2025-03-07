import 'package:flutter/material.dart';

const TextStyle tableTextStyle = TextStyle(
  color: Color(0xFF072220),
  fontFamily: "Inter",
  fontSize: 12,
);

final TextStyle columnTextStyle = TextStyle(
  color: Color(0xFF5A605F),
  fontFamily: "Inter",
  fontSize: 12,
);

DataCell buildDataCell(String? text) {
  return DataCell(Text(text ?? "N/A", style: tableTextStyle));
}

const TextStyle reportTextStyle = TextStyle(
  color: Color(0xFF072220),
  fontFamily: "Inter",
  fontSize: 14,
);

DataCell buildReportCell(String? text) {
  return DataCell(Text(text ?? "N/A", style: reportTextStyle));
}
