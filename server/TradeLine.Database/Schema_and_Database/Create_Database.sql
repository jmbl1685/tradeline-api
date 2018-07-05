DECLARE @DBName NVARCHAR(MAX) = N'TradeLineApp'

IF NOT EXISTS (SELECT name FROM SYS.DATABASES WHERE name = @DBName)
	BEGIN
		DECLARE @sql NVARCHAR(MAX)
		DECLARE @template NVARCHAR(MAX)

		SET @template = N'CREATE DATABASE [{dbName}]'
		SET @sql = REPLACE(@template, '{dbName}', @DBName)
		PRINT REPLACE('The database [{dbName}] has been created.', '{dbName}', @DBName)
		EXECUTE (@sql)
	END
ELSE
	PRINT REPLACE('The database [{dbName}] already exists.', '{dbName}', @DBName)


