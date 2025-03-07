// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'faq.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FAQ _$FAQFromJson(Map<String, dynamic> json) => FAQ(
      (json['id'] as num?)?.toInt(),
      json['pitanje'] as String?,
      json['odgovor'] as String?,
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$FAQToJson(FAQ instance) => <String, dynamic>{
      'id': instance.id,
      'pitanje': instance.pitanje,
      'odgovor': instance.odgovor,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'korisnik': instance.korisnik,
    };
