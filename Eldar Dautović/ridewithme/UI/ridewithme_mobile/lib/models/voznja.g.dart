// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'voznja.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Voznja _$VoznjaFromJson(Map<String, dynamic> json) => Voznja(
      (json['id'] as num?)?.toInt(),
      json['stateMachine'] as String?,
      json['datumVrijemePocetka'] == null
          ? null
          : DateTime.parse(json['datumVrijemePocetka'] as String),
      json['datumVrijemeZavrsetka'] == null
          ? null
          : DateTime.parse(json['datumVrijemeZavrsetka'] as String),
      (json['ocjena'] as num?)?.toInt(),
      (json['cijena'] as num?)?.toDouble(),
      json['napomena'] as String?,
      json['gradOd'] == null
          ? null
          : Gradovi.fromJson(json['gradOd'] as Map<String, dynamic>),
      json['gradDo'] == null
          ? null
          : Gradovi.fromJson(json['gradDo'] as Map<String, dynamic>),
      json['vozac'] == null
          ? null
          : Korisnik.fromJson(json['vozac'] as Map<String, dynamic>),
      json['klijent'] == null
          ? null
          : Korisnik.fromJson(json['klijent'] as Map<String, dynamic>),
      json['kupon'] == null
          ? null
          : Kupon.fromJson(json['kupon'] as Map<String, dynamic>),
      json['dogadjaj'] == null
          ? null
          : Dogadjaj.fromJson(json['dogadjaj'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$VoznjaToJson(Voznja instance) => <String, dynamic>{
      'id': instance.id,
      'stateMachine': instance.stateMachine,
      'datumVrijemePocetka': instance.datumVrijemePocetka?.toIso8601String(),
      'datumVrijemeZavrsetka':
          instance.datumVrijemeZavrsetka?.toIso8601String(),
      'ocjena': instance.ocjena,
      'cijena': instance.cijena,
      'napomena': instance.napomena,
      'gradOd': instance.gradOd,
      'gradDo': instance.gradDo,
      'vozac': instance.vozac,
      'klijent': instance.klijent,
      'kupon': instance.kupon,
      'dogadjaj': instance.dogadjaj,
    };
