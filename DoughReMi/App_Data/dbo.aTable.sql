CREATE TABLE [dbo].[aTable] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [qId]     INT            NOT NULL,
    [Comment] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([qId]) REFERENCES [dbo].[qTable] ([qId])
);

