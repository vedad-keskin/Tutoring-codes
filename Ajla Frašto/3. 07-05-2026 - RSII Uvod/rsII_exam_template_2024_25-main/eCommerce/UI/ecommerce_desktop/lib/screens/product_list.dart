import 'package:ecommerce_desktop/layouts/master_screen.dart';
import 'package:ecommerce_desktop/model/product.dart';
import 'package:ecommerce_desktop/model/search_result.dart';
import 'package:ecommerce_desktop/providers/utils.dart';
import 'package:ecommerce_desktop/screens/product_details_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ecommerce_desktop/providers/product_provider.dart';

class ProductList extends StatefulWidget {
  const ProductList({super.key});

  @override
  State<ProductList> createState() => _ProductListState();
}

class _ProductListState extends State<ProductList> {
  late ProductProvider productProvider;

  TextEditingController codeController = TextEditingController();
  TextEditingController searchController = TextEditingController();

  SearchResult<Product>? products;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    productProvider = context.read<ProductProvider>();
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
                  hintText: "Code",
                  border: OutlineInputBorder(),
                ),
                controller: codeController,
              ),
            ),
            SizedBox(width: 10),
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
                  "code": codeController.text,
                  "fts": searchController.text,
                };
                debugPrint(filter.toString());
                var products = await productProvider.get(filter: filter);
                debugPrint(products.items?.firstOrNull?.name);
                this.products = products;
                setState(() {});
              },
              child: Text("Search"),
            ),
            SizedBox(width: 10),
            ElevatedButton(
              onPressed: () {
                Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDetailsScreen(product: null)));
              },
              child: Text("New"),
            )
          ],
        ));
  }
  

  Widget _buildResultView() {
    return Expanded(child: Container(
      width: double.infinity,
      child: SingleChildScrollView(
        child: DataTable(
        columns: [
          DataColumn(label: Text("Code")),
          DataColumn(label: Text("Name")),
          DataColumn(label: Text("State")), 
          DataColumn(label: Text("Price")),
        ],
        rows: products?.items?.map((e) => DataRow(
          onSelectChanged: (value) {
            Navigator.push(context, MaterialPageRoute(builder: (context) => ProductDetailsScreen(product: e)));
          },
          cells: [
            DataCell(Text(e.code)),
            DataCell(Text(e.name)),
            DataCell(Text(e.productState)),
            DataCell(Text(formatNumber(e.price))),
          ])).toList() ?? [],
      ),
      ),
    ));
  }

}
