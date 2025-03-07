import 'dart:convert';

import 'package:ridewithme_mobile/models/kupon.dart';
import 'package:ridewithme_mobile/models/kupon_check.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';

import 'package:http/http.dart' as http;

class KuponiProvider extends BaseProvider<Kupon> {
  KuponiProvider() : super("Kuponi");

  Future<IspravanKupon> check(String kod) async {
    var url = "$fullUrl/check?kod=$kod";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      var kupon = data['kupon'] != null ? Kupon.fromJson(data['kupon']) : null;
      var result = IspravanKupon(data['ispravanKupon'], kupon);

      return result;
    } else {
      throw new Exception("Unknown error");
    }
  }

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Kupon.fromJson(data);
  }
}
