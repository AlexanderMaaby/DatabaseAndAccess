ALTER TABLE [dbo].[Assistant] 
ADD [HeroId] INT NOT NULL

ALTER TABLE [dbo].[Assistant] 
ADD CONSTRAINT FK_HeroId
FOREIGN KEY ([HeroId]) 
REFERENCES [dbo].[Superhero] ([HeroId])
