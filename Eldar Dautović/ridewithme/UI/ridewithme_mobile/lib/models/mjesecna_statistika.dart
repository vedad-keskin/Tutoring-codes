// -- mjesecna_statistika.dart --
import 'package:json_annotation/json_annotation.dart';

part 'mjesecna_statistika.g.dart';

@JsonSerializable()
class MjesecnaStatistika {
  int? mjesec;
  int? brojVoznji;

  MjesecnaStatistika(
    this.mjesec,
    this.brojVoznji,
  );

  factory MjesecnaStatistika.fromJson(Map<String, dynamic> json) =>
      _$MjesecnaStatistikaFromJson(json);

  Map<String, dynamic> toJson() => _$MjesecnaStatistikaToJson(this);
}
