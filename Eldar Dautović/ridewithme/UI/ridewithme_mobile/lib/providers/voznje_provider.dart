import 'dart:convert';

import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class VoznjeProvider extends BaseProvider<Voznja> {
  VoznjeProvider() : super("Voznje");

  Future<Voznja> book(int id, dynamic request) async {
    var url = "$fullUrl/$id/book";
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

  Future<Voznja> start(int id, dynamic request) async {
    var url = "$fullUrl/$id/start";
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

  Future<Voznja> complete(int id, dynamic request) async {
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

  Future<List<Voznja>> recommend(int id) async {
    var url = "$fullUrl/$id/recommend";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      List<Voznja> result = [];

      for (var item in data) {
        result.add(Voznja.fromJson(item));
      }

      return result;
    } else {
      throw new Exception("Unknown error");
    }
  }

  Future<Voznja> hide(int id) async {
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

  Future<Voznja> edit(int id) async {
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

  Future<Voznja> activate(int id) async {
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
    return Voznja.fromJson(data);
  }
}
