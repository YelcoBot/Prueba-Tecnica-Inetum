USE [PruebaInetum]
GO
/****** Object:  Table [dbo].[autor]    Script Date: 6/12/22 8:15:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
	[apellidos] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autor_has_libro]    Script Date: 6/12/22 8:15:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autor_has_libro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[autor_id] [int] NOT NULL,
	[libro_ISBN] [int] NOT NULL,
 CONSTRAINT [PK_autor_has_libro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[editorial]    Script Date: 6/12/22 8:15:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editorial](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
	[sede] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libro]    Script Date: 6/12/22 8:15:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libro](
	[ISBN] [int] IDENTITY(1,1) NOT NULL,
	[editorial_id] [int] NOT NULL,
	[titulo] [nvarchar](45) NOT NULL,
	[sinopsis] [text] NULL,
	[n_paginas] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[autor] ON 

INSERT [dbo].[autor] ([id], [nombre], [apellidos]) VALUES (1, N'William', N'Faulkner')
INSERT [dbo].[autor] ([id], [nombre], [apellidos]) VALUES (4, N'Oscar', N'Wilde')
INSERT [dbo].[autor] ([id], [nombre], [apellidos]) VALUES (5, N'Franz ', N'Kafka')
INSERT [dbo].[autor] ([id], [nombre], [apellidos]) VALUES (6, N'William ', N'Shakespeare')
SET IDENTITY_INSERT [dbo].[autor] OFF
GO
SET IDENTITY_INSERT [dbo].[autor_has_libro] ON 

INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (1, 1, 1)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (2, 4, 1)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (3, 5, 1)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (4, 1, 6)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (5, 4, 6)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (6, 5, 6)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (7, 4, 5)
INSERT [dbo].[autor_has_libro] ([id], [autor_id], [libro_ISBN]) VALUES (8, 4, 7)
SET IDENTITY_INSERT [dbo].[autor_has_libro] OFF
GO
SET IDENTITY_INSERT [dbo].[editorial] ON 

INSERT [dbo].[editorial] ([id], [nombre], [sede]) VALUES (1, N'Alianza Distribuidora de Colombia', N'Bogotá')
INSERT [dbo].[editorial] ([id], [nombre], [sede]) VALUES (2, N'Babel Libros', N'Bogotá')
INSERT [dbo].[editorial] ([id], [nombre], [sede]) VALUES (3, N'Cangrejo Editores', N'Bogotá')
INSERT [dbo].[editorial] ([id], [nombre], [sede]) VALUES (4, N'Círculo de Lectores', N'Bogotá')
SET IDENTITY_INSERT [dbo].[editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[libro] ON 

INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (1, 1, N'Memorias de una geisha', N'Memorias de una geisha', N'1233')
INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (2, 4, N'Nada', N'Andrea es la protagonista de esta historia, una estudiante universitaria recién llegada a Barcelona para completar su formación académica en Letras.', N'456')
INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (3, 2, N'Maria', N'Novela que narra en primera persona el amor de Efraín por su prima María, joven de quince años, enferma de un mal incurable.', N'345')
INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (4, 3, N'El Alquimista', N'Santiago es un pastor andaluz que emprende un viaje por las arenas del desierto en busca de un tesoro.', N'506')
INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (5, 1, N'Matar a un ruiseñor', N'Matar a un ruiseñor', N'3')
INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (6, 1, N'Los juegos del hambre', N'Los juegos del hambre', N'1233')
INSERT [dbo].[libro] ([ISBN], [editorial_id], [titulo], [sinopsis], [n_paginas]) VALUES (7, 2, N'Harry Potter y la piedra filosofal ', N'Harry Potter y la piedra filosofal ', N'1230')
SET IDENTITY_INSERT [dbo].[libro] OFF
GO
ALTER TABLE [dbo].[autor_has_libro]  WITH CHECK ADD  CONSTRAINT [fk_autor_id] FOREIGN KEY([autor_id])
REFERENCES [dbo].[autor] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[autor_has_libro] CHECK CONSTRAINT [fk_autor_id]
GO
ALTER TABLE [dbo].[autor_has_libro]  WITH CHECK ADD  CONSTRAINT [fk_libro_ISBN] FOREIGN KEY([libro_ISBN])
REFERENCES [dbo].[libro] ([ISBN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[autor_has_libro] CHECK CONSTRAINT [fk_libro_ISBN]
GO
ALTER TABLE [dbo].[libro]  WITH CHECK ADD  CONSTRAINT [fk_editorial_id] FOREIGN KEY([editorial_id])
REFERENCES [dbo].[editorial] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[libro] CHECK CONSTRAINT [fk_editorial_id]
GO
