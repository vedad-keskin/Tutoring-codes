import 'package:ridewithme_mobile/models/grad.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

class GradoviProvider extends BaseProvider<Gradovi> {
  GradoviProvider() : super("Gradovi");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Gradovi.fromJson(data);
  }
}
