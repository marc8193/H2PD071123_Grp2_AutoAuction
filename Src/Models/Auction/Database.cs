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

	// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//HARALDUR DET GRIM MEN DET VIRKER

	public void CreateBid(int userId, int auctionId, decimal minBid)
	{
		string queryString =
		$@"
		EXEC	[dbo].[CreateBid]
		@UserId = {userId},
		@AuctionId = {auctionId},
		@Status = N'No',
		@BidAmount = {minBid}";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();
			// Console.WriteLine(reader["@return_value"]);
		}
	}


	public SelectedAuction SelecThisAuction(int baseVehicleId)
	{
		string queryString =
		$@"
		EXEC [dbo].[SelectThisAuction]
		@AuctionId = {baseVehicleId}";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();
			var obj = new SelectedAuction(
				Convert.ToInt32(reader["Id"]),
				Convert.ToInt32(reader["VehicleId"]),
				Convert.ToInt32(reader["UserId"]),
				Convert.ToBoolean(reader["Visible"]),
				Convert.ToDecimal(reader["MinPrice"]),
				Convert.ToDateTime(reader["EndDate"]),
				Convert.ToString(reader["Name"])!,
				Convert.ToInt32(reader["Km"]),
				Convert.ToString(reader["Registration"])!,
				Convert.ToInt32(reader["Year"]),
				Convert.ToBoolean(reader["Towbar"]),
				Convert.ToDecimal(reader["EngineSize"]),
				Convert.ToInt32(reader["KmPr"]),
				Convert.ToString(reader["LicensTypes"])!,
				Convert.ToString(reader["EnergyClass"])!,
				Convert.ToString(reader["Fuel"])!,
				Convert.ToInt32(reader["BaseVehicleId"]),
				Convert.ToDecimal(reader["NewestBidAmount"])
			);
			// Console.WriteLine(reader["@return_value"]);
			return obj;
		}
	}

	public class SelectedAuction
	{
		public SelectedAuction(
			int id,
			int vehicleId,
			int userId,
			bool visible,
			decimal minPrice,
			DateTime endDate,
			string name,
			int km,
			string registration,
			int year,
			bool towbar,
			decimal engineSize,
			int kmPr,
			string licensTypes,
			string energyClass,
			string fuel,
			int baseVehicleId,
			decimal newestBidAmount)
		{
			Id = id;
			VehicleId = vehicleId;
			UserId = userId;
			Visible = visible;
			MinPrice = minPrice;
			EndDate = endDate;
			Name = name;
			Km = km;
			Registration = registration;
			Year = year;
			Towbar = towbar;
			EngineSize = engineSize;
			KmPr = kmPr;
			LicensTypes = licensTypes;
			EnergyClass = energyClass;
			Fuel = fuel;
			BaseVehicleId = baseVehicleId;
			NewestBidAmount = newestBidAmount;
		}

		public int Id { get; set; }
		public int VehicleId { get; set; }
		public int UserId { get; set; }
		public bool Visible { get; set; }
		public decimal MinPrice { get; set; }
		public DateTime EndDate { get; set; }
		public string Name { get; set; }
		public int Km { get; set; }
		public string Registration { get; set; }
		public int Year { get; set; }
		public bool Towbar { get; set; }
		public decimal EngineSize { get; set; }
		public int KmPr { get; set; }
		public string LicensTypes { get; set; }
		public string EnergyClass { get; set; }
		public string Fuel { get; set; }
		public int BaseVehicleId { get; set; }
		public decimal NewestBidAmount { get; set; }
	}
	// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public List<DisplayAuction> SelectAuctions()
	{
		var list = new List<DisplayAuction>();

		string queryString =
		$@"		
		DECLARE	@return_value int

		EXEC	@return_value = [dbo].[SelectAllAuction]

		SELECT	'Return Value' = @return_value";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				var obj = new DisplayAuction(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToString(reader[6])!, Convert.ToDecimal(reader[8]), Convert.ToDateTime(reader[5]));

				if (Convert.ToBoolean(reader[3]))
				{
					list.Add(obj);
				}
			}
		}

		return list;
	}

	public List<DisplayAuction> SelectYourAuctions(int userId)
	{
		var list = new List<DisplayAuction>();

		string queryString =
		$@"		
		DECLARE	@return_value int

		EXEC @return_value = [dbo].[SelectUserAuction]
			 @UserId = {userId}

		SELECT	'Return Value' = @return_value";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				var obj = new DisplayAuction(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToString(reader[6])!, Convert.ToDecimal(reader[8]), Convert.ToDateTime(reader[5]));

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
		var list = new List<DisplayBids>();

		string queryString =
		$@"
		DECLARE	@return_value int

		EXEC @return_value = [dbo].[FindUserBid]
			 @UserId = {userId}

		SELECT	'Return Value' = @return_value";


		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				var obj = new DisplayBids(Convert.ToDecimal(reader[4]), Convert.ToDateTime(reader[5]));
				list.Add(obj);
			}
		}

		return list;
	}

}