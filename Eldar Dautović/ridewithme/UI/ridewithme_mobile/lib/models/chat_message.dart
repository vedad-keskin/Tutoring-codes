// -- chat_message.dart --
import 'package:json_annotation/json_annotation.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';

part 'chat_message.g.dart';

@JsonSerializable()
class ChatMessage {
  int? id;
  String? message;
  Korisnik? sender;
  Korisnik? reciever;
  DateTime? datumKreiranja;

  ChatMessage(
    this.id,
    this.message,
    this.sender,
    this.reciever,
    this.datumKreiranja,
  );

  factory ChatMessage.fromJson(Map<String, dynamic> json) =>
      _$ChatMessageFromJson(json);

  Map<String, dynamic> toJson() => _$ChatMessageToJson(this);
}
