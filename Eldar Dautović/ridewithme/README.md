# **ridewithme**
Seminarski rad za predmet Razvoj Softvera II 

# Upute za pokretanje:
1. Pokrenuti komandu: ```docker-compose up --build``` u terminalu.
2. Pustiti da se izvrti docker compose koji će da nam builda, seeda bazu i pokrene API.
3. Exportovati ```fit-build-2025-01-07.zip```.
4. Nakon exporta imamo dva različita foldera, jedan za desktop **(Release)** drugi za mobile  **(flutter-apk) APK**.

## Pokretanje Mobile:
1. Pokrenuti emulator.
2. Prevući apk fajl iz foldera **flutter-apk** u emulator, sačekati da se instalira.
3. Koristiti aplikaciju

## Pokretanje Desktop:
1. Pokrenuti .exe fajl iz  **Release** foldera.
2. Koristiti aplikaciju.

## Kredencijali:
**Admin Korisnik**\
  Korisničko ime: ```admin```\
  Lozinka: ```string```

**Test Korisnik**\
  Korisničko ime: ```test```\
  Lozinka: ```string```

## Stripe
U sklopu seminarskog rada za plaćanje korišten je Stripe. Da bi testirali plaćanje on nam osigurava testne podatke za unos kreditne kartice. Oni su sljedeći:

Broj kartice: ```4242 4242 4242 4242```\
CVC: ```Bilo koje 3 cifre```\
Datum isteka: ```Bilo koji u budućnosti```

Plaćanje je omogućeno kada se uđe u detalje vožnje koja je u statusu "Aktivan".


## RabbitMQ
RabbitMQ korišten za:
- dopisivanje između korisnika i vozača ukoliko je vožnja u statusu "Zakazana".
- slanje e-maila da smo aktivirali vožnju
- slanja e-maila svim Administratorima da je žalba kreirana
- slanje e-maila korisniku koji plati vožnju i vozaču da mu je vožnja zakazana.

## E-mail 
E-mail adresa korištena za slanje mejlova jeste:\
```ridewithmesender@gmail.com```

## CRON
Korišten je i jedan CRON job koji nam svaki dan u 00:00 provjerava sva obavještenja koja su aktivna da li su završili po datumu završetka, ako jesu prebacuje ih u status "Završen".

