// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'recenzija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Recenzija _$RecenzijaFromJson(Map<String, dynamic> json) => Recenzija(
      (json['id'] as num?)?.toInt(),
      (json['ocjena'] as num?)?.toInt(),
      json['komentar'] as String?,
      json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
      json['voznja'] == null
          ? null
          : Voznja.fromJson(json['voznja'] as Map<String, dynamic>),
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
    );

Map<String, dynamic> _$RecenzijaToJson(Recenzija instance) => <String, dynamic>{
      'id': instance.id,
      'ocjena': instance.ocjena,
      'komentar': instance.komentar,
      'korisnik': instance.korisnik,
      'voznja': instance.voznja,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
    };
