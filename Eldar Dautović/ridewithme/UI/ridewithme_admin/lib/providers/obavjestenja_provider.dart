import 'dart:convert';

import 'package:ridewithme_admin/models/obavjestenje.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class ObavjestenjaProvider extends BaseProvider<Obavjestenje> {
  ObavjestenjaProvider() : super("Obavjestenje");

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

  Future<Obavjestenje> hide(int id) async {
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

  Future<Obavjestenje> edit(int id) async {
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

  Future<Obavjestenje> complete(int id) async {
    var url = "$fullUrl/$id/complete";
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

  Future<Obavjestenje> activate(int id) async {
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

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Obavjestenje.fromJson(data);
  }
}
