// -- kupon.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';

part 'kupon.g.dart';

@JsonSerializable()
class Kupon {
  int? id;
  String? kod;
  String? naziv;
  DateTime? datumPocetka;
  int? brojIskoristivosti;
  String? stateMachine;
  double? popust;
  Korisnik? korisnik;
  DateTime? datumIzmjene;

  Kupon(
    this.id,
    this.kod,
    this.naziv,
    this.datumPocetka,
    this.brojIskoristivosti,
    this.stateMachine,
    this.popust,
    this.korisnik,
    this.datumIzmjene,
  );

  factory Kupon.fromJson(Map<String, dynamic> json) => _$KuponFromJson(json);

  Map<String, dynamic> toJson() => _$KuponToJson(this);
}
