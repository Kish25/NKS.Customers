/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO Dbo.Titles (Name) VALUES ('Not Defined')
INSERT INTO Dbo.Titles (Name) VALUES ('Mr')
INSERT INTO Dbo.Titles (Name) VALUES ('Miss')
INSERT INTO Dbo.Titles (Name) VALUES ('Mrs')
INSERT INTO Dbo.Titles (Name) VALUES ('Ms')
INSERT INTO Dbo.Titles (Name) VALUES ('Inf')
INSERT INTO Dbo.Titles (Name) VALUES ('Mast')