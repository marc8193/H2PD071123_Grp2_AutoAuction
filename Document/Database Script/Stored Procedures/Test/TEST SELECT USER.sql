USE [auction]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SelectUser]
		@UserId = 1

SELECT	'Return Value' = @return_value

GO
