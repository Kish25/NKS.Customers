
CREATE TABLE Dbo.Addresses
(
	Id				UniqueIdentifier NOT NULL ,
	CustomerId		UniqueIdentifier NOT NULL ,
	IsCurrent		Bit NOT NULL default(0),
	Address1		varchar(50) NOT NULL default(0),
	Address2		varchar(50) NULL ,
	Address3		varchar(50) NOT NULL ,
	Town			varchar(50) NULL ,
	County			varchar(50) NOT NULL,
	Country			varchar(50) NOT NULL,
	Postcode		varchar(15) NOT NULL default(''),
	CONSTRAINT PK_Addresses  PRIMARY KEY (Id)
)
GO

CREATE INDEX IX_Addresses_CustomerId ON Dbo.Addresses (CustomerId)
GO
CREATE INDEX IX_Addresses_Postcode ON Dbo.Addresses (PostCode)
GO
CREATE INDEX IX_Addresses_HouseNumber ON Dbo.Addresses (Address1)