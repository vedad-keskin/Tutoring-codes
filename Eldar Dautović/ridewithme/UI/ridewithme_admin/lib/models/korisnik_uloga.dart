// -- korisnik_uloga.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_admin/models/uloga.dart';

part 'korisnik_uloga.g.dart';

@JsonSerializable()
class KorisnikUloga {
  int? id;
  DateTime? datumIzmjene;
  Uloga? uloga;

  KorisnikUloga(
    this.id,
    this.datumIzmjene,
    this.uloga,
  );

  factory KorisnikUloga.fromJson(Map<String, dynamic> json) =>
      _$KorisnikUlogaFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikUlogaToJson(this);
}
