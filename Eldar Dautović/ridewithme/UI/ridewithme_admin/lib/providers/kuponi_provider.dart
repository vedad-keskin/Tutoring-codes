import 'dart:convert';

import 'package:ridewithme_admin/models/kupon.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

import 'package:http/http.dart' as http;

class KuponiProvider extends BaseProvider<Kupon> {
  KuponiProvider() : super("Kuponi");

  Future<List<String>> allowedActions(int id) async {
    var url = "$fullUrl/$id/allowedActions";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      List<String> result = [];

      for (var item in data) {
        result.add(item);
      }

      return result;
    } else {
      throw new Exception("Unknown error");
    }
  }

  Future<Kupon> hide(int id) async {
    var url = "$fullUrl/$id/hide";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw new Exception("Unknown error");
    }
  }

  Future<Kupon> activate(int id) async {
    var url = "$fullUrl/$id/activate";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw new Exception("Unknown error");
    }
  }

  Future<Kupon> edit(int id) async {
    var url = "$fullUrl/$id/edit";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
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
