
import 'package:ecommerce_mobile/model/product.dart';

class Cart {
    List<CartItem> items = [];
}

class CartItem {
  CartItem(this.product, this.count);
  late Product product;
  late int count;
}