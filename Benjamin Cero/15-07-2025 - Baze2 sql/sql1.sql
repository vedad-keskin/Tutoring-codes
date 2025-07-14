CREATE DATABASE IB180079
GO
USE IB180079

--2a) Prodavaci
--• ProdavacID, cjelobrojna vrijednost i primarni kljuè, autoinkrement
--• Ime, 50 UNICODE karaktera (obavezan unos)
--• Prezime, 50 UNICODE karaktera (obavezan unos)
--• OpisPosla, 50 UNICODE karaktera (obavezan unos)
--• EmailAdresa, 50 UNICODE 

CREATE TABLE Prodavaci
(
ProdavacID INT CONSTRAINT PK_Prodavac PRIMARY KEY IDENTITY(1,1),
Ime NVARCHAR(50) NOT NULL,
Prezime NVARCHAR(50) NOT NULL,
OpisPosla NVARCHAR(50) NOT NULL,
EmailAdresa NVARCHAR(50)
)

--2b) Proizvodi
--• ProizvodID, cjelobrojna vrijednost i primarni kljuè, autoinkrement
--• Naziv, 50 UNICODE karaktera (obavezan unos)
--• SifraProizvoda, 25 UNICODE karaktera (obavezan unos)
--• Boja, 15 UNICODE karaktera
--• NazivKategorije, 50 UNICODE (obavezan unos)

CREATE TABLE Proizvodi
(
ProizvodID INT CONSTRAINT PK_Proizvod PRIMARY KEY IDENTITY(1,1),
Naziv NVARCHAR(50) NOT NULL,
SifraProizvoda NVARCHAR(25) NOT NULL,
Boja NVARCHAR(15),
NazivKategorije NVARCHAR(50) NOT NULL
)

--2c) ZaglavljeNarudzbe
--• NarudzbaID, cjelobrojna vrijednost i primarni kljuè, autoinkrement
--• DatumNarudzbe, polje za unos datuma i vremena (obavezan unos)
--• DatumIsporuke, polje za unos datuma i vremena
--• KreditnaKarticaID, cjelobrojna vrijednost
--• ImeKupca, 50 UNICODE (obavezan unos)
--• PrezimeKupca, 50 UNICODE (obavezan unos)
--• NazivGrada, 30 UNICODE (obavezan unos)
--• ProdavacID, cjelobrojna vrijednost i strani kljuè
--• NacinIsporuke, 50 UNICODE (obavezan unos)

CREATE TABLE ZaglavljeNarudzbe
(
NarudzbaID INT CONSTRAINT PK_Narudzba PRIMARY KEY IDENTITY(1,1),
DatumNarudzbe DATETIME NOT NULL,
DatumIsporuke DATETIME ,
KreditnaKarticaID INT,
ImeKupca NVARCHAR(50) NOT NULL,
PrezimeKupca NVARCHAR(50) NOT NULL,
NazivGrada NVARCHAR(30) NOT NULL,
ProdavacID INT CONSTRAINT FK_ZaglavljeNarudzbe_Prodavaci FOREIGN KEY REFERENCES Prodavaci(ProdavacID),
NacinIsporuke NVARCHAR(50) NOT NULL
)

--c) DetaljiNarudzbe
--• NarudzbaID, cjelobrojna vrijednost, obavezan unos i strani kljuè
--• ProizvodID, cjelobrojna vrijednost, obavezan unos i strani kljuè
--• Cijena, novèani tip (obavezan unos),
--• Kolicina, skraæeni cjelobrojni tip (obavezan unos),
--• Popust, novèani tip (obavezan unos)
--• OpisSpecijalnePonude, 255 UNICODE (obavezan unos)

CREATE TABLE DetaljiNarudzbe
(
DetaljiNarudzbeID INT CONSTRAINT PK_DetaljiNarudzbe PRIMARY KEY IDENTITY(1,1),
NarudzbaID INT CONSTRAINT FK_DetaljiNarudzbe_ZaglavljeNarudzbe FOREIGN KEY REFERENCES ZaglavljeNarudzbe(NarudzbaID),
ProizvodID INT CONSTRAINT FK_DetaljiNarudzbe_Proizvodi FOREIGN KEY REFERENCES Proizvodi(ProizvodID),
Cijena MONEY NOT NULL,
Kolicina SMALLINT NOT NULL,
Popust MONEY NOT NULL,
OpisSpecijalnePonude NVARCHAR(255) NOT NULL
)

--3a. Iz baze podataka AdventureWorks u svoju bazu podataka prebaciti sljedeæe podatke:
--a) U tabelu Prodavaci dodati :
--• BusinessEntityID (SalesPerson) -> ProdavacID
--• FirstName -> Ime
--• LastName -> Prezime
--• JobTitle (Employee) -> OpisPosla
--• EmailAddress (EmailAddress) -> EmailAdresa

