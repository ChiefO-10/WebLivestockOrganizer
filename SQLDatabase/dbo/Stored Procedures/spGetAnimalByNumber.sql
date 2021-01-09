CREATE PROCEDURE [dbo].[spGetAnimalByNumber]
@AnimalNumber NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
	SELECT * FROM [dbo].[Livestock]
	WHERE AnimalNumber= @AnimalNumber;
END
