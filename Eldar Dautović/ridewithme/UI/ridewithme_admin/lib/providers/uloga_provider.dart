import 'package:ridewithme_admin/models/uloga.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

class UlogaProvider extends BaseProvider<Uloga> {
  UlogaProvider() : super("Uloge");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Uloga.fromJson(data);
  }
}
