CREATE PROCEDURE [dbo].[spDeleteAnimal]
	@ID int = 0
AS
BEGIN
	 DELETE FROM [dbo].[Livestock] WHERE Id = @ID
END
