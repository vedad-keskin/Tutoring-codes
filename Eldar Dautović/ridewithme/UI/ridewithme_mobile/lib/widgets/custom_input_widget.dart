import 'package:flutter/material.dart';

class CustomInputField extends StatelessWidget {
  final String labelText;
  final String? Function(String?)? validator;
  final TextEditingController? controller;
  final IconData? prefixIcon;
  final double fontSize;
  final String fontFamily;
  final Color fillColor;
  final Color borderColor;
  final bool obscuredText;

  const CustomInputField(
      {Key? key,
      required this.labelText,
      this.validator,
      this.controller,
      this.prefixIcon,
      this.fontSize = 16,
      this.fontFamily = "Inter",
      this.fillColor = const Color(0xFFF3FCFC),
      this.borderColor = const Color(0xFFE3E3E3),
      this.obscuredText = false})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      validator: validator,
      obscureText: obscuredText,
      controller: controller,
      style: TextStyle(fontSize: fontSize + 1, fontFamily: fontFamily),
      decoration: InputDecoration(
        label: Text(labelText),
        labelStyle: TextStyle(fontSize: fontSize, fontFamily: fontFamily),
        prefixIcon: prefixIcon != null ? Icon(prefixIcon) : null,
        filled: true,
        fillColor: fillColor,
        border: OutlineInputBorder(
          borderSide: BorderSide(color: borderColor),
        ),
        enabledBorder: OutlineInputBorder(
          borderSide: BorderSide(color: borderColor),
        ),
      ),
    );
  }
}
