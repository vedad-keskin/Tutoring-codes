import 'package:flutter/material.dart';

class CustomButtonWidget extends StatelessWidget {
  CustomButtonWidget(
      {required this.buttonText,
      required this.onPress,
      this.padding = const EdgeInsets.symmetric(
          vertical: 16, horizontal: 24), // default padding
      this.buttonColor = const Color(0xFF39D5C3),
      this.textColor = const Color(0xFF072220),
      this.fontSize = 14,
      this.fontWeight = FontWeight.bold,
      this.borderRadius = 5,
      this.isDisabled = false});

  final String buttonText;
  final void Function()? onPress;
  final EdgeInsetsGeometry padding;
  final Color buttonColor;
  final Color textColor;
  final double fontSize;
  final FontWeight fontWeight;
  final double borderRadius;
  final bool isDisabled;

  @override
  Widget build(BuildContext context) {
    return IntrinsicWidth(
      child: ElevatedButton(
        onPressed: isDisabled ? null : onPress,
        style: ElevatedButton.styleFrom(
          foregroundColor: textColor,
          backgroundColor: buttonColor,
          shadowColor: Colors.transparent,
          textStyle: TextStyle(fontSize: fontSize, fontWeight: fontWeight),
          padding: padding, // Apply the padding here
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(borderRadius),
          ),
        ),
        child: Text(
          buttonText,
          style: TextStyle(fontFamily: "Inter"),
        ),
      ),
    );
  }
}
