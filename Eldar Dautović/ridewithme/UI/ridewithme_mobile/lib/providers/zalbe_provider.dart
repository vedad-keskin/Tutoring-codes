import 'package:ridewithme_mobile/models/zalba.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

class ZalbeProvider extends BaseProvider<Zalba> {
  ZalbeProvider() : super("Zalbe");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Zalba.fromJson(data);
  }
}
