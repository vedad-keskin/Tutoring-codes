// -- korisnici_dostignuca.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/dostignuca.dart';

part 'korisnici_dostignuca.g.dart';

@JsonSerializable()
class KorisniciDostignuca {
  int? id;
  Dostignuca? dostignuce;
  DateTime? datumKreiranja;

  KorisniciDostignuca(
    this.id,
    this.dostignuce,
    this.datumKreiranja,
  );

  factory KorisniciDostignuca.fromJson(Map<String, dynamic> json) =>
      _$KorisniciDostignucaFromJson(json);

  Map<String, dynamic> toJson() => _$KorisniciDostignucaToJson(this);
}
