import 'package:ridewithme_mobile/models/faq.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

class FaqProvider extends BaseProvider<FAQ> {
  FaqProvider() : super("FAQ");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return FAQ.fromJson(data);
  }
}
