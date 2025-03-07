// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kupon.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Kupon _$KuponFromJson(Map<String, dynamic> json) => Kupon(
      (json['id'] as num?)?.toInt(),
      json['kod'] as String?,
      json['naziv'] as String?,
      json['datumPocetka'] == null
          ? null
          : DateTime.parse(json['datumPocetka'] as String),
      (json['brojIskoristivosti'] as num?)?.toInt(),
      json['stateMachine'] as String?,
      (json['popust'] as num?)?.toDouble(),
      json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
    );

Map<String, dynamic> _$KuponToJson(Kupon instance) => <String, dynamic>{
      'id': instance.id,
      'kod': instance.kod,
      'naziv': instance.naziv,
      'datumPocetka': instance.datumPocetka?.toIso8601String(),
      'brojIskoristivosti': instance.brojIskoristivosti,
      'stateMachine': instance.stateMachine,
      'popust': instance.popust,
      'korisnik': instance.korisnik,
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
    };
