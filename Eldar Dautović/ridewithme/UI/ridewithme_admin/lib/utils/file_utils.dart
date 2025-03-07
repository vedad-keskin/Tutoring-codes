import 'dart:io';

import 'package:open_file/open_file.dart';
import 'package:path_provider/path_provider.dart';

Future<void> saveAndLaunchFile(List<int> bytes, String fileName) async {
  try {
    final Directory directory = await getApplicationDocumentsDirectory();
    final String filePath = '${directory.path}/$fileName';

    final File file = File(filePath);
    await file.writeAsBytes(bytes);

    await OpenFile.open(filePath);
  } catch (e) {
    print("Greška pri čuvanju i otvaranju fajla: $e");
  }
}
