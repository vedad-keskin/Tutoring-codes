import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/screens/achievements_screen.dart';
import 'package:ridewithme_mobile/screens/edit_profile_screen.dart';
import 'package:ridewithme_mobile/screens/faq_screen.dart';
import 'package:ridewithme_mobile/screens/login_screen.dart';
import 'package:ridewithme_mobile/screens/traveler_rides_screen.dart';
import 'package:ridewithme_mobile/screens/your_rides_screen.dart';
import 'package:ridewithme_mobile/screens/zalbe_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({super.key});

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  void logoutUser() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Odjava"),
          content: Text("Da li ste sigurni da želite da se odjavite?"),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text("Ne"),
            ),
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
                Authorization.password = null;
                Authorization.username = null;

                Navigator.of(context).pushReplacement(
                  MaterialPageRoute(
                    builder: (context) => LoginPage(),
                  ),
                );

                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(
                    behavior: SnackBarBehavior.floating,
                    content: Text("Uspješno ste se odjavili."),
                  ),
                );
              },
              child: Text("Da"),
            ),
          ],
        );
      },
    );
  }

  final List<Map<String, dynamic>> segmentedOptions = [
    {
      'segmentTitle': 'O vama',
      'options': [
        {
          'title': 'Vaše vožnje',
          'icon': Icons.directions_car_filled_rounded,
          'route': YourRidesScreen(),
          'iconColor': Color(0xFF39D5C3)
        },
        {
          'title': 'Vožnje u kojima ste (bili) putnici',
          'icon': Icons.airport_shuttle_rounded,
          'route': TravelerRidesScreen(),
          'iconColor': Color(0xFF7463DE)
        },
        {
          'title': 'Dostignuća',
          'icon': Icons.emoji_events_rounded,
          'route': AchievementsScreen(),
          'iconColor': Color(0xFF7463DE)
        },
      ]
    },
    {
      'segmentTitle': 'Postavke',
      'options': [
        {
          'title': 'Uredi profil',
          'icon': Icons.edit_rounded,
          'iconColor': Color(0xFFE98CD2),
          'route': EditProfileScreen(),
        },
        {
          'title': 'Žalbe',
          'icon': Icons.support_rounded,
          'iconColor': Colors.blue,
          'route': ZalbeScreen(),
        },
        {
          'title': 'FAQ',
          'icon': Icons.question_answer_rounded,
          'iconColor': Colors.indigoAccent,
          'route': FaqScreen(),
        },
        {
          'title': 'Odjava',
          'icon': Icons.logout_rounded,
          'iconColor': Color(0xFFE14040),
        },
      ]
    },
  ];

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
        selectedIndex: 4,
        header: "Profil",
        headerDescription: "Ovdje možete da pregledate i uredite vaš profil",
        headerColor: Color(0xFF39D5C3),
        headerTextColor: Colors.black,
        child: Flexible(
          child: SingleChildScrollView(
            child: Column(
              children: [_buildOverview(), _buildSegments()],
            ),
          ),
        ));
  }

  Widget _buildOverview() {
    return Container(
      margin: const EdgeInsets.symmetric(horizontal: 20),
      decoration: BoxDecoration(
          color: Color(0xFF7463DE).withAlpha(60),
          borderRadius: BorderRadius.circular(15)),
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 25, vertical: 15),
        child: Row(
          spacing: 15,
          children: [
            Container(
                width: 80,
                height: 80,
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(100)),
                child: Authorization.slika != null
                    ? ClipRRect(
                        borderRadius: BorderRadius.circular(100),
                        child: Image.memory(
                          base64Decode(Authorization.slika ?? ''),
                          fit: BoxFit.cover,
                        ),
                      )
                    : Icon(
                        Icons.account_circle,
                        size: 40,
                        color: Colors.blueGrey,
                      )),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              spacing: 8,
              children: [
                Text(
                  Authorization.fullName ?? '',
                  style: TextStyle(
                      fontSize: 17,
                      fontWeight: FontWeight.w800,
                      color: Color(0xFF072220),
                      fontFamily: "Inter"),
                ),
                Text(
                  Authorization.email ?? '',
                  style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.w500,
                      color: Colors.grey,
                      decoration: TextDecoration.underline,
                      fontFamily: "Inter"),
                ),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => EditProfileScreen()),
                    );
                  },
                  child: Row(
                    children: [
                      Text(
                        "Uredi profil",
                        style: TextStyle(
                            fontSize: 14,
                            fontWeight: FontWeight.w500,
                            color: Color(0xFF072220),
                            fontFamily: "Inter"),
                      ),
                      Icon(
                        Icons.chevron_right_rounded,
                        color: Color(0xFF072220),
                      )
                    ],
                  ),
                ),
              ],
            )
          ],
        ),
      ),
    );
  }

  Widget _buildSegments() {
    return Column(
      children: segmentedOptions.map((segment) {
        return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 20),
              child: Text(
                segment['segmentTitle'].toString().toUpperCase(),
                style: TextStyle(
                  fontSize: 15,
                  fontFamily: 'Inter',
                  fontWeight: FontWeight.w700,
                  color: Color(0xFF000C3C).withAlpha(40),
                ),
              ),
            ),
            Column(
              children: (segment['options'] as List<Map<String, dynamic>>)
                  .map((option) {
                return ListTile(
                  leading: Icon(
                    option['icon'],
                    color: option['iconColor'],
                    size: 28,
                  ),
                  title: Text(
                    option['title'],
                    style: TextStyle(
                        color: Colors.black,
                        fontSize: 15,
                        fontFamily: 'Inter',
                        fontWeight: FontWeight.w600),
                  ),
                  trailing: Icon(Icons.chevron_right, color: Colors.grey),
                  onTap: () {
                    if (option['title'] == 'Odjava') {
                      logoutUser();
                      return;
                    }

                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => option['route']),
                    );
                  },
                );
              }).toList(),
            )
          ],
        );
      }).toList(),
    );
  }
}
