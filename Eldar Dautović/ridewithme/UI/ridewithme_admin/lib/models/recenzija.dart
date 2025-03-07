// -- recenzija.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/models/voznja.dart';

part 'recenzija.g.dart';

@JsonSerializable()
class Recenzija {
  int? id;
  int? ocjena;
  String? komentar;
  Korisnik? korisnik;
  Voznja? voznja;
  DateTime? datumKreiranja;

  Recenzija(
    this.id,
    this.ocjena,
    this.komentar,
    this.korisnik,
    this.voznja,
    this.datumKreiranja,
  );

  factory Recenzija.fromJson(Map<String, dynamic> json) =>
      _$RecenzijaFromJson(json);

  Map<String, dynamic> toJson() => _$RecenzijaToJson(this);
}
