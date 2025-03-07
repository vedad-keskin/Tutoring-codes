import 'package:ridewithme_mobile/models/recenzija.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

class RecenzijeProvider extends BaseProvider<Recenzija> {
  RecenzijeProvider() : super("Recenzije");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Recenzija.fromJson(data);
  }
}
