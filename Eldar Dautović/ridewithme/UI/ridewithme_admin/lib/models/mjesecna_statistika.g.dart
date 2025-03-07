// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'mjesecna_statistika.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MjesecnaStatistika _$MjesecnaStatistikaFromJson(Map<String, dynamic> json) =>
    MjesecnaStatistika(
      (json['mjesec'] as num?)?.toInt(),
      (json['brojVoznji'] as num?)?.toInt(),
    );

Map<String, dynamic> _$MjesecnaStatistikaToJson(MjesecnaStatistika instance) =>
    <String, dynamic>{
      'mjesec': instance.mjesec,
      'brojVoznji': instance.brojVoznji,
    };
