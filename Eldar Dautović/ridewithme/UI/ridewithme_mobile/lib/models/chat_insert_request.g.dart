// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'chat_insert_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ChatInsertRequest _$ChatInsertRequestFromJson(Map<String, dynamic> json) =>
    ChatInsertRequest(
      (json['senderId'] as num?)?.toInt(),
      (json['recieverId'] as num?)?.toInt(),
      json['message'] as String?,
    );

Map<String, dynamic> _$ChatInsertRequestToJson(ChatInsertRequest instance) =>
    <String, dynamic>{
      'senderId': instance.senderId,
      'recieverId': instance.recieverId,
      'message': instance.message,
    };
