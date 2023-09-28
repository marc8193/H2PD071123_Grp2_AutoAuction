USE [auction]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SelectBus]
		@BaseVehicleId = 25

SELECT	'Return Value' = @return_value

GO
