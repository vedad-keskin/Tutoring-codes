// -- reklama.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_admin/models/korisnik.dart';

part 'reklama.g.dart';

@JsonSerializable()
class Reklama {
  int? id;
  String? nazivKlijenta;
  String? nazivKampanje;
  String? sadrzajKampanje;
  String? slika;
  Korisnik? korisnik;
  DateTime? datumIzmjene;
  DateTime? datumKreiranja;

  Reklama(
    this.id,
    this.nazivKlijenta,
    this.nazivKampanje,
    this.sadrzajKampanje,
    this.slika,
    this.korisnik,
    this.datumIzmjene,
    this.datumKreiranja,
  );

  factory Reklama.fromJson(Map<String, dynamic> json) =>
      _$ReklamaFromJson(json);

  Map<String, dynamic> toJson() => _$ReklamaToJson(this);
}
