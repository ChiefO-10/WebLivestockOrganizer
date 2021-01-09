CREATE TABLE [dbo].[Livestock] (
    [Id]              INT           NOT NULL IDENTITY,
    [AnimalNumber]	  NVARCHAR (50) NOT NULL,
    [Country]         NVARCHAR (10) NULL,
    [Gender]          NVARCHAR (10) NULL,
    [MotherNumber]    NVARCHAR (50) NULL,
    [FatherNumber]    NVARCHAR (50) NULL,
    [DateOfBirth]     DATE          NULL,
    [HerdNumber]      NVARCHAR (50) NULL,
    [PlaceOfBirth]	  NVARCHAR (50) NULL, 
	[PassportSerial]  NVARCHAR (50) NULL,
	[PassportDate]	  DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Gender]='Female' OR [Gender]='Male'),
    UNIQUE NONCLUSTERED ([AnimalNumber] ASC), 
    CONSTRAINT [FK_Livestock_ToTable] FOREIGN KEY ([HerdNumber]) REFERENCES [Herds]([HerdNumber]) 
);


