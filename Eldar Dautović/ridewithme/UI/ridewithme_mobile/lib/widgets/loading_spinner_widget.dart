import 'package:flutter/material.dart';

class LoadingSpinnerWidget extends StatelessWidget {
  const LoadingSpinnerWidget({super.key, required this.height});
  final int height;

  @override
  Widget build(BuildContext context) {
    return Container(
      height: height.toDouble(),
      child: Center(
        child: CircularProgressIndicator(),
      ),
    );
  }
}
