// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnici_dostignuca.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KorisniciDostignuca _$KorisniciDostignucaFromJson(Map<String, dynamic> json) =>
    KorisniciDostignuca(
      (json['id'] as num?)?.toInt(),
      json['dostignuce'] == null
          ? null
          : Dostignuca.fromJson(json['dostignuce'] as Map<String, dynamic>),
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
    );

Map<String, dynamic> _$KorisniciDostignucaToJson(
        KorisniciDostignuca instance) =>
    <String, dynamic>{
      'id': instance.id,
      'dostignuce': instance.dostignuce,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
    };
