USE [AutoAccessoriesPlus]
GO

/****** Object:  Table [dbo].[VehicleBrandAccessories]    Script Date: 11/2/2020 4:12:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleBrandAccessories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RelatedAccessoryId] [int] NULL,
	[VehicleId] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_VehicleBrandAccessories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[VehicleBrandAccessories]  WITH CHECK ADD  CONSTRAINT [FK_VehicleBrandAccessories_Accessory_RelatedAccessoryId] FOREIGN KEY([RelatedAccessoryId])
REFERENCES [dbo].[Accessory] ([Id])
GO

ALTER TABLE [dbo].[VehicleBrandAccessories] CHECK CONSTRAINT [FK_VehicleBrandAccessories_Accessory_RelatedAccessoryId]
GO

ALTER TABLE [dbo].[VehicleBrandAccessories]  WITH CHECK ADD  CONSTRAINT [FK_VehicleBrandAccessories_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VehicleBrandAccessories] CHECK CONSTRAINT [FK_VehicleBrandAccessories_Vehicles_VehicleId]
GO


