import 'dart:convert';

import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:http/http.dart' as http;
import 'package:ecommerce_mobile/providers/auth_provider.dart';

class ProductProvider extends BaseProvider<Product> {
  ProductProvider() : super("product");

  @override
  Product fromJson(dynamic json) {
    return Product.fromJson(json);
  }
}