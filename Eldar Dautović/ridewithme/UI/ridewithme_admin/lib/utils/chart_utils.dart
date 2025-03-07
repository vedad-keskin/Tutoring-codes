import 'dart:ui';

import 'package:fl_chart/fl_chart.dart';

PieChartSectionData buildPieSection(String title, Color color, int? value) {
  return PieChartSectionData(
    color: color,
    value: value?.toDouble() ?? 0,
    title: '$title - ${value ?? 0}',
    radius: 130,
    titlePositionPercentageOffset: 0.55,
  );
}
