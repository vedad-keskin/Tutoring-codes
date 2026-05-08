import 'package:ecommerce_desktop/model/unit_of_measure.dart';
import 'package:ecommerce_desktop/providers/base_provider.dart';

class UnitOfMeasureProvider extends BaseProvider<UnitOfMeasure> {
  UnitOfMeasureProvider() : super("unitOfMeasure");

  @override
  UnitOfMeasure fromJson(dynamic json) {
    return UnitOfMeasure.fromJson(json);
  }
}
