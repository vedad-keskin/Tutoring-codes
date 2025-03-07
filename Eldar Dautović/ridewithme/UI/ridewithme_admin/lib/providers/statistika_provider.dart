import 'dart:convert';

import 'package:ridewithme_admin/models/poslovni_izvjestaj.dart';
import 'package:ridewithme_admin/models/statistika.dart';
import 'package:ridewithme_admin/models/ukupna_statistika.dart';
import 'package:ridewithme_admin/providers/base_provider.dart';

import 'package:http/http.dart' as http;

class StatistikaProvider extends BaseProvider<Statistika> {
  StatistikaProvider() : super("Statistika");

  Future<UkupnaStatistika> monthly() async {
    var url = "$fullUrl/monthly";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      return UkupnaStatistika.fromJson(data);
    } else {
      throw new Exception("Unknown error");
    }
  }

  Future<List<PoslovniIzvjestaj>> getBusinessReport() async {
    var url = "$fullUrl/business";

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      var result = <PoslovniIzvjestaj>[];

      for (var item in data) {
        result.add(PoslovniIzvjestaj.fromJson(item));
      }

      return result;
    } else {
      throw new Exception("Unknown error");
    }
  }

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Statistika.fromJson(data);
  }
}
