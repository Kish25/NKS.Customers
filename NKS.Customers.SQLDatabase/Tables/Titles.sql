
CREATE TABLE Dbo.Titles 
(
	Id Int Identity(1,1) NOT NULL ,
	Name varchar(25) NOT NULL ,									-- Customer, Supplier, Staff, 
    DateAdded datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),		-- Create Default and bind for easy reference
    DateModified datetime2  NOT NULL DEFAULT SYSUTCDATETIME(),
	CONSTRAINT PK_Titles  PRIMARY KEY (ID)
)