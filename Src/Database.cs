using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Tmds.DBus.Protocol;

namespace H2PD071123_Grp2_AutoAuction;

public partial class Database
{
    private static readonly Lazy<Database> lazy = 
    new Lazy<Database>(() => new Database());

    public static Database Instance { get; set; } = lazy.Value;
    private Database()
    {
        this.ConnectionStr = MakeConnectionString();
        this.Connection = new SqlConnection(this.ConnectionStr);

        SqlCommand cmd = new SqlCommand("UpdateAuctionVisibility", Connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        Connection.Open();
    }

    private SqlConnection Connection { get; set; }

    private string ConnectionStr { get; set; }

    private string MakeConnectionString()
    {
        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
        sqlBuilder.DataSource = "docker.data.techcollege.dk,20002";
        sqlBuilder.InitialCatalog = "auction";
        sqlBuilder.UserID = "sa";
        sqlBuilder.Password = "H2PD071123_Gruppe2";
        sqlBuilder.Encrypt = false;

        return sqlBuilder.ToString();
    }
}