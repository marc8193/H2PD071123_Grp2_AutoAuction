using System;
using AutoAuctionProjekt.Models;
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

	public Boolean IsUserValid(string username, string password)
	{
		string queryString =
		$@"
		SELECT
			CASE WHEN EXISTS
			(SELECT name
			FROM sys.database_principals
			WHERE name = '{username}')
			THEN 1
			ELSE 0
		END
		";

		SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToBoolean(reader[0]);
		}
	}
}