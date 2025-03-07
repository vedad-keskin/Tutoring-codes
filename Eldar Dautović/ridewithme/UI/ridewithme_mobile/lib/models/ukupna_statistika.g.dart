// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ukupna_statistika.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UkupnaStatistika _$UkupnaStatistikaFromJson(Map<String, dynamic> json) =>
    UkupnaStatistika(
      (json['mjesecnaStatistika'] as List<dynamic>?)
          ?.map((e) => MjesecnaStatistika.fromJson(e as Map<String, dynamic>))
          .toList(),
      json['statistika'] == null
          ? null
          : Statistika.fromJson(json['statistika'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$UkupnaStatistikaToJson(UkupnaStatistika instance) =>
    <String, dynamic>{
      'mjesecnaStatistika': instance.mjesecnaStatistika,
      'statistika': instance.statistika,
    };
