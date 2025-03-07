// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'statistika.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Statistika _$StatistikaFromJson(Map<String, dynamic> json) => Statistika(
      (json['brojRegistrovanihKorisnika'] as num?)?.toInt(),
      (json['brojIskoristenihKupona'] as num?)?.toInt(),
      (json['brojKreiranihVoznji'] as num?)?.toInt(),
      (json['brojVozaca'] as num?)?.toInt(),
      (json['brojZakazanihVoznji'] as num?)?.toInt(),
    );

Map<String, dynamic> _$StatistikaToJson(Statistika instance) =>
    <String, dynamic>{
      'brojRegistrovanihKorisnika': instance.brojRegistrovanihKorisnika,
      'brojIskoristenihKupona': instance.brojIskoristenihKupona,
      'brojKreiranihVoznji': instance.brojKreiranihVoznji,
      'brojVozaca': instance.brojVozaca,
      'brojZakazanihVoznji': instance.brojZakazanihVoznji,
    };
