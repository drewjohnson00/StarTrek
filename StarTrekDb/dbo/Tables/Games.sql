CREATE TABLE [dbo].[Games] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [StartTime] SMALLDATETIME   NOT NULL,
    [IsRunning] BIT             NOT NULL,
    [GameState] NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC)
);

