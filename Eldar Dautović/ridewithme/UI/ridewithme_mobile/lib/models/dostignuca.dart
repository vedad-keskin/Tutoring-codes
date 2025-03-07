// -- dostignuca.dart --
import 'package:json_annotation/json_annotation.dart';

part 'dostignuca.g.dart';

@JsonSerializable()
class Dostignuca {
  int? id;
  String? naziv;
  String? opis;

  Dostignuca(
    this.id,
    this.naziv,
    this.opis,
  );

  factory Dostignuca.fromJson(Map<String, dynamic> json) =>
      _$DostignucaFromJson(json);

  Map<String, dynamic> toJson() => _$DostignucaToJson(this);
}
