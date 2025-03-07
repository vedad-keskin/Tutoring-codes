// -- vrsta_zalbe.dart --
import 'package:json_annotation/json_annotation.dart';

part 'vrsta_zalbe.g.dart';

@JsonSerializable()
class VrstaZalbe {
  int? id;
  String? naziv;
  DateTime? datumIzmjene;

  VrstaZalbe(
    this.id,
    this.naziv,
    this.datumIzmjene,
  );

  factory VrstaZalbe.fromJson(Map<String, dynamic> json) =>
      _$VrstaZalbeFromJson(json);

  Map<String, dynamic> toJson() => _$VrstaZalbeToJson(this);
}
