// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dogadjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Dogadjaj _$DogadjajFromJson(Map<String, dynamic> json) => Dogadjaj(
      (json['id'] as num?)?.toInt(),
      json['naziv'] as String?,
      json['opis'] as String?,
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['datumPocetka'] == null
          ? null
          : DateTime.parse(json['datumPocetka'] as String),
      json['datumZavrsetka'] == null
          ? null
          : DateTime.parse(json['datumZavrsetka'] as String),
    );

Map<String, dynamic> _$DogadjajToJson(Dogadjaj instance) => <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'datumPocetka': instance.datumPocetka?.toIso8601String(),
      'datumZavrsetka': instance.datumZavrsetka?.toIso8601String(),
    };
