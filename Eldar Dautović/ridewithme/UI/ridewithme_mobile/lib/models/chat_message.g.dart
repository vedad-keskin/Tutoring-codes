// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'chat_message.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ChatMessage _$ChatMessageFromJson(Map<String, dynamic> json) => ChatMessage(
      (json['id'] as num?)?.toInt(),
      json['message'] as String?,
      json['sender'] == null
          ? null
          : Korisnik.fromJson(json['sender'] as Map<String, dynamic>),
      json['reciever'] == null
          ? null
          : Korisnik.fromJson(json['reciever'] as Map<String, dynamic>),
      json['datumKreiranja'] == null
          ? null
          : DateTime.parse(json['datumKreiranja'] as String),
    );

Map<String, dynamic> _$ChatMessageToJson(ChatMessage instance) =>
    <String, dynamic>{
      'id': instance.id,
      'message': instance.message,
      'sender': instance.sender,
      'reciever': instance.reciever,
      'datumKreiranja': instance.datumKreiranja?.toIso8601String(),
    };
