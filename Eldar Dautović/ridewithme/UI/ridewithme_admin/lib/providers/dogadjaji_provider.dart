import 'package:ridewithme_admin/models/dogadjaj.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

class DogadjajiProvider extends BaseProvider<Dogadjaj> {
  DogadjajiProvider() : super("Dogadjaji");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Dogadjaj.fromJson(data);
  }
}
