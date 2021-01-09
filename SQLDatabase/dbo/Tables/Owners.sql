CREATE TABLE [dbo].[Owners]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [ZipCode] NCHAR(10) NULL, 
    [City] NVARCHAR(50) NULL, 
    [Adress] NVARCHAR(100) NULL
)
