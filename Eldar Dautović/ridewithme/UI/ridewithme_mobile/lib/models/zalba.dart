// -- zalba.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';
import 'package:ridewithme_mobile/models/vrsta_zalbe.dart';

part 'zalba.g.dart';

@JsonSerializable()
class Zalba {
  int? id;
  String? naslov;
  String? sadrzaj;
  String? odgovorNaZalbu;
  DateTime? datumIzmjene;
  DateTime? datumPreuzimanja;
  DateTime? datumKreiranja;
  String? stateMachine;
  VrstaZalbe? vrstaZalbe;
  Korisnik? administrator;
  Korisnik? korisnik;

  Zalba(
    this.id,
    this.naslov,
    this.sadrzaj,
    this.odgovorNaZalbu,
    this.datumIzmjene,
    this.datumPreuzimanja,
    this.datumKreiranja,
    this.stateMachine,
    this.vrstaZalbe,
    this.administrator,
    this.korisnik,
  );

  factory Zalba.fromJson(Map<String, dynamic> json) => _$ZalbaFromJson(json);

  Map<String, dynamic> toJson() => _$ZalbaToJson(this);
}
