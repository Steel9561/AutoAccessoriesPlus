USE [AutoAccessoriesPlus]
GO

/****** Object:  StoredProcedure [dbo].[VehiclePagination]    Script Date: 11/2/2020 4:06:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VehiclePagination] 	
@PageNumber int,
@PageSize int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @sqlToExecute NVARCHAR(1200)

	SET @sqlToExecute=
	'SELECT Id,Make,Model,Type,Year,VehicleImage From Vehicles ORDER BY ID' +
	' OFFSET ' + CONVERT(VARCHAR(10),@PageSize) + '*' + '(' + CONVERT(VARCHAR(10),@PageNumber) + '-' +'1) ROWS FETCH NEXT ' +
	CONVERT(VARCHAR(10),@PageSize) + ' ROWS ONLY OPTION (RECOMPILE);';

	EXEC sp_executesql @sqlToExecute
END
GO