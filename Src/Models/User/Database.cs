using System;
using AutoAuctionProjekt.Models;
using H2PD071123_Grp2_AutoAuction.ViewModels;
using H2PD071123_Grp2_AutoAuction.Views;
using Microsoft.Data.SqlClient;

namespace H2PD071123_Grp2_AutoAuction;

public partial class Database
{
	public int InsertUser(User user)
	{
		string queryString =
		$@"DECLARE	@PrivatUserId int,
		@FirmUserId int,
		@UserId int

		EXEC [dbo].[CreateUser]
		@UserName = {user.UserName},
		@Password = N'{user.Password}',
		{(user is PrivateUser ? $"@SocialSecurityNumber = {((PrivateUser)user).CPRNumber}" : $"@Cvr = {((CorporateUser)user).CVRNumber}")},
		@Balance = {user.Balance},
		@PrivatUserId = @PrivatUserId OUTPUT,
		@FirmUserId = @FirmUserId OUTPUT,
		@ZipCode = {user.Zipcode},
		@UserId = @UserId OUTPUT,
		@Credit = {(user is PrivateUser ? 0 : ((CorporateUser)user).Credit)}
		SELECT @UserId as N'@UserId'";


		SqlCommand command = new SqlCommand(queryString, this.Connection);
		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@UserId"]);
		}
	}

	public int SelectUserId(string username)
	{
		string queryString =
		$@"
		SELECT Id 
		FROM Users 
		WHERE Name = '{username}'
		";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			try
			{
				reader.Read();
				return Convert.ToInt32(reader[0]);
				
			}
			catch (System.InvalidOperationException)
			{
				return -1;
			}
		}
	}

	public YourProfileUserControlViewModel SelectUserById(int userId)
	{
		string queryString =
		$@"
		DECLARE @UserId int

		EXEC [dbo].[SelectUser]
			@UserId = {userId}
		";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			var obj = new YourProfileUserControlViewModel(Convert.ToString(reader[3])!, Convert.ToDecimal(reader[7]));

			return obj;
		}
	}
}