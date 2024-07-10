CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [firstName] NCHAR(10) NULL, 
    [lastName] NCHAR(10) NULL, 
    [userName] NCHAR(10) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [gender] NCHAR(10) NOT NULL, 
    [password] VARCHAR(50) NOT NULL
)
