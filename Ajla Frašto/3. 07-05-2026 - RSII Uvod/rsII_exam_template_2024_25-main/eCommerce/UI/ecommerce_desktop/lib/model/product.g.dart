// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product(
      id: (json['id'] as num?)?.toInt() ?? 0,
      name: json['name'] as String? ?? '',
      code: json['code'] as String? ?? '',
      productState: json['productState'] as String? ?? 'ActiveProductState',
      price: (json['price'] as num?)?.toDouble() ?? 0,
      unitOfMeasureId: (json['unitOfMeasureId'] as num?)?.toInt(),
      productTypeId: (json['productTypeId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'code': instance.code,
      'productState': instance.productState,
      'price': instance.price,
      'unitOfMeasureId': instance.unitOfMeasureId,
      'productTypeId': instance.productTypeId,
    };
