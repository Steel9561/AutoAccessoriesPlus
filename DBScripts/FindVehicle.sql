USE [AutoAccessoriesPlus]
GO

/****** Object:  StoredProcedure [dbo].[FindVehicle]    Script Date: 11/2/2020 4:05:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindVehicle] 	
@SearchTerm VARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;		
	SELECT * FROM Vehicles WHERE Make like '%' + @SearchTerm + '%'
END
GO