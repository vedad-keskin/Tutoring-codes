import 'package:ecommerce_mobile/model/cart.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:flutter/widgets.dart';
import 'package:collection/collection.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Product product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Product product) {
    cart.items.removeWhere((item) => item.product.id == product.id);
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.id == product.id);
    return item;
  }
}