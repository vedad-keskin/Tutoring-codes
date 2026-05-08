

import 'package:json_annotation/json_annotation.dart';


part 'product.g.dart';
@JsonSerializable()
class Product {
  final int id;
  final String name;
  final String code;
  final String productState;
  final double? price;
  final int? unitOfMeasureId;
  final int? productTypeId;

  Product({
    this.id = 0,
    this.name = '',
    this.code = '',
    this.productState = 'ActiveProductState',
    this.price = 0,
    this.unitOfMeasureId,
    this.productTypeId,
  });

  factory Product.fromJson(Map<String, dynamic> json) => _$ProductFromJson(json);

  // // Factory constructor for creating Product from JSON
  // factory Product.fromJson(Map<String, dynamic> json) {
  //   return Product(
  //     id: json['id'] ?? 0,
  //     name: json['name'] ?? '',
  //     code: json['code'] ?? '',
  //     productState: json['productState'] ?? 'ActiveProductState',
  //   );
  // }

  // // Method to convert Product to JSON
  // Map<String, dynamic> toJson() {
  //   return {
  //     'id': id,
  //     'name': name,
  //     'code': code,
  //     'productState': productState,
  //   };
  // }

  // @override
  // String toString() {
  //   return 'Product{id: $id, name: $name, code: $code, productState: $productState}';
  // }
}
