// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik_uloga.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KorisnikUloga _$KorisnikUlogaFromJson(Map<String, dynamic> json) =>
    KorisnikUloga(
      (json['id'] as num?)?.toInt(),
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
      json['uloga'] == null
          ? null
          : Uloga.fromJson(json['uloga'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$KorisnikUlogaToJson(KorisnikUloga instance) =>
    <String, dynamic>{
      'id': instance.id,
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
      'uloga': instance.uloga,
    };
