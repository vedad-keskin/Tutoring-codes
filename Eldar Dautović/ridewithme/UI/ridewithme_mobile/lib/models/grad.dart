// -- gradovi.dart --
import 'package:json_annotation/json_annotation.dart';

part 'grad.g.dart';

@JsonSerializable()
class Gradovi {
  int? id;
  String? naziv;
  double? longitude;
  double? latitude;

  Gradovi(
    this.id,
    this.naziv,
    this.longitude,
    this.latitude,
  );

  factory Gradovi.fromJson(Map<String, dynamic> json) =>
      _$GradoviFromJson(json);

  Map<String, dynamic> toJson() => _$GradoviToJson(this);
}
