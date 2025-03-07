// -- obavjestenje.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_admin/models/korisnik.dart';

part 'obavjestenje.g.dart';

@JsonSerializable()
class Obavjestenje {
  int? id;
  String? stateMachine;
  String? naslov;
  String? podnaslov;
  String? opis;
  DateTime? datumKreiranja;
  DateTime? datumIzmjene;
  DateTime? datumZavrsetka;
  Korisnik? korisnik;

  Obavjestenje(
    this.id,
    this.stateMachine,
    this.naslov,
    this.podnaslov,
    this.opis,
    this.datumKreiranja,
    this.datumIzmjene,
    this.datumZavrsetka,
    this.korisnik,
  );

  factory Obavjestenje.fromJson(Map<String, dynamic> json) =>
      _$ObavjestenjeFromJson(json);

  Map<String, dynamic> toJson() => _$ObavjestenjeToJson(this);
}
