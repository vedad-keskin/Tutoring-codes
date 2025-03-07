import 'dart:convert';

import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

import 'package:http/http.dart' as http;

class KorisnikProvider extends BaseProvider<Korisnik> {
  KorisnikProvider() : super("Korisnici");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Korisnik.fromJson(data);
  }

  Future<Korisnik> login(String username, String password) async {
    var url = "$fullUrl/login?username=${username}&password=${password}";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.post(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      return fromJson(data);
    } else {
      throw new Exception("Unknown error");
    }
  }
}
