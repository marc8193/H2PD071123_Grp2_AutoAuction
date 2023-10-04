using System;
using System.Collections.Generic;
using AutoAuctionProjekt.Models;
using Microsoft.Data.SqlClient;
using static H2PD071123_Grp2_AutoAuction.ViewModels.HomeScreenUserControlViewModel;
using static H2PD071123_Grp2_AutoAuction.ViewModels.YourBidHistoryUserControlViewModel;

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

	public List<DisplayAuction> SelectAuctions() {
		var list = new List<DisplayAuction> ();
		
		string queryString = 
		$@"		
		DECLARE	@return_value int

		EXEC	@return_value = [dbo].[SelectAllAuction]

		SELECT	'Return Value' = @return_value";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while(reader.Read())
			{
				var obj = new DisplayAuction(Convert.ToString(reader[6])!, Convert.ToDecimal(reader[4]), Convert.ToDateTime(reader[5]));
				
				if (Convert.ToBoolean(reader[3]))
				{
					list.Add(obj);
				}
			}
		}

		return list;
	}

	public List<DisplayAuction> SelectYourAuctions(int userId) {
		var list = new List<DisplayAuction> ();
		
		string queryString = 
		$@"		
		DECLARE	@return_value int

		EXEC @return_value = [dbo].[SelectUserAuction]
			 @UserId = {userId}

		SELECT	'Return Value' = @return_value";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while(reader.Read())
			{
				var obj = new DisplayAuction(Convert.ToString(reader[6])!, Convert.ToDecimal(reader[4]), Convert.ToDateTime(reader[5]));
				
				if (Convert.ToBoolean(reader[3]))
				{
					list.Add(obj);
				}
			}
		}

		return list;
	}

	public List<DisplayBids> SelectYourBids(int userId)
	{
		var list = new List<DisplayBids> ();

		string queryString = 
		$@"
		DECLARE	@return_value int

		EXEC @return_value = [dbo].[FindUserBid]
			 @UserId = {userId}

		SELECT	'Return Value' = @return_value";


		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while(reader.Read())
			{
				var obj = new DisplayBids(Convert.ToDecimal(reader[4]), Convert.ToDateTime(reader[5]));
				list.Add(obj);
			}
		}

		return list;
	}
}