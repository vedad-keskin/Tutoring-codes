import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:ridewithme_mobile/layouts/master_layout.dart';
import 'package:ridewithme_mobile/models/dogadjaj.dart';
import 'package:ridewithme_mobile/models/grad.dart';
import 'package:ridewithme_mobile/models/search_result.dart';
import 'package:ridewithme_mobile/models/voznja.dart';
import 'package:ridewithme_mobile/providers/dogadjaji_provider.dart';
import 'package:ridewithme_mobile/providers/gradovi_provider.dart';
import 'package:ridewithme_mobile/providers/voznje_provider.dart';
import 'package:ridewithme_mobile/screens/voznje_details_screen.dart';
import 'package:ridewithme_mobile/utils/input_util.dart';
import 'package:ridewithme_mobile/widgets/custom_button_widget.dart';
import 'package:ridewithme_mobile/widgets/loading_spinner_widget.dart';

class VoznjeCreateScreen extends StatefulWidget {
  Voznja? voznja;
  List<String>? allowedActions;
  VoznjeCreateScreen({super.key, this.voznja, this.allowedActions});

  @override
  State<VoznjeCreateScreen> createState() => _VoznjeCreateScreenState();
}

class _VoznjeCreateScreenState extends State<VoznjeCreateScreen> {
  late GradoviProvider _gradoviProvider;
  late VoznjeProvider _voznjeProvider;
  late DogadjajiProvider _dogadjajiProvider;

  SearchResult<Gradovi>? gradoviResult;
  SearchResult<Dogadjaj>? dogadjajResult;

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _gradoviProvider = context.read<GradoviProvider>();
    _voznjeProvider = context.read<VoznjeProvider>();
    _dogadjajiProvider = context.read<DogadjajiProvider>();

    _initialValue = {
      "gradOdId": widget.voznja?.gradOd?.id,
      "gradDoId": widget.voznja?.gradDo?.id,
      "cijena": widget.voznja?.cijena.toString(),
      "datumVrijemePocetka": widget.voznja?.datumVrijemePocetka,
      "dogadjajId": widget.voznja?.dogadjaj?.id
    };

