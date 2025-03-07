// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Korisnik _$KorisnikFromJson(Map<String, dynamic> json) => Korisnik(
      (json['id'] as num?)?.toInt(),
      json['ime'] as String?,
      json['prezime'] as String?,
      json['korisnickoIme'] as String?,
      json['email'] as String?,
      (json['korisniciUloge'] as List<dynamic>?)
          ?.map((e) => KorisnikUloga.fromJson(e as Map<String, dynamic>))
          .toList(),
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
      json['slika'] as String?,
      (json['korisniciDostignuca'] as List<dynamic>?)
          ?.map((e) => KorisniciDostignuca.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$KorisnikToJson(Korisnik instance) => <String, dynamic>{
      'id': instance.id,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'korisnickoIme': instance.korisnickoIme,
      'email': instance.email,
      'korisniciUloge': instance.korisniciUloge,
      'korisniciDostignuca': instance.korisniciDostignuca,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
      'slika': instance.slika,
    };
