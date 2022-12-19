SET IDENTITY_INSERT [dbo].[Partidos] ON
INSERT INTO [dbo].[Partidos] ([Id], [FechaHora], [Discriminator], [Nombre]) VALUES (1, N'2022-11-15 00:00:00', N'PartidoDeGrupo', N'A')
INSERT INTO [dbo].[Partidos] ([Id], [FechaHora], [Discriminator], [Nombre]) VALUES (2, N'2022-11-15 00:00:00', N'PartidoDeGrupo', N'A')
INSERT INTO [dbo].[Partidos] ([Id], [FechaHora], [Discriminator], [Nombre]) VALUES (3, N'2022-11-20 00:00:00', N'PartidoDeGrupo', N'B')
SET IDENTITY_INSERT [dbo].[Partidos] OFF
