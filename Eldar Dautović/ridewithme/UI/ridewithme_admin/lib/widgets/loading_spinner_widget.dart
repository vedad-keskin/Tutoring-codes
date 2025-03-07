import 'package:flutter/material.dart';

class LoadingSpinnerWidget extends StatelessWidget {
  const LoadingSpinnerWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Center(
        child: CircularProgressIndicator(),
      ),
    );
  }
}
