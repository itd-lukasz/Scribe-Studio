using binanceBotNetCore.Logic.BinanceApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.Engine
{
    public static class SQL
    {
        public static string GetConnection()
        {
            SqlConnectionStringBuilder cnB = new SqlConnectionStringBuilder()
            {
                DataSource = "itd-binance-dev.database.windows.net",
                InitialCatalog = "itd-binance-dev-db",
                UserID = "itd-binance-dev-admin",
                Password = "XnpQ96ymI8jI"
            };
            return cnB.ConnectionString;
        }

        public static void SaveBalance(Balance balance, Price price, DateTime date)
        {
            Console.Write("Saving balance...");
            using (SqlConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Balance] ([blc_date], [blc_asset], [blc_free],
                                                                 [blc_locked], [blc_price], [blc_value])
                                                         VALUES (@date, @asset, @free, @locked, @price, @value)";
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@asset", balance.asset);
                cmd.Parameters.AddWithValue("@free", balance.free);
                cmd.Parameters.AddWithValue("@locked", balance.locked);
                cmd.Parameters.AddWithValue("@price", price.price);
                cmd.Parameters.AddWithValue("@value", (balance.free + balance.locked) * price.price);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            Console.WriteLine("done!");
        }

        public static DateTime LastBalanceDate()
        {
            DateTime date = DateTime.Now.AddHours(-4);
            using (SqlConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT ISNULL(MAX([blc_date]), DATEADD(HH, -4, GETDATE())) FROM [dbo].[Balance]";
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    date = Convert.ToDateTime(dr.GetValue(0));
                }
                dr.Close();
                cn.Close();
            }
            return date;
        }
    }
}
