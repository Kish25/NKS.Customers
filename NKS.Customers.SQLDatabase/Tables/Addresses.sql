
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
