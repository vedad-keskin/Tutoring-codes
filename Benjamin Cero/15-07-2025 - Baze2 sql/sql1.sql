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


USE AdventureWorks2022

--1) (6 bodova) Kreirati upit koji će prikazati ukupan broj uposlenika po odjelima. Potrebno je prebrojati samo one uposlenike koji su trenutno aktivni, odnosno rade na datom odjelu. Također, samo uzeti u obzir one uposlenike koji imaju više od 10 godina radnog staža (ne uključujući graničnu vrijednost). Rezultate sortirati prema broju uposlenika u opadajućem redoslijedu. (AdventureWorks2017)

SELECT D.Name, COUNT(E.BusinessEntityID) AS 'Broj uposlenika'
FROM HumanResources.Department AS D
     INNER JOIN HumanResources.EmployeeDepartmentHistory AS EDH
	 ON EDH.DepartmentID = D.DepartmentID
	 INNER JOIN HumanResources.Employee AS E
	 ON E.BusinessEntityID = EDH.BusinessEntityID
WHERE EDH.EndDate IS NULL AND DATEDIFF(YEAR, E.HireDate, GETDATE() ) > 10
GROUP BY D.Name
ORDER BY 2 DESC


--2) Ispisati teritorij i broj narudžbi po teritorijima, uzeti u obzir onu narudzbu koja je placena kreditnom karticom (AdventureWorks2017)

SELECT ST.Name, COUNT(SOH.SalesOrderID) AS 'Broj naružbi'
FROM Sales.SalesTerritory AS ST
     INNER JOIN Sales.SalesOrderHeader AS SOH
	 ON ST.TerritoryID = SOH.TerritoryID
WHERE SOH.CreditCardID IS NOT NULL
GROUP BY ST.Name



--3) Prikazati proizvode koji pripadaju kategoriji bikes, imaju vise od 30 narudzbi i nemaju broj u imenu (AdventureWorks2017)

SELECT P.Name
FROM Production.Product AS P
     INNER JOIN Production.ProductSubcategory AS PS
	 ON PS.ProductSubcategoryID = P.ProductSubcategoryID
	 INNER JOIN Production.ProductCategory AS PC
	 ON PC.ProductCategoryID = PS.ProductCategoryID
	 INNER JOIN Sales.SalesOrderDetail AS SOD
	 ON SOD.ProductID = P.ProductID
WHERE PC.Name = 'Bikes' AND P.Name NOT LIKE '%[0-9]%' --PC.Name LIKE '%Bikes%'
GROUP BY P.Name
HAVING COUNT(SOD.ProductID) > 30

--4) Prikazati narudžbu koja je najmanje dana bila u prodaji, i ako ima vise narudžbi sa istim vrijednostima, prikazati i njih (AdventureWorks)

SELECT TOP 1 WITH TIES SOD.SalesOrderID, DATEDIFF(DAY, P.SellStartDate, P.SellEndDate) AS 'Dani u prodaji'
FROM Production.Product AS P
     INNER JOIN Sales.SalesOrderDetail AS SOD
	 ON SOD.ProductID = P.ProductID
WHERE P.SellEndDate IS NOT NULL
ORDER BY 2 ASC


--5) (7 bodova) Kreirati upit kojim će se prikazati proizvod koji je najviše dana bio u prodaji (njegova prodaja je prestala) a pripada kategoriji bicikala. Proizvodu se početkom i po prestanku prodaje bilježi datum. Ukoliko postoji više proizvoda sa istim vremenskim periodom kao i prvi, prikazati ih u rezultatima upita.


SELECT TOP 1 WITH TIES P.Name, DATEDIFF(DAY, P.SellStartDate, P.SellEndDate) AS 'Dana u prodaji'
FROM Production.Product AS P
     INNER JOIN Production.ProductSubcategory AS PS
	 ON PS.ProductSubcategoryID = P.ProductSubcategoryID
	 INNER JOIN Production.ProductCategory AS PC
	 ON PC.ProductCategoryID = PS.ProductCategoryID
WHERE P.SellEndDate IS NOT NULL AND PC.Name = 'Bikes'
ORDER BY 2 DESC


--6) Prikazuje prosječnu vrijednost narudžbi po godinama za svaki teritorij. Uzimaju se u obzir samo narudžbe koje su plaćene kreditnom karticom. Rezultat prikazuje teritorije sortirane uzlazno po imenu teritorija, dok su godine sortirane silazno (najnovije prvo) Prosječna vrijednost narudžbi je zaokružena na dvije decimale

SELECT ST.Name, YEAR(SOH.OrderDate) AS 'Godina naružbe' , ROUND(AVG(SOH.SubTotal),2) AS 'Prosjek narudžbe'
FROM Sales.SalesTerritory AS ST
     INNER JOIN Sales.SalesOrderHeader AS SOH
	 ON SOH.TerritoryID = ST.TerritoryID
WHERE SOH.CreditCardID IS NOT NULL
GROUP BY ST.Name, YEAR(SOH.OrderDate)
ORDER BY 1 ASC, 2 DESC

--7) Prikazati naziv odjela na kojem radi najviše uposlenika starijih od 65 godina

SELECT TOP 1 D.Name, COUNT(E.BusinessEntityID) AS 'Broj uposlenika'
FROM HumanResources.Employee AS E
     INNER JOIN HumanResources.EmployeeDepartmentHistory AS EDH
	 ON EDH.BusinessEntityID = E.BusinessEntityID
	 INNER JOIN HumanResources.Department AS D
	 ON D.DepartmentID = EDH.DepartmentID
