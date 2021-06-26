
CREATE TABLE Dbo.Customers
(
	Id bigint Identity(1,1) NOT NULL,
    TitleID Int NOT NULL Default(0), 
    Forename nVarchar(50) NOT NULL , 
    Initials nVarchar(10) NOT NULL Default('') , 
    Surname nVarchar(50) NOT NULL , 
    DateofBirth Date NULL, 
	Status smallint NOT NULL Default(0) ,			-- 0-: Inactive, 1- Active 2-Block, 4-Inactive 8-No Comms, 16- BadReviews
	EffectiveFrom datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),	-- Create Default and bind for easy reference
    EffectiveUntil datetime2  NOT NULL DEFAULT CONVERT(DATETIME2, '9999-12-31 23:59:59.99999999'),
	CONSTRAINT PK_Customers  PRIMARY KEY (ID)
)
GO

CREATE INDEX IX_Customers_Title ON Dbo.Customers (TitleID)
GO
CREATE INDEX IX_Customers_Forename ON Dbo.Customers (Forename)
GO
ALTER TABLE Dbo.Customers ADD PERIOD FOR SYSTEM_TIME (EffectiveFrom,EffectiveUntil);
GO
ALTER TABLE Dbo.Customers SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Dbo.CustomersHistory));
GO
