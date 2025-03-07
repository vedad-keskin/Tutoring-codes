// -- voznja.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_admin/models/dogadjaj.dart';
import 'package:ridewithme_admin/models/grad.dart';
import 'package:ridewithme_admin/models/korisnik.dart';
import 'package:ridewithme_admin/models/kupon.dart';

part 'voznja.g.dart';

@JsonSerializable()
class Voznja {
  int? id;
  String? stateMachine;
  DateTime? datumVrijemePocetka;
  DateTime? datumVrijemeZavrsetka;
  int? ocjena;
  double? cijena;
  String? napomena;
  Gradovi? gradOd;
  Gradovi? gradDo;
  Korisnik? vozac;
  Korisnik? klijent;
  Kupon? kupon;
  Dogadjaj? dogadjaj;

  Voznja(
    this.id,
    this.stateMachine,
    this.datumVrijemePocetka,
    this.datumVrijemeZavrsetka,
    this.ocjena,
    this.cijena,
    this.napomena,
    this.gradOd,
    this.gradDo,
    this.vozac,
    this.klijent,
    this.kupon,
    this.dogadjaj,
  );

  factory Voznja.fromJson(Map<String, dynamic> json) => _$VoznjaFromJson(json);

  Map<String, dynamic> toJson() => _$VoznjaToJson(this);
}
