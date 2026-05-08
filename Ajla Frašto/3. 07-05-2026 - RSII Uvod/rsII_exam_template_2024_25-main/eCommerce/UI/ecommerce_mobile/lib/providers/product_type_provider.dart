import 'package:ecommerce_mobile/model/product_type.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';

class ProductTypeProvider extends BaseProvider<ProductType> {
  ProductTypeProvider() : super("productTypes");

  @override
  ProductType fromJson(dynamic json) {
    return ProductType.fromJson(json);
  }
} 