// import 'dart:developer' as developer;
// import 'package:ecommerce_mobile/model/product.dart';
// import 'package:ecommerce_mobile/model/search_result.dart';
// import 'package:ecommerce_mobile/providers/product_provider.dart';

// class LoggedProductProvider extends ProductProvider {
//   @override
//   Future<SearchResult<Product>> get({dynamic filter}) async {
//     developer.log('Starting product fetch request', name: 'LoggedProductProvider');
    
//     try {
//       final startTime = DateTime.now();
//       final result = await super.get(filter: filter);
//       final endTime = DateTime.now();
//       final duration = endTime.difference(startTime);
      
//       developer.log(
//         'Product fetch completed successfully in ${duration.inMilliseconds}ms',
//         name: 'LoggedProductProvider'
//       );
      
      
//       return result;
//     } catch (e) {
//       developer.log(
//         'Product fetch failed with error: $e',
//         name: 'LoggedProductProvider',
//         error: e
//       );
//       rethrow;
//     }
//   }
// }
