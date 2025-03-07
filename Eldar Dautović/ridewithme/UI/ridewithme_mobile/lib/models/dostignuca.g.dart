// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dostignuca.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Dostignuca _$DostignucaFromJson(Map<String, dynamic> json) => Dostignuca(
      (json['id'] as num?)?.toInt(),
      json['naziv'] as String?,
      json['opis'] as String?,
    );

Map<String, dynamic> _$DostignucaToJson(Dostignuca instance) =>
    <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'opis': instance.opis,
    };
