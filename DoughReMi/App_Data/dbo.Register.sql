CREATE TABLE [dbo].[Register] (
    [Id]        INT          NOT NULL,
    [firstName] NCHAR (10)   NULL,
    [lastName]  NCHAR (10)   NULL,
    [userName]  NCHAR (10)   NULL,
    [email]     NCHAR(10) NULL,
    [gender]    NCHAR (10)   NULL,
    [password]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

