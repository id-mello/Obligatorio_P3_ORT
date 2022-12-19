SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT INTO [dbo].[Roles] ([Id], [Nombre], [Descripcion], [UsuariosId]) VALUES (1, N'Admin', N'A todas las funcionalidades sin excepción', 2)
INSERT INTO [dbo].[Roles] ([Id], [Nombre], [Descripcion], [UsuariosId]) VALUES (2, N'Apostador', N'Accede a las búsquedas y a obtener un grupo con su fixture', 3)
INSERT INTO [dbo].[Roles] ([Id], [Nombre], [Descripcion], [UsuariosId]) VALUES (3, N'Invitado', N'Accede al fixture, a buscar una selección y al listado de todas las selecciones', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
