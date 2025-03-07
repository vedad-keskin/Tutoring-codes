import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

class GradoviProvider extends BaseProvider<Gradovi> {
  GradoviProvider() : super("Gradovi");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Gradovi.fromJson(data);
  }
}
