import 'package:ridewithme_mobile/models/obavjestenje.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

class ObavjestenjaProvider extends BaseProvider<Obavjestenje> {
  ObavjestenjaProvider() : super("Obavjestenje");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Obavjestenje.fromJson(data);
  }
}
