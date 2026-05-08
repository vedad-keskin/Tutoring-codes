// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'unit_of_measure.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UnitOfMeasure _$UnitOfMeasureFromJson(Map<String, dynamic> json) =>
    UnitOfMeasure(
      id: (json['id'] as num?)?.toInt() ?? 0,
      name: json['name'] as String? ?? '',
      description: json['description'] as String? ?? '',
    );

Map<String, dynamic> _$UnitOfMeasureToJson(UnitOfMeasure instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
    };
