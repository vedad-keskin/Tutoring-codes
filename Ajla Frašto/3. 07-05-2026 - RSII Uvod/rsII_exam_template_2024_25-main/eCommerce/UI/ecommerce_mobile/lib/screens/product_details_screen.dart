import 'dart:convert';
import 'dart:io';

import 'package:ecommerce_mobile/layouts/master_screen.dart';
import 'package:ecommerce_mobile/model/product.dart';
import 'package:ecommerce_mobile/model/product_type.dart';
import 'package:ecommerce_mobile/model/search_result.dart';
import 'package:ecommerce_mobile/model/unit_of_measure.dart';
import 'package:ecommerce_mobile/providers/product_provider.dart';
import 'package:ecommerce_mobile/providers/product_type_provider.dart';
import 'package:ecommerce_mobile/providers/unit_of_measure_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
// import 'package:file_picker/file_picker.dart';

class ProductDetailsScreen extends StatefulWidget {
  Product? product;
  ProductDetailsScreen({super.key, this.product});

  @override
  State<ProductDetailsScreen> createState() => _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {
  final formKey = GlobalKey<FormBuilderState>();

  Map<String, dynamic> _initalValue = {};

  late ProductProvider productProvider;
  late UnitOfMeasureProvider unitOfMeasureProvider;
  late ProductTypeProvider productTypeProvider;

  SearchResult<UnitOfMeasure>? unitOfMeasures;
  SearchResult<ProductType>? productTypes;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    productProvider = Provider.of<ProductProvider>(context, listen: false);
    unitOfMeasureProvider =
        Provider.of<UnitOfMeasureProvider>(context, listen: false);
    productTypeProvider =
        Provider.of<ProductTypeProvider>(context, listen: false);

    _initalValue = {
      "name": widget.product?.name,
      "code": widget.product?.code,
      "unitOfMeasureId": widget.product?.unitOfMeasureId,
      "productTypeId": widget.product?.productTypeId,
      "price": widget.product?.price?.toString(),
    };
    print("widget.product");
    print(_initalValue);

    initFormData();
  }

  initFormData() async {
    unitOfMeasures = await unitOfMeasureProvider.get();
    productTypes = await productTypeProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      title: "Product Details",
      child: Column(children: [
        _buildForm(),
        _buildSaveButton()
      ],),
    );
  }

  Widget _buildSaveButton() {
    return ElevatedButton(
      onPressed: () async {
        formKey.currentState?.saveAndValidate();
        if (formKey.currentState?.validate() ?? false) {
          print(formKey.currentState?.value.toString());
          var request = Map.from(formKey.currentState?.value ?? {});
          if (widget.product == null) {
            widget.product = await productProvider.insert(request);
          } else {
            widget.product = await productProvider.update(widget.product!.id, request);
          }
        }
      },
      child: Text("Save"),
    );
  }
  
  File? _image;
  String? _base64Image;

  Widget _buildForm() {
    if (isLoading) {
      return Center(child: CircularProgressIndicator());
    }

    return FormBuilder(
        key: formKey,
        initialValue: _initalValue,
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: [
              FormBuilderTextField(
                name: "name",
                decoration: InputDecoration(labelText: "Name"),
              ),
              FormBuilderTextField(
                name: "code",
                decoration: InputDecoration(labelText: "Code"),
              ),
              Row(
                children: [
                  Expanded(
                      child: FormBuilderDropdown(
                    name: "unitOfMeasureId",
                    decoration: InputDecoration(labelText: "Unit of Measure"),
                    items: unitOfMeasures?.items
                            ?.map((e) => DropdownMenuItem(
                                value: e.id, child: Text(e.name)))
                            .toList() ??
                        [],
                  )),
                  Expanded(
                      child: FormBuilderDropdown(
                    name: "productTypeId",
                    decoration: InputDecoration(labelText: "Product Type"),
                    items: productTypes?.items
                            ?.map((e) => DropdownMenuItem(
                                value: e.id, child: Text(e.name)))
                            .toList() ??
                        [],
                  ))
                ],
              ),
              FormBuilderTextField(
                name: "price",
                decoration: InputDecoration(labelText: "Price"),
              ),
              // Row(
              //   children: [
              //     Expanded(
              //         child: FormBuilderField(
              //             name: "image",
              //             builder: (FormFieldState<dynamic> field) {
              //               return TextButton(
              //                 onPressed: () async {
              //                   FilePickerResult? result =
              //                       await FilePicker.platform.pickFiles();
              //                   if (result != null) {
              //                     _image = File(result.files.single.path!);
              //                     _base64Image = base64Encode(_image!.readAsBytesSync());
              //                   }
              //                 },
              //                 child: Text("Upload Image"),
              //               );
              //             }))
              //   ],
              // )
            ],
          ),
        ));
  }
}
