import 'package:ridewithme_admin/models/reklama.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

class ReklameProvider extends BaseProvider<Reklama> {
  ReklameProvider() : super("Reklame");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Reklama.fromJson(data);
  }
}
