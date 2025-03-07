import 'package:flutter/cupertino.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/voznje_provider.dart';
import 'package:ridewithme_mobile/screens/profile_screen.dart';
import 'package:ridewithme_mobile/utils/auth_util.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';
import 'package:ridewithme_mobile/widgets/ride_widget_detailed.dart';

class TravelerRidesScreen extends StatefulWidget {
  const TravelerRidesScreen({super.key});

  @override
  State<TravelerRidesScreen> createState() => _TravelerRidesScreenState();
}

class _TravelerRidesScreenState extends State<TravelerRidesScreen> {
  late VoznjeProvider _voznjeProvider;
  bool isLoading = true;
  SearchResult<Voznja>? voznjeResults;

  final Map<String, Color> rideColors = {
    'active': Color(0xFF7463DE),
    'draft': Color(0xFFD5C339),
    'booked': Color(0xFF39D5C3),
    'inprogress': Color(0xFFC339D5),
    'completed': Color(0xFF3999D5),
  };

  final Map<String, String> rideTitles = {
    'active': "Aktivne vožnje",
    'draft': "Draft vožnje",
    'booked': "Zakazane vožnje",
    'inprogress': "U toku",
    'completed': "Završene vožnje",
  };

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _voznjeProvider = context.read<VoznjeProvider>();
    initRides();
  }

  Future<void> initRides() async {
    voznjeResults = await _voznjeProvider.get(filter: {
      "IsKorisniciIncluded": true,
      "IsGradoviIncluded": true,
      "KlijentId": Authorization.id ?? 0
    });
    setState(() => isLoading = false);
  }

  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 4,
      header: "Vožnje",
      headerDescription: "Vožnje u kojima ste (bili) putnici",
      backButton: ProfileScreen(),
      headerColor: Color(0xFF39D5C3),
      child: Flexible(
        child: SingleChildScrollView(
          child: Column(
            spacing: 20,
            children: isLoading
                ? [LoadingSpinnerWidget(height: 100)]
                : (voznjeResults == null || voznjeResults!.result.isEmpty)
                    ? [
                        Padding(
                          padding: const EdgeInsets.all(20),
                          child: Text(
                            "Niste (bili) putnici u niti jednoj vožnji.",
                            textAlign: TextAlign.center,
                            style: TextStyle(
                              fontFamily: "Inter",
                              fontSize: 16,
                              fontWeight: FontWeight.w600,
                            ),
                          ),
                        )
                      ]
                    : rideTitles.keys
                        .map((state) => _buildRides(state))
                        .toList(),
          ),
        ),
      ),
    );
  }

  Widget _buildRides(String state) {
    var filteredRides =
        voznjeResults?.result.where((e) => e.stateMachine == state).toList() ??
            [];
    if (filteredRides.isEmpty) return SizedBox.shrink();

    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: Column(
        spacing: 10,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            rideTitles[state]!.toUpperCase(),
            style: TextStyle(
              fontSize: 15,
              fontFamily: 'Inter',
              fontWeight: FontWeight.w700,
              color: Color(0xFF000C3C).withAlpha(40),
            ),
          ),
          Column(
            spacing: 10,
            children: filteredRides.map((element) {
              return RideWidgetDetailed(
                voznja: element,
                boxColor: rideColors[state]!,
                rating: false,
              );
            }).toList(),
          ),
        ],
      ),
    );
  }
}