    initForm();
  }

  Future initForm() async {
    gradoviResult = await _gradoviProvider.get();
    dogadjajResult = await _dogadjajiProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterLayout(
        selectedIndex: 2,
        backButton: widget.voznja != null
            ? VoznjeDetailsScreen(
                voznja: widget.voznja!,
              )
            : null,
        child: Flexible(
          child: SingleChildScrollView(
            child: Column(
              children: [
                _buildHeader(),
                isLoading ? LoadingSpinnerWidget(height: 100) : _buildForm(),
                _save()
              ],
            ),
          ),
        ));
  }

  Widget _buildHeader() {
    return Container(
      margin: EdgeInsets.all(20),
      decoration: BoxDecoration(
          color: Color(widget.voznja != null ? 0xFF7463DE : 0xFF39D5C3)
              .withAlpha(60),
          borderRadius: BorderRadius.circular(15)),
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          spacing: 20,
          children: [
            Row(
              spacing: 10,
              children: [
                SizedBox(
                  height: 150,
                  width: 10,
                  child: DecoratedBox(
                      decoration: BoxDecoration(
                          color: Color(widget.voznja != null
                              ? 0xFF7463DE
                              : 0xFF39D5C3))),
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      widget.voznja != null ? "Uređivanje" : 'Kreiranje',
                      style: _buildTextStyle(),
                    ),
                    Text(
                      widget.voznja != null ? "vaše" : "nove",
                      style: _buildTextStyle(),
                    ),
                    Text('vožnje', style: _buildTextStyle())
                  ],
                )
              ],
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildForm() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20),
      child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(
            spacing: 10,
            children: [
              buildDropdown(
                name: "GradOdId",
                labelText: "Grad od",
                prefixIcon: Icon(Icons.location_city_rounded),
                initialValue: _initialValue['gradOdId']?.toString() ??
                    gradoviResult?.result[0].id.toString(),
                items: _buildGradoviDropdownItems(),
              ),
              buildDropdown(
                name: "GradDoId",
                labelText: "Grad do",
                hintText: "Grad do",
                initialValue: _initialValue['gradDoId']?.toString() ??
                    gradoviResult?.result[1].id.toString(),
                prefixIcon: Icon(Icons.location_city_rounded),
                items: _buildGradoviDropdownItems(),
              ),
              if (dogadjajResult?.count != 0) ...[
                buildDropdown(
                  name: "DogadjajId",
                  labelText: "Događaj",
                  hintText: "Događaj",
                  prefixIcon: Icon(Icons.event),
                  items: _buildDogadjajiDropdownItems(),
                ),
              ],
              FormBuilderTextField(
                name: "cijena",
                keyboardType: TextInputType.number,
                autovalidateMode: AutovalidateMode.onUserInteraction,
                validator: FormBuilderValidators.compose([
                  FormBuilderValidators.required(
                    errorText: 'Ovo polje je obavezno.',
                  ),
                  FormBuilderValidators.float(
                      errorText: "Ovo polje mora biti broj.")
                ]),
                initialValue: _initialValue['cijena'],
                valueTransformer: (value) {
                  if (value != null) {
                    return double.tryParse(value);
                  }
                },
                decoration: buildTextFieldDecoration(
                    labelText: "Cijena",
                    hintText: "Cijena",
                    prefixIcon: Icon(Icons.attach_money_rounded)),
              ),
              FormBuilderDateTimePicker(
                name: "datumVrijemePocetka",
                initialValue: _initialValue['datumVrijemePocetka'],
                autovalidateMode: AutovalidateMode.onUserInteraction,
                validator: (value) {
                  if (value != null && value.isBefore(DateTime.now())) {
                    return 'Datum ne može biti u prošlosti';
                  }
                  return null;
                },
                decoration: buildTextFieldDecoration(
                  labelText: "Datum vrijeme polaska",
                  hintText: "Datum vrijeme polaska",
                  prefixIcon: Icon(Icons.date_range_rounded),
                ),
              )
            ],
          )),
    );
  }

  Future<void> handleFormSubmit() async {
    try {
      if (!_formKey.currentState!.saveAndValidate()) {
        return;
      }

      var request = Map.from(_formKey.currentState!.value);
      if (request['datumVrijemePocetka'] is DateTime) {
        request['datumVrijemePocetka'] =
            (request['datumVrijemePocetka'] as DateTime).toIso8601String();
      }

      if (widget.voznja == null) {
        var result = await _voznjeProvider.insert(request);
        await showSnackBar("Uspješno ste dodali novu vožnju.");

        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => VoznjeDetailsScreen(
              voznja: result,
            ),
          ),
        );
      } else {
        bool? confirmUpdate = await showDialog<bool>(
          context: context,
          builder: (BuildContext context) {
            return AlertDialog(
              title: const Text("Potvrda izmjene"),
              content: const Text(
                  "Jeste li sigurni da želite izmijeniti ovu vožnju?"),
              actions: [
                TextButton(
                  onPressed: () => Navigator.of(context).pop(false),
                  child: const Text("Odustani"),
                ),
                TextButton(
                  onPressed: () => Navigator.of(context).pop(true),
                  child: const Text("Potvrdi"),
                ),
              ],
            );
          },
        );

        if (confirmUpdate == true) {
          var result =
              await _voznjeProvider.update(widget.voznja!.id!, request);
          await showSnackBar("Uspješno ste izmijenili vožnju.");
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => VoznjeDetailsScreen(
                voznja: result,
              ),
            ),
          );
        }
      }
    } on Exception catch (e) {
      await showSnackBar("Došlo je do greške: ${e.toString()}");
    }
  }

  Future<void> showSnackBar(String message) async {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        behavior: SnackBarBehavior.floating,
        content: Text(message),
        action: SnackBarAction(
          label: "U redu",
          onPressed: () =>
              ScaffoldMessenger.of(context)..removeCurrentSnackBar(),
        ),
      ),
    );
  }

  Widget _save() {
    return Padding(
      padding: const EdgeInsets.all(20),
      child: CustomButtonWidget(
          isFullWidth: true,
          buttonText: "Sačuvaj",
          onPress: () async {
            await handleFormSubmit();
          } // Promenite zaobljenost ivica
          ),
    );
  }

  TextStyle _buildTextStyle() {
    return TextStyle(
        fontFamily: "Inter",
        fontSize: 30,
        color: Color(0xFF072220),
        fontWeight: FontWeight.w900);
  }

  List<DropdownMenuItem<String>> _buildGradoviDropdownItems() {
    return (gradoviResult?.result ?? [])
        .map((e) => DropdownMenuItem(
              value: e.id.toString(),
              child: Text(
                e.naziv ?? "",
                style: const TextStyle(color: Colors.black),
              ),
            ))
        .toList();
  }

  List<DropdownMenuItem<String>> _buildDogadjajiDropdownItems() {
    final items = (dogadjajResult?.result ?? [])
        .map((e) => DropdownMenuItem(
              value: e.id.toString(),
              child: Text(
                e.naziv ?? "",
                style: const TextStyle(color: Colors.black),
              ),
            ))
        .toList();

    // Dodaj opciju "Odaberi" s null vrijednošću
    items.insert(
      0,
      const DropdownMenuItem(
        value: null,
        child: Text(
          'Odaberi',
          style: TextStyle(color: Colors.black),
        ),
      ),
    );

    return items;
  }
}
