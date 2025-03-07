// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'uloga.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Uloga _$UlogaFromJson(Map<String, dynamic> json) => Uloga(
      (json['id'] as num?)?.toInt(),
      json['naziv'] as String?,
    );

Map<String, dynamic> _$UlogaToJson(Uloga instance) => <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
    };
