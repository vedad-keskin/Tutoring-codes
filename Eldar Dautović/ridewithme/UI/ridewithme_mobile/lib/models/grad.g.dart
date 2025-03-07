// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'grad.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Gradovi _$GradoviFromJson(Map<String, dynamic> json) => Gradovi(
      (json['id'] as num?)?.toInt(),
      json['naziv'] as String?,
      (json['longitude'] as num?)?.toDouble(),
      (json['latitude'] as num?)?.toDouble(),
    );

Map<String, dynamic> _$GradoviToJson(Gradovi instance) => <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'longitude': instance.longitude,
      'latitude': instance.latitude,
    };
