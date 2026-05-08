import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/cart_provider.dart';
import 'package:ecommerce_mobile/model/cart.dart';
import 'package:ecommerce_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class CartScreen extends StatefulWidget {
  const CartScreen({super.key});

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {
  late CartProvider cartProvider;

  @override
  void initState() {
    super.initState();
    cartProvider = context.read<CartProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Shopping Cart",
      child: Consumer<CartProvider>(
        builder: (context, cartProvider, child) {
          return Center(
            child: Column(
              children: [
                _buildCartHeader(),
                _buildCartItems(),
                _buildCartSummary(),
              ],
            ),
          );
        },
      ),
    );
  }

  Widget _buildCartHeader() {
    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Row(
        children: [
          Icon(Icons.shopping_cart, size: 24),
          SizedBox(width: 8),
          Text(
            "Cart Items (${cartProvider.cart.items.length})",
            style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
          ),
        ],
      ),
    );
  }

  Widget _buildCartItems() {
    if (cartProvider.cart.items.isEmpty) {
      return Expanded(
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Icon(Icons.shopping_cart_outlined, size: 64, color: Colors.grey),
              SizedBox(height: 16),
              Text(
                "Your cart is empty",
                style: TextStyle(fontSize: 18, color: Colors.grey),
              ),
            ],
          ),
        ),
      );
    }

    return Expanded(
      child: ListView.builder(
        itemCount: cartProvider.cart.items.length,
        itemBuilder: (context, index) {
          CartItem item = cartProvider.cart.items[index];
          return _buildCartItemCard(item);
        },
      ),
    );
  }

  Widget _buildCartItemCard(CartItem item) {
    return Card(
      margin: EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      child: Padding(
        padding: EdgeInsets.all(12),
        child: Row(
          children: [
            // Product Image
            Container(
              height: 80,
              width: 80,
              child: item.product.assets.firstOrNull == null 
                ? Placeholder() 
                : imageFromString(item.product.assets.first.base64Content),
            ),
            SizedBox(width: 12),
            // Product Details
            Expanded(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    item.product.name,
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  SizedBox(height: 4),
                  Text(
                    formatNumber(item.product.price),
                    style: TextStyle(
                      fontSize: 14,
                      color: Colors.green,
                      fontWeight: FontWeight.w500,
                    ),
                  ),
                  SizedBox(height: 8),
                  Row(
                    children: [
                      Text("Quantity: "),
                      Text(
                        "${item.count}",
                        style: TextStyle(fontWeight: FontWeight.bold),
                      ),
                    ],
                  ),
                ],
              ),
            ),
            // Actions
                          Column(
              children: [
                Text(
                  formatNumber((item.product.price ?? 0.0) * item.count),
                  style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                    color: Colors.green,
                  ),
                ),
                SizedBox(height: 8),
                IconButton(
                  onPressed: () {
                    cartProvider.removeFromCart(item.product);
                  },
                  icon: Icon(Icons.delete, color: Colors.red),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildCartSummary() {
    if (cartProvider.cart.items.isEmpty) {
      return SizedBox.shrink();
    }

    double total = cartProvider.cart.items
        .map((item) => (item.product.price ?? 0.0) * item.count)
        .reduce((a, b) => a + b);

    return Container(
      padding: EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: Colors.grey[100],
        border: Border(top: BorderSide(color: Colors.grey[300]!)),
      ),
      child: Column(
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                "Total:",
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
              Text(
                formatNumber(total),
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: Colors.green,
                ),
              ),
            ],
          ),
          SizedBox(height: 16),
          SizedBox(
            width: double.infinity,
            child: ElevatedButton(
              onPressed: () {
                // TODO: Implement checkout functionality
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text("Checkout functionality not implemented yet")),
                );
              },
              style: ElevatedButton.styleFrom(
                padding: EdgeInsets.symmetric(vertical: 16),
                backgroundColor: Colors.blue,
                foregroundColor: Colors.white,
              ),
              child: Text(
                "Proceed to Checkout",
                style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
