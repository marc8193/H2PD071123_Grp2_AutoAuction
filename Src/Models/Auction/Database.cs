using System;
using Microsoft.Data.SqlClient;

namespace H2PD071123_Grp2_AutoAuction;

public partial class Database
{
    public int SetForSale(int baseVehicleId, int userId, decimal minBid)
    {
		string queryString = 
        $@"DECLARE @AuctionId int

        EXEC [dbo].[SetForSale]
		@VehicleId = {baseVehicleId},
		@UserId = {userId},
		@Visible = 1,
		@MinPrice = {minBid},
		@EndDate = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}',
		@AuctionId = @AuctionId OUTPUT

        SELECT	@AuctionId as N'@AuctionId'";

        SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@AuctionId"]);
		}
    }
}