CREATE TABLE [dbo].[GameUser] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [GameId] INT NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_GameUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

