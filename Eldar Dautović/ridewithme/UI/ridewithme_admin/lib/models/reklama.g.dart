// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reklama.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reklama _$ReklamaFromJson(Map<String, dynamic> json) => Reklama(
      (json['id'] as num?)?.toInt(),
      json['nazivKlijenta'] as String?,
      json['nazivKampanje'] as String?,
      json['sadrzajKampanje'] as String?,
      json['slika'] as String?,
      json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
    );

Map<String, dynamic> _$ReklamaToJson(Reklama instance) => <String, dynamic>{
      'id': instance.id,
      'nazivKlijenta': instance.nazivKlijenta,
      'nazivKampanje': instance.nazivKampanje,
      'sadrzajKampanje': instance.sadrzajKampanje,
      'slika': instance.slika,
      'korisnik': instance.korisnik,
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
    };
