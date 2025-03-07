// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'obavjestenje.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Obavjestenje _$ObavjestenjeFromJson(Map<String, dynamic> json) => Obavjestenje(
      (json['id'] as num?)?.toInt(),
      json['stateMachine'] as String?,
      json['naslov'] as String?,
      json['podnaslov'] as String?,
      json['opis'] as String?,
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['datumZavrsetka'] == null
          ? null
          : DateTime.parse(json['datumZavrsetka'] as String),
      json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$ObavjestenjeToJson(Obavjestenje instance) =>
    <String, dynamic>{
      'id': instance.id,
      'stateMachine': instance.stateMachine,
      'naslov': instance.naslov,
      'podnaslov': instance.podnaslov,
      'opis': instance.opis,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'datumZavrsetka': instance.datumZavrsetka?.toIso8601String(),
      'korisnik': instance.korisnik,
    };
