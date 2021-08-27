INSERT INTO [dbo].[Power] ([Name], [Description]) VALUES ('Flight', 'The hero can fly.');
INSERT INTO [dbo].[Power] ([Name], [Description]) VALUES ('Strength', 'Hero stronk');
INSERT INTO [dbo].[Power] ([Name], [Description]) VALUES ('Money', 'The hero is rich af');
INSERT INTO [dbo].[Power] ([Name], [Description]) VALUES ('Underwater breathing', 'Can breathe underwater najs');
INSERT INTO [dbo].[PowerConnect] ([HeroId], [PowerId]) VALUES (1, 1);
INSERT INTO [dbo].[PowerConnect] ([HeroId], [PowerId]) VALUES (1, 2);
INSERT INTO [dbo].[PowerConnect] ([HeroId], [PowerId]) VALUES (2, 2);
INSERT INTO [dbo].[PowerConnect] ([HeroId], [PowerId]) VALUES (2, 3);
INSERT INTO [dbo].[PowerConnect] ([HeroId], [PowerId]) VALUES (3, 4);