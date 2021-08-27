CREATE TABLE [dbo].[Superhero]
(
    [HeroId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(30) NOT NULL,
    [Alias] NVARCHAR(30) NOT NULL,
	PRIMARY KEY ([HeroId])
)
GO
CREATE TABLE [dbo].[Assistant]
(
    [AssistantId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(120),
	PRIMARY KEY ([AssistantId])
);
CREATE TABLE [dbo].[Power]
(
    [PowerId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(120),
	[Description] NVARCHAR(120),
	PRIMARY KEY ([PowerId])
);