import 'package:ridewithme_admin/models/vrsta_zalbe.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

class VrstaZalbeProvider extends BaseProvider<VrstaZalbe> {
  VrstaZalbeProvider() : super("VrstaZalbe");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return VrstaZalbe.fromJson(data);
  }
}
