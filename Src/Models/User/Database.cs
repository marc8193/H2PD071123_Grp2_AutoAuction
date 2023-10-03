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
		@SocialSecurityNumber = N'202020',
		--@Cvr = N'20',
		@Balance = 200,
		@PrivatUserId = @PrivatUserId OUTPUT,
		@FirmUserId = @FirmUserId OUTPUT,
		@ZipCode = N'9320',
		@UserId = @UserId OUTPUT,
		@Credit = 0

		SELECT @UserId as N'@UserId'";

        SqlCommand command = new SqlCommand(queryString, this.Connection);

		using (SqlDataReader reader = command.ExecuteReader())
		{
			reader.Read();

			return Convert.ToInt32(reader["@UserId"]);
		}
    }
}