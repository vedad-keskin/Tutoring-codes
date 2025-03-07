// -- ukupna_statistika.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/mjesecna_statistika.dart';
import 'package:ridewithme_mobile/models/statistika.dart';

part 'ukupna_statistika.g.dart';

@JsonSerializable()
class UkupnaStatistika {
  List<MjesecnaStatistika>? mjesecnaStatistika;
  Statistika? statistika;

  UkupnaStatistika(
    this.mjesecnaStatistika,
    this.statistika,
  );

  factory UkupnaStatistika.fromJson(Map<String, dynamic> json) =>
      _$UkupnaStatistikaFromJson(json);

  Map<String, dynamic> toJson() => _$UkupnaStatistikaToJson(this);
}
