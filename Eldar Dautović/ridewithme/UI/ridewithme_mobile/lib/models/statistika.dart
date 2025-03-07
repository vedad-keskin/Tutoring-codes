// -- statistika.dart --
import 'package:json_annotation/json_annotation.dart';

part 'statistika.g.dart';

@JsonSerializable()
class Statistika {
  int? brojRegistrovanihKorisnika;
  int? brojIskoristenihKupona;
  int? brojKreiranihVoznji;
  int? brojVozaca;
  int? brojZakazanihVoznji;

  Statistika(
    this.brojRegistrovanihKorisnika,
    this.brojIskoristenihKupona,
    this.brojKreiranihVoznji,
    this.brojVozaca,
    this.brojZakazanihVoznji,
  );

  factory Statistika.fromJson(Map<String, dynamic> json) =>
      _$StatistikaFromJson(json);

  Map<String, dynamic> toJson() => _$StatistikaToJson(this);
}