WHERE DATEDIFF(YEAR, E.BirthDate, GETDATE()) > 65
GROUP BY D.Name
ORDER BY 2 DESC

--8) Prikazati 10 količinski najvećih stavki prodaje. Uključiti broj narudžbe, naziv proizvoda, datum narudžbe i naručenu količinu. Ukoliko postoji više stavki sa istom količinom kao posljednja na listi, proširiti listu i uključiti i te stavke (Pubs)

USE pubs

SELECT TOP 10 WITH TIES S.ord_num, T.title, S.ord_date, S.qty
FROM sales AS S
     INNER JOIN titles AS T
	 ON S.title_id = T.title_id
ORDER BY 4 DESC

--9) (6 bodova) Kreirati upit kojim će se prikazati ukupan broj porizvoda po kategoriajma. Uslov je da se prikazu samo one kategorije kojima ne pripada vise od 30 proizvoda, a sadrze broj u bilo kojoj od rijeci i ne nalaze se u prodaji.

USE AdventureWorks2022

SELECT PC.Name, COUNT(P.ProductID) AS 'Ukupan broj proizvoda'
FROM Production.Product AS P
     INNER JOIN Production.ProductSubcategory AS PS
	 ON PS.ProductSubcategoryID = P.ProductSubcategoryID
	 INNER JOIN Production.ProductCategory AS PC
	 ON PC.ProductCategoryID = PS.ProductCategoryID
WHERE P.Name LIKE '%[0-9]%' AND P.SellEndDate IS NOT NULL
GROUP BY PC.Name
HAVING COUNT(P.ProductID) <= 30

--10) Menadzmentu trebaju svi proizvodi koji vise nisu u prodaji. Trebaju se uzeti prozivodi koji su se prodali vise od 100 puta i ne pripadaju kateogriji Bikes. Rezultati se trebaju ispisati u obliku "laptop 300kom" prodano (AdventureWorks)


SELECT P.Name +' ' + CAST(SUM(SOD.OrderQty) AS NVARCHAR)+'kom' AS 'Prodani proizvodi'
FROM Production.Product AS P
     INNER JOIN Sales.SalesOrderDetail AS SOD
	 ON SOD.ProductID = P.ProductID
	 INNER JOIN Production.ProductSubcategory AS PS
	 ON PS.ProductSubcategoryID = P.ProductSubcategoryID
	 INNER JOIN Production.ProductCategory AS PC
	 ON PC.ProductCategoryID = PS.ProductCategoryID
WHERE P.SellEndDate IS NOT NULL AND PC.Name NOT LIKE '%Bikes%'
GROUP BY P.Name
HAVING SUM(SOD.OrderQty) > 100


--11) (11 bodova) Napisati upit koji će prikazati sljedeće podatke o proizvodima: naziv proizvoda, naziv kompanije dobavljača, količinu na skladištu, te kreiranu šifru proizvoda. Šifra se sastoji od sljedećih vrijednosti: (Northwind)
--1) Prva dva slova naziva proizvoda
--2) Karakter /
--3) Prva dva slova druge riječi naziva kompanije dobavljača, uzeti u obzir one kompanije koje u nazivu imaju 2 ili 3 riječi
--4) ID proizvoda, po pravilu ukoliko se radi o jednoznamenkom broju na njega dodati slovo 'a', u suprotnom uzeti obrnutu vrijednost broja Npr. Za proizvod sa nazivom Chai i sa dobavljačem naziva Exotic Liquids, šifra će btiti Ch/Li1a

USE Northwind

SELECT P.ProductName, S.CompanyName, P.UnitsInStock, SUBSTRING(P.ProductName,1,2) + '/' +
IIF(LEN(S.CompanyName) - LEN(REPLACE(S.CompanyName, ' ', '' )) IN (1,2) , SUBSTRING(S.CompanyName ,  CHARINDEX(' ',S.CompanyName) + 1, 2) ,'' ) + IIF(P.ProductID < 10 , CAST(P.ProductID AS NVARCHAR) + 'a' , REVERSE(P.ProductID) ) AS 'Sifra'
FROM Products AS P 
     INNER JOIN Suppliers AS S
	 ON S.SupplierID = P.SupplierID


--12) prikazati ime proizvode, koliko ga ima na stanju i koliko je puta prodat,
--i ukupna vrijednost proizvoda sa popustom.
--- Tamo gdje je količina na skladištu 0 staviti "proizvoda nema na skladištu",
--- tamo gdje je prodata količina 0 staviti "proizvod nije prodat"
--- tamo gdje je ukupna vrijednost NULL staviti "stavka nije prodana" (AdventureWorks2017)

USE AdventureWorks2022

SELECT P.Name, IIF(PPI.Quantity = 0,'proizvoda nema na skladištu' , CAST(PPI.Quantity AS NVARCHAR) ) AS 'Količina na skladištu',
IIF(COUNT(SOD.OrderQty) = 0, 'proizvod nije prodat', CAST(COUNT(SOD.OrderQty) AS NVARCHAR)) AS 'Prodana količina',
IIF(SUM(LineTotal) IS NULL,'stavka nije prodana', CAST( SUM(LineTotal) AS NVARCHAR) ) AS 'Ukupna vrijednost s popustom'
FROM Production.Product AS P
     INNER JOIN Production.ProductInventory AS PPI
	 ON PPI.ProductID = P.ProductID
	 FULL OUTER JOIN Sales.SalesOrderDetail AS SOD
	 ON SOD.ProductID = P.ProductID
GROUP BY P.Name, PPI.Quantity
ORDER BY 3 DESC




