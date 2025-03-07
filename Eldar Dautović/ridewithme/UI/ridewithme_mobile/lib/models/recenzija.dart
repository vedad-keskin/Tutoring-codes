// -- recenzija.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';
import 'package:ridewithme_mobile/models/voznja.dart';

part 'recenzija.g.dart';

@JsonSerializable()
class Recenzija {
  int? id;
  int? ocjena;
  String? komentar;
  Korisnik? korisnik;
  Voznja? voznja;
  DateTime? datumKreiranja;

  Recenzija(this.id, this.ocjena, this.komentar, this.datumKreiranja,
      this.korisnik, this.voznja);

  factory Recenzija.fromJson(Map<String, dynamic> json) =>
      _$RecenzijaFromJson(json);

  Map<String, dynamic> toJson() => _$RecenzijaToJson(this);
}
