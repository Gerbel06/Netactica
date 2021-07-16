USE [PruebaNetactica]
GO
/****** Object:  Table [dbo].[Aerolinea]    Script Date: 15/07/2021 10:04:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aerolinea](
	[IdAerolinea] [int] NOT NULL,
	[Nombre] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Aerolinea] PRIMARY KEY CLUSTERED 
(
	[IdAerolinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aeropuerto]    Script Date: 15/07/2021 10:04:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aeropuerto](
	[IdAeropuerto] [int] NOT NULL,
	[Nombre] [int] NOT NULL,
 CONSTRAINT [PK_Aeropuerto] PRIMARY KEY CLUSTERED 
(
	[IdAeropuerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 15/07/2021 10:04:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[IdReserva] [int] NOT NULL,
	[IdVuelo] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Precio] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 15/07/2021 10:04:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[IdVuelo] [int] NOT NULL,
	[HoraSalida] [time](7) NOT NULL,
	[AeropuertoOrigen] [int] NOT NULL,
	[HoraLlegada] [time](7) NOT NULL,
	[AeropuertoDestino] [int] NOT NULL,
	[Aerolinea] [int] NOT NULL,
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[IdVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Vuelo] FOREIGN KEY([IdVuelo])
REFERENCES [dbo].[Vuelo] ([IdVuelo])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Vuelo]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Aerolinea] FOREIGN KEY([Aerolinea])
REFERENCES [dbo].[Aerolinea] ([IdAerolinea])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Aerolinea]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Aeropuerto] FOREIGN KEY([AeropuertoOrigen])
REFERENCES [dbo].[Aeropuerto] ([IdAeropuerto])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Aeropuerto]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Aeropuerto1] FOREIGN KEY([AeropuertoDestino])
REFERENCES [dbo].[Aeropuerto] ([IdAeropuerto])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Aeropuerto1]
GO
