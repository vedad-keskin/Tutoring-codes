import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/cart_provider.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/providers/utils.dart';
import 'package:ecommerce_mobile/screens/product_details_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ecommerce_mobile/providers/product_provider.dart';

class ProductList extends StatefulWidget {
  const ProductList({super.key});

  @override
  State<ProductList> createState() => _ProductListState();
}

class _ProductListState extends State<ProductList> {
  late ProductProvider productProvider;
  late CartProvider cartProvider;

  TextEditingController searchController = TextEditingController();

  SearchResult<Product>? data;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  
  }

  @override
  void initState() {
    super.initState();
    productProvider = context.read<ProductProvider>();
    cartProvider = context.read<CartProvider>();
    loadData();
  }

  void loadData() async {
    var products = await productProvider.get(filter: {
      "code": "",
      "fts": "",
    });
    this.data = products;
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Product List",
      child: Center(
        child: Column(
          children: [
            _buildSearch(),
            _buildResultView()
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
        padding: EdgeInsets.all(10),
        child: Row(
          children: [
            Expanded(
              child: TextField(
                decoration: InputDecoration(
                  hintText: "Search",
                  border: OutlineInputBorder(),
                ),
                controller: searchController,
              ),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () async {
                var filter = {
                  "fts": searchController.text,
                };
                debugPrint(filter.toString());
                var products = await productProvider.get(filter: filter);
                debugPrint(products.items?.firstOrNull?.name);
                this.data = products;
                setState(() {});
              },
              child: Text("Search"),
            ),
            SizedBox(width: 10),
          ],
        ));
  }
  

  Widget _buildResultView() {
    return Expanded(child: Container(
      width: double.infinity,
      child: SingleChildScrollView(
        child: Container(
              height: 500,
              child: GridView(
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 2,
                  childAspectRatio: 4 / 3,
                  crossAxisSpacing: 10,
                  mainAxisSpacing: 30
                ),
                scrollDirection: Axis.horizontal,
                children: _buildProductCardList(),
              ),
            ),
      ),
    ));
  }



    List<Widget> _buildProductCardList() {
    if (data == null || data?.items?.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data!.items!.map((x) => Container(
      child: Column(
        children: [
          Container(
            height: 100,
            width: 100,
            child: x.assets.firstOrNull == null ? Placeholder() : imageFromString(x.assets.first.base64Content),
          ),
          Text(x.name),
          Text(formatNumber(x.price)),
          IconButton(onPressed: () {
              cartProvider?.addToCart(x);
          }, icon: Icon(Icons.shopping_cart))
        ],
      ),
    )).cast<Widget>().toList();
    
    return list;
  }

}
