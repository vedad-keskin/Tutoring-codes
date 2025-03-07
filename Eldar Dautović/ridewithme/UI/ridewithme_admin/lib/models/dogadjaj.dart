// -- dogadjaj.dart --
import 'package:json_annotation/json_annotation.dart';

part 'dogadjaj.g.dart';

@JsonSerializable()
class Dogadjaj {
  int? id;
  String? naziv;
  String? opis;
  DateTime? datumKreiranja;
  DateTime? datumIzmjene;
  DateTime? datumPocetka;
  DateTime? datumZavrsetka;

  Dogadjaj(
    this.id,
    this.naziv,
    this.opis,
    this.datumKreiranja,
    this.datumIzmjene,
    this.datumPocetka,
    this.datumZavrsetka,
  );

  factory Dogadjaj.fromJson(Map<String, dynamic> json) =>
      _$DogadjajFromJson(json);

  Map<String, dynamic> toJson() => _$DogadjajToJson(this);
}
