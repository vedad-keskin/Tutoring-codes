import 'dart:typed_data';
import 'dart:ui';

import 'package:intl/intl.dart';
import 'package:syncfusion_flutter_pdf/pdf.dart';

PdfLayoutResult drawHeader(
    PdfPage page, Size pageSize, PdfGrid grid, Uint8List fontData) {
  page.graphics.drawRectangle(
      brush: PdfSolidBrush(PdfColor(68, 114, 196)),
      bounds: Rect.fromLTWH(0, 0, pageSize.width - 115, 90));

  page.graphics.drawString('ridewithme', PdfTrueTypeFont(fontData, 15),
      brush: PdfBrushes.white,
      bounds: Rect.fromLTWH(25, 0, pageSize.width - 115, 90),
      format: PdfStringFormat(lineAlignment: PdfVerticalAlignment.middle));

  page.graphics.drawString('IZVJEŠTAJ', PdfTrueTypeFont(fontData, 30),
      brush: PdfBrushes.white,
      bounds: Rect.fromLTWH(25, 20, pageSize.width - 115, 90),
      format: PdfStringFormat(lineAlignment: PdfVerticalAlignment.middle));

  final PdfFont contentFont = PdfTrueTypeFont(fontData, 9);

  final DateFormat format = DateFormat('dd.MM.yyyy.');
  final String invoiceNumber = 'Datum: ${format.format(DateTime.now())}';
  final Size contentSize = contentFont.measureString(invoiceNumber);

  PdfTextElement(text: invoiceNumber, font: contentFont).draw(
      page: page,
      bounds: Rect.fromLTWH(pageSize.width - (contentSize.width + 30), 120,
          contentSize.width + 30, pageSize.height - 120));

  return PdfTextElement(
          text:
              "Poslovni izvještaj ridewithme platforme u posljednje tri godine.",
          font: contentFont)
      .draw(
          page: page,
          bounds: Rect.fromLTWH(
              30,
              120,
              pageSize.width - (contentSize.width + 30),
              pageSize.height - 120))!;
}
