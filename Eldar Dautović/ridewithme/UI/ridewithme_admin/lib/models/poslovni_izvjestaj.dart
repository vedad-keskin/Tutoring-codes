// -- poslovni_izvjestaj.dart --
import 'package:json_annotation/json_annotation.dart';

part 'poslovni_izvjestaj.g.dart';

@JsonSerializable()
class PoslovniIzvjestaj {
  int? godina;
  int? brojAdministratora;
  int? brojVoznji;
  int? brojKorisnika;
  int? brojKreiranihKupona;
  int? brojIskoristenihKupona;
  double? prihodiVozaca;

  PoslovniIzvjestaj(
    this.godina,
    this.brojAdministratora,
    this.brojVoznji,
    this.brojKorisnika,
    this.brojKreiranihKupona,
    this.brojIskoristenihKupona,
    this.prihodiVozaca,
  );

  factory PoslovniIzvjestaj.fromJson(Map<String, dynamic> json) =>
      _$PoslovniIzvjestajFromJson(json);

  Map<String, dynamic> toJson() => _$PoslovniIzvjestajToJson(this);
}
