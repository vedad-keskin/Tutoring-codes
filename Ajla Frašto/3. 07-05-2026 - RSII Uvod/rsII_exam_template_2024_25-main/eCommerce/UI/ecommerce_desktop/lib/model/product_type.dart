import 'package:json_annotation/json_annotation.dart';

part 'product_type.g.dart';

@JsonSerializable()
class ProductType {
  final int id;
  final String name;
  final String description;
  final bool isActive;
  final DateTime? createdAt;
  final DateTime? updatedAt;

  ProductType({
    this.id = 0,
    this.name = '',
    this.description = '',
    this.isActive = true,
    this.createdAt,
    this.updatedAt,
  });

  factory ProductType.fromJson(Map<String, dynamic> json) => _$ProductTypeFromJson(json);

  Map<String, dynamic> toJson() => _$ProductTypeToJson(this);
} 