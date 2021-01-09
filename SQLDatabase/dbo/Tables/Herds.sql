CREATE TABLE [dbo].[Herds]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [HerdNumber] NVARCHAR(50) NULL UNIQUE, 
    [OwnerId] INT NULL, 
    CONSTRAINT [FK_Herds_ToTable] FOREIGN KEY ([OwnerId]) REFERENCES [Owners]([Id])
)
