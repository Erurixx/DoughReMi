CREATE TABLE [dbo].[qTable] (
    [qId]      INT            IDENTITY (1, 1) NOT NULL,
    [question] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([qId] ASC)
);

