import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:ridewithme_mobile/screens/home_screen.dart';
import 'package:ridewithme_mobile/screens/profile_screen.dart';
import 'package:ridewithme_mobile/screens/rate_list_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_create_screen.dart';
import 'package:ridewithme_mobile/screens/voznje_screen.dart';

class MasterLayout extends StatefulWidget {
  final Widget child;
  final int selectedIndex;
  String? header;
  String? headerDescription;
  Color? headerColor;
  Color? headerTextColor;
  Widget? backButton;

  MasterLayout(
      {super.key,
      required this.child,
      required this.selectedIndex,
      this.header,
      this.headerDescription,
      this.headerColor,
      this.headerTextColor,
      this.backButton});

  @override
  State<MasterLayout> createState() => _MasterLayoutState();
}

class _MasterLayoutState extends State<MasterLayout> {
  final List<Map<String, dynamic>> menuItems = [
    {'title': 'Početna', 'icon': Icons.home_rounded, 'route': HomeScreen()},
    {
      'title': 'Vožnje',
      'icon': Icons.directions_car_filled_rounded,
      'route': VoznjeScreen()
    },
    {
      'title': '',
      'icon': Icons.add_circle,
      'route': VoznjeCreateScreen(),
      'size': 50
    },
    {
      'title': 'Ocjene',
      'icon': Icons.star_rate_rounded,
      'route': RateListScreen()
    },
    {
      'title': 'Profil',
      'icon': Icons.person_2_rounded,
      'route': ProfileScreen()
    },
  ];

  void _onItemTapped(int index) {
    Navigator.of(context).push(
      PageRouteBuilder(
        pageBuilder: (context, animation1, animation2) =>
            menuItems[index]['route'] as Widget,
        transitionDuration: Duration.zero,
        reverseTransitionDuration: Duration.zero,
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return PopScope(
      canPop: true,
      child: Scaffold(
        body: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            if (widget.backButton != null)
              Padding(
                padding: const EdgeInsets.only(top: 10, left: 10),
                child: IconButton(
                  onPressed: () {
                    // Navigator.of(context).push(
                    //   CupertinoPageRoute(
                    //     builder: (context) => widget.backButton!,
                    //   ),
                    // );
                    Navigator.of(context).pop();
                  },
                  iconSize: 30,
                  icon: Icon(Icons.chevron_left),
                ),
              ),
            if (widget.header != null &&
                widget.headerDescription != null &&
                widget.headerColor != null)
              Container(
                margin: EdgeInsets.all(20),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(15),
                    color: widget.headerColor?.withAlpha(60)),
                alignment: Alignment.centerLeft,
                child: Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(widget.header ?? '',
                          style: TextStyle(
                              fontFamily: "Inter",
                              fontSize: 20,
                              fontWeight: FontWeight.bold,
                              color:
                                  widget.headerTextColor ?? widget.headerColor),
                          overflow: TextOverflow.ellipsis),
                      Text(widget.headerDescription ?? '',
                          style: TextStyle(
                              fontFamily: "Inter",
                              fontSize: 13,
                              fontWeight: FontWeight.normal,
                              color: Color(0xFF072220)),
                          overflow: TextOverflow.ellipsis),
                    ],
                  ),
                ),
              ),
            widget.child
          ],
        ),
        bottomNavigationBar: CupertinoTabBar(
          items: menuItems
              .map((e) => BottomNavigationBarItem(
                    icon: Icon(
                      e['icon'],
                      size: e['title'] == "" ? 45 : 30,
                    ),
                    activeIcon: Icon(
                      e['icon'],
                      color: Color(0xFF7463DE),
                      size: e['title'] == "" ? 45 : 30,
                    ),
                    label: e['title'],
                  ))
              .toList(),
          inactiveColor: Color(0xFF848388),
          currentIndex: widget.selectedIndex,
          onTap: (value) => _onItemTapped(value),
          activeColor: Color(0xFF000000),
        ),
      ),
    );
  }
}
