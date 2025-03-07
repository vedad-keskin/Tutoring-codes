import 'package:ridewithme_mobile/models/vrsta_zalbe.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

class VrsteZalbeProvider extends BaseProvider<VrstaZalbe> {
  VrsteZalbeProvider() : super("VrstaZalbe");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return VrstaZalbe.fromJson(data);
  }
}
