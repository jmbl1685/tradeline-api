CREATE PROCEDURE TradeLine.SignIn
	@Account VARCHAR(30),
	@Password VARCHAR(MAX)
AS
BEGIN
	SELECT 
		UserCode,
		Name,
		Lastname,
		Identification,
		Username,
		Email,
		Password,
		ImageURL,
		Rol
	FROM [TradeLine].[Users]
	WHERE Email = @Account OR Username = @Account
END