SET IDENTITY_INSERT Prodavaci ON
INSERT INTO Prodavaci(ProdavacID, Ime ,Prezime, OpisPosla, EmailAdresa)
SELECT SP.BusinessEntityID, P.FirstName, P.LastName, E.JobTitle, EA.EmailAddress
FROM AdventureWorks2022.Sales.SalesPerson AS SP 
     INNER JOIN AdventureWorks2022.HumanResources.Employee AS E
	 ON SP.BusinessEntityID = E.BusinessEntityID
	 INNER JOIN AdventureWorks2022.Person.Person AS P
	 ON E.BusinessEntityID = P.BusinessEntityID
	 INNER JOIN AdventureWorks2022.Person.EmailAddress AS EA
	 ON EA.BusinessEntityID = P.BusinessEntityID
SET IDENTITY_INSERT Prodavaci OFF

--3. Iz baze podataka AdventureWorks u svoju bazu podataka prebaciti sljedeæe podatke:
--3b) U tabelu Proizvodi dodati sve proizvode
--• ProductID -> ProizvodID
--• Name -> Naziv
--• ProductNumber -> SifraProizvoda
--• Color -> Boja
--• Name (ProductCategory) -> NazivKategorije


SET IDENTITY_INSERT Proizvodi ON
INSERT INTO Proizvodi(ProizvodID, Naziv ,SifraProizvoda, Boja, NazivKategorije)
SELECT P.ProductID, P.Name, P.ProductNumber, P.Color, PC.Name
FROM AdventureWorks2022.Production.Product AS P
     INNER JOIN AdventureWorks2022.Production.ProductSubcategory AS PS
	 ON P.ProductSubcategoryID = PS.ProductSubcategoryID
	 INNER JOIN AdventureWorks2022.Production.ProductCategory AS PC
	 ON PS.ProductCategoryID = PC.ProductCategoryID
SET IDENTITY_INSERT Proizvodi OFF

--3c) U tabelu ZaglavljeNarudzbe dodati sve narudžbe
--• SalesOrderID -> NarudzbaID
--• OrderDate -> DatumNarudzbe
--• ShipDate -> DatumIsporuke
--• CreditCardID -> KreditnaKarticaID
--• FirstName (Person) -> ImeKupca
--• LastName (Person) -> PrezimeKupca
--• City (Address) -> NazivGrada
--• SalesPersonID (SalesOrderHeader) -> ProdavacID
--• Name (ShipMethod) -> NacinIsporuke

SET IDENTITY_INSERT ZaglavljeNarudzbe ON
INSERT INTO ZaglavljeNarudzbe(NarudzbaID, DatumNarudzbe ,DatumIsporuke, KreditnaKarticaID, ImeKupca, PrezimeKupca, NazivGrada, ProdavacID, NacinIsporuke)
SELECT SOH.SalesOrderID, SOH.OrderDate, SOH.ShipDate, SOH.CreditCardID, P.FirstName, P.LastName, A.City, SOH.SalesPersonID, SM.Name
FROM AdventureWorks2022.Sales.SalesOrderHeader AS SOH
     INNER JOIN AdventureWorks2022.Sales.Customer AS C
	 ON SOH.CustomerID = C.CustomerID
	 INNER JOIN AdventureWorks2022.Person.Person AS P
	 ON C.PersonID = P.BusinessEntityID
	 INNER JOIN AdventureWorks2022.Person.Address AS A
	 ON SOH.ShipToAddressID = A.AddressID
	 INNER JOIN AdventureWorks2022.Purchasing.ShipMethod AS SM
	 ON SOH.ShipMethodID = SM.ShipMethodID
SET IDENTITY_INSERT ZaglavljeNarudzbe OFF

--3d) U tabelu DetaljiNarudzbe dodati sve stavke narudžbe
--• SalesOrderID -> NarudzbaID
--• ProductID -> ProizvodID
--• UnitPrice -> Cijena
--• OrderQty -> Kolicina
--• UnitPriceDiscount -> Popust
--• Description (SpecialOffer) -> OpisSpecijalnePonude


INSERT INTO DetaljiNarudzbe(NarudzbaID, ProizvodID ,Cijena, Kolicina, Popust, OpisSpecijalnePonude)
SELECT SOD.SalesOrderID, SOD.ProductID, SOD.UnitPrice, SOD.OrderQty, SOD.UnitPriceDiscount, SO.Description
FROM AdventureWorks2022.Sales.SalesOrderDetail AS SOD
     INNER JOIN AdventureWorks2022.Sales.SpecialOfferProduct AS SOP
	 ON SOD.SpecialOfferID = SOP.SpecialOfferID
	 INNER JOIN AdventureWorks2022.Sales.SpecialOffer AS SO
	 ON SOP.SpecialOfferID = SO.SpecialOfferID
