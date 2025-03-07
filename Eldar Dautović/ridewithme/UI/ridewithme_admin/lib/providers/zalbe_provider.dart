import 'dart:convert';

import 'package:ridewithme_admin/models/zalba.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

import 'package:http/http.dart' as http;

class ZalbaProvider extends BaseProvider<Zalba> {
  ZalbaProvider() : super("Zalbe");

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

  Future<Zalba> process(int id) async {
    var url = "$fullUrl/$id/process";
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

  Future<Zalba> activate(int id) async {
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

  Future<Zalba> complete(int id, dynamic request) async {
    var url = "$fullUrl/$id/complete";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var jsonRequest = jsonEncode(request);
    var response = await http.put(uri, headers: headers, body: jsonRequest);

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
    return Zalba.fromJson(data);
  }
}
