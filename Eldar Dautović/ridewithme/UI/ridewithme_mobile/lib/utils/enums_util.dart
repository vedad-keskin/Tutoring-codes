import 'package:flutter/material.dart';

enum VoznjaStatus {
  draft("Draft", Colors.amber),
  active("Aktivan", Colors.green),
  hidden("Sakriven", Colors.grey),
  booked("Rezervisan", Colors.blue),
  inprogress("U toku", Colors.orange),
  completed("Završen", Colors.purple);

  final String naziv;
  final Color boja;
  const VoznjaStatus(this.naziv, this.boja);

  static VoznjaStatus? fromString(String? value) {
    return VoznjaStatus.values.firstWhere(
      (status) => status.name == value,
      orElse: () => VoznjaStatus.draft, // Podrazumevana vrednost
    );
  }
}

enum VoznjaActions {
  Activate(
      "Aktiviraj", Color(0xFF4CAF50), Color(0xFF072220)), // Smaragdno zelena
  Hide("Sakrij", Color(0xFFFFC107), Color(0xFF072220)), // Zlatno žuta
  Delete("Obriši", Color(0xFFFF7043), Color(0xFF072220)), // Topla narandžasta
  Edit("Omogući uređivanje", Color(0xFF64B5F6),
      Color(0xFF072220)), // Pastelno plava
  Update("Uredi", Color(0xFF64B5F6), Color(0xFF072220)), // Pastelno plava
  Start("Započni", Color(0xFF4CAF50), Color(0xFF072220)), // Pastelno plava
  Complete("Završi", Color(0xFFFF7043), Color(0xFF072220)), // Pastelno plava
  Rate("Ocijeni", Color(0xFFFFC107), Color(0xFF072220)), // Pastelno plava
  NonExisting("", Colors.transparent,
      Color(0xFF072220)); // Transparentna za nepostojeće akcije

  final String naziv;
  final Color boja;
  final Color textBoja;
  const VoznjaActions(this.naziv, this.boja, this.textBoja);

  static VoznjaActions? fromString(String? value) {
    return VoznjaActions.values.firstWhere(
      (status) => status.name == value,
      orElse: () => VoznjaActions.NonExisting,
    );
  }
}
