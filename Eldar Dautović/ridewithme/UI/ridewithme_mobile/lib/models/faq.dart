// -- faq.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';

part 'faq.g.dart';

@JsonSerializable()
class FAQ {
  int? id;
  String? pitanje;
  String? odgovor;
  DateTime? datumKreiranja;
  DateTime? datumIzmjene;
  Korisnik? korisnik;

  FAQ(
    this.id,
    this.pitanje,
    this.odgovor,
    this.datumKreiranja,
    this.datumIzmjene,
    this.korisnik,
  );

  factory FAQ.fromJson(Map<String, dynamic> json) => _$FAQFromJson(json);

  Map<String, dynamic> toJson() => _$FAQToJson(this);
}
