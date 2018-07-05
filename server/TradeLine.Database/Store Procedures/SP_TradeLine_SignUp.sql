CREATE PROCEDURE SignUp
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
END