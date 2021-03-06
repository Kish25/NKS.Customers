
--		Table : Addresses		

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Dbo.Addresses') AND type in (N'U'))
	Begin
		ALTER TABLE Dbo.Addresses SET ( SYSTEM_VERSIONING = OFF  )
		ALTER TABLE Dbo.Addresses DROP PERIOD FOR SYSTEM_TIME;
		DROP TABLE Dbo.Addresses
		DROP TABLE Dbo.AddressesHistory
	End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Dbo.Addresses
(
	Id				UniqueIdentifier NOT NULL ,
	CustomerId		UniqueIdentifier NOT NULL ,
	IsCurrent		Bit NOT NULL default(0),
	HouseNumber		varchar(10) NOT NULL default(0),
	Property		varchar(75) NULL ,
	StreetName		varchar(75) NOT NULL ,
	Landmark		varchar(75) NULL ,
	Town			varchar(50) NULL ,
	County			varchar(50) NOT NULL,
	Country			varchar(50) NOT NULL,
	Postcode		varchar(15) NOT NULL default(''),
	Accuracy		 varchar(10) NULL,
	ActionedByUserId	UniqueIdentifier NULL ,
    EffectiveFrom	datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
    EffectiveUntil	datetime2  NOT NULL DEFAULT CONVERT(DATETIME2, '9999-12-31 23:59:59.99999999'),
	CONSTRAINT PK_Addresses  PRIMARY KEY (Id)
)
GO

CREATE INDEX IX_Addresses_CustomerId ON Dbo.Addresses (CustomerId)
GO
CREATE INDEX IX_Addresses_Postcode ON Dbo.Addresses (PostCode)
GO
CREATE INDEX IX_Addresses_HouseNumber ON Dbo.Addresses (HouseNumber)
GO
ALTER TABLE Dbo.Addresses ADD PERIOD FOR SYSTEM_TIME (EffectiveFrom,EffectiveUntil);
GO
ALTER TABLE Dbo.Addresses SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Dbo.AddressesHistory));
GO


/*		Table : Customers		*/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Dbo.Customers') AND type in (N'U'))
	Begin
		ALTER TABLE Dbo.Customers SET ( SYSTEM_VERSIONING = OFF  )
		ALTER TABLE Dbo.Customers DROP PERIOD FOR SYSTEM_TIME;
		DROP TABLE Dbo.Customers
		DROP TABLE Dbo.CustomersHistory
	End

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Dbo.Customers
(
	Id UniqueIdentifier  NOT NULL,
    Title varchar(10) NOT NULL Default(''), 
    Forename nVarchar(50) NOT NULL , 
    Initials nVarchar(10) NOT NULL Default('') , 
    Surname nVarchar(50) NOT NULL , 
    Email nVarchar(100) NOT NULL , 
    HashedEmail Varbinary(200) NOT NULL , 
    MobileNumber Varchar(20) NOT NULL , 
    DateofBirth Date NULL, 
	Status smallint NOT NULL Default(0) ,			-- 0-: Inactive, 1- Active 2-Block, 4-Inactive 8-No Comms, 16- BadReviews
	EffectiveFrom datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),	-- Create Default and bind for easy reference
    EffectiveUntil datetime2  NOT NULL DEFAULT CONVERT(DATETIME2, '9999-12-31 23:59:59.99999999'),
	CONSTRAINT PK_Customers  PRIMARY KEY (ID)
)
GO

CREATE INDEX IX_Customers_Forename ON Dbo.Customers (Forename)
GO
ALTER TABLE Dbo.Customers ADD PERIOD FOR SYSTEM_TIME (EffectiveFrom,EffectiveUntil);
GO
ALTER TABLE Dbo.Customers SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Dbo.CustomersHistory));
GO
