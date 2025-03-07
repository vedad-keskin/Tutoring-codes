import 'dart:convert';

import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/chat_message.dart';
import 'package:ridewithme_mobile/models/korisnik.dart';
import 'package:ridewithme_mobile/providers/chat_provider.dart';
import 'package:ridewithme_mobile/screens/profile_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/chat_bubble.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class ChatScreen extends StatefulWidget {
  Korisnik sender;
  ChatScreen({super.key, required this.sender});

  @override
  State<ChatScreen> createState() => _ChatScreenState();
}

class _ChatScreenState extends State<ChatScreen> {
  late ChatProvider _chatProvider;
  final TextEditingController _messageController = TextEditingController();

  List<ChatMessage>? _messages;

  bool isLoading = true;

  Client client = Client(
      settings: ConnectionSettings(
          host:
              const String.fromEnvironment("mqHost", defaultValue: "10.0.2.2"),
          authProvider: const PlainAuthenticator(
              String.fromEnvironment("mqUsername", defaultValue: "user"),
              String.fromEnvironment("mqPass", defaultValue: "mypass"))));

  @override
  void initState() {
    super.initState();
    _chatProvider = context.read<ChatProvider>();
    initChat();

    checkNotifications();
  }

  @override
  void dispose() {
    super.dispose();
  }

  Future initChat() async {
    _messages = await _chatProvider.conversation(
      Authorization.id ?? 0,
      widget.sender.id ?? 0,
    );

    if (mounted) {
      setState(() {
        isLoading = false;
      });
    }
  }

  Future<void> checkNotifications() async {
    Channel channel = await client.channel();

    Queue queue = await channel.queue("chat");

    var consumer = await queue.consume();

    consumer.listen((AmqpMessage message) {
      if (message.payloadAsJson["RecieverId"] == Authorization.id ||
          message.payloadAsJson["SenderId"] == Authorization.id) {
        if (mounted) {
          setState(() {
            isLoading = true;
          });
          initChat();
        }
      }
    });
  }

  void _sendMessage() async {
    isLoading = true;

    await _chatProvider.send({
      "senderId": widget.sender.id ?? 0,
      "recieverId": Authorization.id,
      "message": _messageController.text
    });

    _messageController.clear();

    initChat();
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 4,
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Stack(
                children: [
                  SingleChildScrollView(
                    child: Column(
                      children: [
                        isLoading
                            ? LoadingSpinnerWidget(height: 500)
                            : _buildChat(context),
                      ],
                    ),
                  ),
                  Positioned(
                    bottom: 0,
                    left: 10,
                    right: 10,
                    child: Container(
                      padding: EdgeInsets.symmetric(horizontal: 10),
                      decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(30),
                        border:
                            Border.all(color: Color(0xFFE1E0E0).withAlpha(200)),
                        boxShadow: [
                          BoxShadow(
                            color: Colors.black.withAlpha(10),
                            blurRadius: 10,
                            offset: Offset(0, 4),
                          ),
                        ],
                      ),
                      child: Row(
                        children: [
                          Expanded(
                            child: TextField(
                              controller: _messageController,
                              decoration: InputDecoration(
                                  fillColor: Colors.white.withAlpha(5),
                                  hintText: 'Pišite ovdje...',
                                  border: InputBorder.none),
                            ),
                          ),
                          IconButton(
                            icon: Icon(Icons.send, color: Color(0xFF7463DE)),
                            onPressed: _sendMessage,
                          ),
                        ],
                      ),
                    ),
                  ),
                  _buildHeader(),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildHeader() {
    return Container(
      margin: EdgeInsets.symmetric(vertical: 20),
      padding: EdgeInsets.all(10),
      child: Row(
        spacing: 10,
        children: [
          GestureDetector(
            onTap: () {
              Navigator.of(context).pop();
            },
            child: Icon(
              Icons.chevron_left,
              size: 25,
            ),
          ),
          Container(
            width: 30,
            height: 30,
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(100),
                border: Border.all(color: Colors.grey)),
            child: widget.sender.slika != null
                ? ClipRRect(
                    borderRadius: BorderRadius.circular(100),
                    child: Image.memory(
                      base64Decode(widget.sender.slika ?? ''),
                      fit: BoxFit.cover,
                    ),
                  )
                : Icon(
                    Icons.account_circle,
                    size: 25,
                    color: Colors.blueGrey,
                  ),
          ),
          Text("${widget.sender.ime ?? ""} ${widget.sender.prezime}")
        ],
      ),
    );
  }

  Widget _buildChat(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(left: 20, right: 20, top: 90, bottom: 50),
      width: double.infinity,
      height: MediaQuery.of(context).size.height - 220,
      child: SingleChildScrollView(
        child: Column(
          spacing: 10,
          children: _messages?.map((element) {
                return Row(
                  mainAxisAlignment: element.reciever?.id == Authorization.id
                      ? MainAxisAlignment.end
                      : MainAxisAlignment.start,
                  children: [
                    ChatBubble(poruka: element),
                  ],
                );
              }).toList() ??
              [],
        ),
      ),
    );
  }
}
