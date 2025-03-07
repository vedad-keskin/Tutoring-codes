// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vrsta_zalbe.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

VrstaZalbe _$VrstaZalbeFromJson(Map<String, dynamic> json) => VrstaZalbe(
      (json['id'] as num?)?.toInt(),
      json['naziv'] as String?,
      json['datumIzmjene'] == null
          ? null
          : DateTime.parse(json['datumIzmjene'] as String),
    );

Map<String, dynamic> _$VrstaZalbeToJson(VrstaZalbe instance) =>
    <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'datumIzmjene': instance.datumIzmjene?.toIso8601String(),
    };
