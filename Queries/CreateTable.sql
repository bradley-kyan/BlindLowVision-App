CREATE TABLE SupportUser(
	UserID uniqueidentifier  NOT NULL default newid() PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
	Password VARCHAR(255) NOT NULL,
	First_Name VARCHAR(25),
	Last_Name VARCHAR(25) NOT NULL,
	Branch VARCHAR(50) NOT NULL
)