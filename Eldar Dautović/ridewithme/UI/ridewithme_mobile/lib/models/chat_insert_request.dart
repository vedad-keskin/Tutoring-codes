// -- chat_insert_request.dart --
import 'package:json_annotation/json_annotation.dart';

part 'chat_insert_request.g.dart';

@JsonSerializable()
class ChatInsertRequest {
  int? senderId;
  int? recieverId;
  String? message;

  ChatInsertRequest(
    this.senderId,
    this.recieverId,
    this.message,
  );

  factory ChatInsertRequest.fromJson(Map<String, dynamic> json) =>
      _$ChatInsertRequestFromJson(json);

  Map<String, dynamic> toJson() => _$ChatInsertRequestToJson(this);
}
