// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'poslovni_izvjestaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PoslovniIzvjestaj _$PoslovniIzvjestajFromJson(Map<String, dynamic> json) =>
    PoslovniIzvjestaj(
      (json['godina'] as num?)?.toInt(),
      (json['brojAdministratora'] as num?)?.toInt(),
      (json['brojVoznji'] as num?)?.toInt(),
      (json['brojKorisnika'] as num?)?.toInt(),
      (json['brojKreiranihKupona'] as num?)?.toInt(),
      (json['brojIskoristenihKupona'] as num?)?.toInt(),
      (json['prihodiVozaca'] as num?)?.toDouble(),
    );

Map<String, dynamic> _$PoslovniIzvjestajToJson(PoslovniIzvjestaj instance) =>
    <String, dynamic>{
      'godina': instance.godina,
      'brojAdministratora': instance.brojAdministratora,
      'brojVoznji': instance.brojVoznji,
      'brojKorisnika': instance.brojKorisnika,
      'brojKreiranihKupona': instance.brojKreiranihKupona,
      'brojIskoristenihKupona': instance.brojIskoristenihKupona,
      'prihodiVozaca': instance.prihodiVozaca,
    };
