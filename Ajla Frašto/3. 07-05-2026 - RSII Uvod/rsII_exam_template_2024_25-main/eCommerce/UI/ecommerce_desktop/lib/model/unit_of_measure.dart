import 'package:json_annotation/json_annotation.dart';

part 'unit_of_measure.g.dart';

@JsonSerializable()
class UnitOfMeasure {
  final int id;
  final String name;
  final String description;

  UnitOfMeasure({
    this.id = 0,
    this.name = '',
    this.description = '',
  });

  factory UnitOfMeasure.fromJson(Map<String, dynamic> json) => _$UnitOfMeasureFromJson(json);

  Map<String, dynamic> toJson() => _$UnitOfMeasureToJson(this);
} 