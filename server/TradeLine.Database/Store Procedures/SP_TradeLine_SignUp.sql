CREATE PROCEDURE TradeLine.SignUp
	@UserCode VARCHAR(50),
	@Name VARCHAR(100),
	@Lastname VARCHAR(100),
	@Identification VARCHAR(50),
	@Username VARCHAR(15),
	@Email VARCHAR(30),
	@Password VARCHAR(MAX),
	@ImageURL VARCHAR(MAX),
	@Rol VARCHAR(50)
AS
BEGIN
	BEGIN TRY	
		INSERT INTO [TradeLine].[Users]
			(
				UserCode,
				Name,
				Lastname,
				Identification,
				Username,
				Email,
				Password,
				ImageURL,
				Rol
			) VALUES
			(
				@UserCode,
				@Name,
				@Lastname,
				@Identification,
				@Username,
				@Email,
				@Password,
				@ImageURL,
				@Rol
			)
		IF EXISTS (SELECT UserCode FROM [TradeLine].[Users] WHERE UserCode = @UserCode)
			SELECT 'Success' AS RESPONSE
		ELSE
			SELECT 'Error' AS RESPONSE
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS RESPONSE
	END CATCH
END