// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'zalba.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Zalba _$ZalbaFromJson(Map<String, dynamic> json) => Zalba(
      (json['id'] as num?)?.toInt(),
      json['naslov'] as String?,
      json['sadrzaj'] as String?,
      json['odgovorNaZalbu'] as String?,
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['datumPreuzimanja'] == null
          ? null
          : DateTime.parse(json['datumPreuzimanja'] as String),
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
      json['stateMachine'] as String?,
      json['vrstaZalbe'] == null
          ? null
          : VrstaZalbe.fromJson(json['vrstaZalbe'] as Map<String, dynamic>),
      json['administrator'] == null
          ? null
          : Korisnik.fromJson(json['administrator'] as Map<String, dynamic>),
      json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$ZalbaToJson(Zalba instance) => <String, dynamic>{
      'id': instance.id,
      'naslov': instance.naslov,
      'sadrzaj': instance.sadrzaj,
      'odgovorNaZalbu': instance.odgovorNaZalbu,
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'datumPreuzimanja': instance.datumPreuzimanja?.toIso8601String(),
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
      'stateMachine': instance.stateMachine,
      'vrstaZalbe': instance.vrstaZalbe,
      'administrator': instance.administrator,
      'korisnik': instance.korisnik,
    };
