import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:ridewithme_mobile/models/chat_message.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';

class ChatBubble extends StatelessWidget {
  const ChatBubble({super.key, required this.poruka});

  final ChatMessage poruka;

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.end,
      children: [
        Row(
          children: [
            if (poruka.reciever?.id != Authorization.id) ...[
              Container(
                width: 30,
                height: 30,
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(100),
                    border: Border.all(color: Colors.grey)),
                child: poruka.reciever?.slika != null
                    ? ClipRRect(
                        borderRadius: BorderRadius.circular(100),
                        child: Image.memory(
                          base64Decode(poruka.reciever!.slika ?? ''),
                          fit: BoxFit.cover,
                        ),
                      )
                    : Icon(
                        Icons.account_circle,
                        size: 25,
                        color: Colors.blueGrey,
                      ),
              ),
            ],
            SizedBox(
              width: 5,
            ),
            Container(
              constraints: BoxConstraints(maxWidth: 250),
              decoration: BoxDecoration(
                  color: poruka.reciever?.id == Authorization.id
                      ? Color(0xFF39D5C3).withAlpha(50)
                      : Color(0xFFBEBEBE).withAlpha(50),
                  borderRadius: poruka.reciever?.id == Authorization.id
                      ? BorderRadius.only(
                          topLeft: Radius.circular(15),
                          bottomLeft: Radius.circular(15),
                          bottomRight: Radius.circular(15),
                          topRight: Radius.circular(0))
                      : BorderRadius.only(
                          topLeft: Radius.circular(0),
                          bottomLeft: Radius.circular(15),
                          bottomRight: Radius.circular(15),
                          topRight: Radius.circular(15))),
              child: Padding(
                padding: const EdgeInsets.all(10.0),
                child: Text(
                  poruka.message ?? '',
                  style: TextStyle(
                      color: Colors.black, fontSize: 15, fontFamily: "Inter"),
                ),
              ),
            ),
          ],
        ),
        Row(
          crossAxisAlignment: CrossAxisAlignment.end,
          children: [
            Text(
              "${DateFormat("dd.MM.yyyy u HH:mm").format(poruka.datumKreiranja ?? DateTime.now())}",
              style: TextStyle(
                  color: Colors.black, fontSize: 11, fontFamily: "Inter"),
            ),
          ],
        )
      ],
    );
  }
}
