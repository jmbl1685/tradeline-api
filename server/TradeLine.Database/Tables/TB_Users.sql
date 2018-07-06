﻿CREATE TABLE TradeLine.Users(
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserCode VARCHAR(50) NOT NULL UNIQUE,
	Name VARCHAR(100) NOT NULL,
	Lastname VARCHAR(100) NOT NULL,
	Identification VARCHAR(50) NOT NULL,
	Username VARCHAR(15) NOT NULL UNIQUE,
	Email VARCHAR(30) NOT NULL UNIQUE,
	Password VARCHAR(MAX) NOT NULL,
	ImageURL VARCHAR(MAX) NOT NULL,
	Rol VARCHAR(50) NOT NULL
)