CREATE TABLE [dbo].[PowerConnect] (
HeroId int NOT NULL,
PowerId int NOT NULL,
CONSTRAINT PK_ConnectionId PRIMARY KEY (HeroId, PowerId),
FOREIGN KEY (HeroId) REFERENCES [dbo].[Superhero] ([HeroId]),
FOREIGN KEY (PowerId) REFERENCES [dbo].[Power] ([PowerId]),
);
