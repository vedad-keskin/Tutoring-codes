import 'package:ridewithme_admin/models/faq.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

class FaqProvider extends BaseProvider<FAQ> {
  FaqProvider() : super("FAQ");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return FAQ.fromJson(data);
  }
}
