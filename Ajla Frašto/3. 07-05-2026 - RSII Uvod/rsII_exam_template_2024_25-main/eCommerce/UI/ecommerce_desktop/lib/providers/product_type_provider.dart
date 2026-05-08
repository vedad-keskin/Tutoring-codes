import 'package:ecommerce_desktop/model/product_type.dart';
import 'package:ecommerce_desktop/providers/base_provider.dart';

class ProductTypeProvider extends BaseProvider<ProductType> {
  ProductTypeProvider() : super("productTypes");

  @override
  ProductType fromJson(dynamic json) {
    return ProductType.fromJson(json);
  }
} 