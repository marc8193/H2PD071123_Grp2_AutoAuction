USE [auction]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SelectVehicles]
		@BaseVehicleId = 11

SELECT	'Return Value' = @return_value

GO
