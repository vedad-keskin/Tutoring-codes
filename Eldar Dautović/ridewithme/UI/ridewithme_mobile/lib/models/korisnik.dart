// -- korisnik.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/korisnici_dostignuca.dart';
import 'package:ridewithme_mobile/models/korisnik_uloga.dart';

part 'korisnik.g.dart';

@JsonSerializable()
class Korisnik {
  int? id;
  String? ime;
  String? prezime;
  String? korisnickoIme;
  String? email;
  List<KorisnikUloga>? korisniciUloge;
  List<KorisniciDostignuca>? korisniciDostignuca;
  DateTime? datumKreiranja;
  String? slika;

  Korisnik(
      this.id,
      this.ime,
      this.prezime,
      this.korisnickoIme,
      this.email,
      this.korisniciUloge,
      this.datumKreiranja,
      this.slika,
      this.korisniciDostignuca);

  factory Korisnik.fromJson(Map<String, dynamic> json) =>
      _$KorisnikFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikToJson(this);
}
