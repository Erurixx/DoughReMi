CREATE TABLE [dbo].[Quizzes_Score] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] NVARCHAR (50) NULL,
    [title]    NVARCHAR (50) NULL,
    [score]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

