import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/faq.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/providers/faq_provider.dart';
import 'package:ridewithme_mobile/widgets/faq_item_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class FaqScreen extends StatefulWidget {
  const FaqScreen({super.key});

  @override
  State<FaqScreen> createState() => _FaqScreenState();
}

class _FaqScreenState extends State<FaqScreen> {
  late FaqProvider _faqProvider;

  bool isLoading = true;

  SearchResult<FAQ>? faqResults;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _faqProvider = context.read<FaqProvider>();

    initData();
  }

  Future initData() async {
    faqResults = await _faqProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
      selectedIndex: 4,
      header: "FAQ",
      headerDescription: "Često postavljena pitanja",
      headerColor: const Color(0xFF7463DE),
      child: isLoading ? LoadingSpinnerWidget(height: 50) : _buildFaq(),
    );
  }

  Widget _buildFaq() {
    if (faqResults?.result == null || faqResults!.result.isEmpty) {
      return const Center(
        child: Text("Nema dostupnih FAQ pitanja."),
      );
    }

    return Flexible(
      fit: FlexFit.loose,
      child: SingleChildScrollView(
        child: Column(
          children: faqResults!.result
              .map((element) => FaqItemWidget(
                    question: element.pitanje ?? '',
                    answer: element.odgovor ?? '',
                  ))
              .toList(),
        ),
      ),
    );
  }
}
