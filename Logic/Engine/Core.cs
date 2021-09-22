using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Helpers;
using Microsoft.Data.Analysis;

namespace binanceBotNetCore.Logic.Engine
{
    public static class Core
    {
        async public static Task ProcessCurrencyAsync(string currency)
        {
            if (!File.Exists(string.Format($"sources/{currency}-1m-{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}.csv")))
            {
                Console.WriteLine($"Downloading currency {currency}");
                await Task.Run(() => DownloadCurrencyAsync(currency, "1m"));
            }
            if (!File.Exists(string.Format($"data/{currency}-1m.csv")))
            {
                DataFrame df = new DataFrame();
                foreach (string file in Directory.GetFiles("sources", string.Format($"{currency}-1m-*.csv")).ToList())
                {
                    DataFrame local_df = DataFrames.CountBinaryData(Kline.ParseCsv(file));
                    local_df = DataFrames.CountRanges(local_df);
                    if (df.Columns.Count == 0)
                    {
                        foreach (DataFrameColumn column in local_df.Columns)
                        {
                            df.Columns.Add(column);
                        }
                    }
                    df.Append(local_df.Rows);
                }
                DataFrame.WriteCsv(df, $"data/{currency}-1m.csv", '|');
                Console.WriteLine($"Data for {currency} ready!");
            }
            else
            {
                DataFrame global_df = DataFrame.LoadCsv($"data/{currency}-1m.csv", '|');
                Console.WriteLine($"Data for {currency} restored!");
                DataFrame current_df = DataFrames.CountBinaryData(BinanceApi.BinanceApi.GetKlinesDataFrame($"{currency}", "1m"));
                current_df = DataFrames.CountRanges(current_df);
                string binaryData = current_df[current_df.Rows.Count-1, 45].ToString();
                string Range_High_Low_One_Minute_Ago = current_df[current_df.Rows.Count-1, 45].ToString();
                string Range_High_Low_Two_Minute_Ago = current_df[current_df.Rows.Count-1, 46].ToString();
                string Range_High_Low_Three_Minute_Ago = current_df[current_df.Rows.Count-1, 47].ToString();
                string Range_High_Low_Four_Minute_Ago = current_df[current_df.Rows.Count-1, 48].ToString();
                string Range_High_Low_Five_Minute_Ago = current_df[current_df.Rows.Count-1, 49].ToString();
                Console.WriteLine($"Current data for {currency} loaded and looking for {binaryData} data!");
                global_df = global_df.Filter(global_df.Columns["BinaryData"].ElementwiseEquals(binaryData));
                global_df = global_df.Filter(global_df.Columns["Range_High_Low_One_Minute_Ago"].ElementwiseEquals(Range_High_Low_One_Minute_Ago));
                global_df = global_df.Filter(global_df.Columns["Range_High_Low_Two_Minute_Ago"].ElementwiseEquals(Range_High_Low_Two_Minute_Ago));
                global_df = global_df.Filter(global_df.Columns["Range_High_Low_Three_Minute_Ago"].ElementwiseEquals(Range_High_Low_Three_Minute_Ago));
                global_df = global_df.Filter(global_df.Columns["Range_High_Low_Four_Minute_Ago"].ElementwiseEquals(Range_High_Low_Four_Minute_Ago));
                global_df = global_df.Filter(global_df.Columns["Range_High_Low_Five_Minute_Ago"].ElementwiseEquals(Range_High_Low_Five_Minute_Ago));
                if (global_df.Rows.Count > 0)
                {
                    DataFrame rows_shouldBuy = global_df.Clone();
                    DataFrame rows_shouldntBuy = global_df.Clone();
                    rows_shouldBuy = rows_shouldBuy.Filter(rows_shouldBuy.Columns["ShouldBuy"].ElementwiseEquals("True"));
                    rows_shouldntBuy = rows_shouldBuy.Filter(rows_shouldBuy.Columns["ShouldBuy"].ElementwiseEquals("False"));
                    if (rows_shouldBuy.Rows.Count > rows_shouldntBuy.Rows.Count)
                    {
                        Console.WriteLine($"Should buy {currency}!");
                    }
                    else
                    {
                        Console.WriteLine($"Shouldn't buy {currency}!");
                    }
                }
                else
                {
                    Console.WriteLine($"There is no example data for {currency} and {binaryData}!");
                }
            }
        }

        async private static void DownloadCurrencyAsync(string currency, string interval)
        {
            for (int i = 1; i < 32; i++)
            {
                if (!File.Exists(string.Format($"sources/{currency}-1m-{DateTime.Now.AddDays(i * -1).ToString("yyyy-MM-dd")}.csv")))
                {
                    try
                    {
                        BinanceApi.BinanceApi.DownloadFile(currency, interval, DateTime.Now.AddDays(i * -1));
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine($"Error while downloading file {currency}-1m-{DateTime.Now.AddDays(i * -1).ToString("yyyy-MM-dd")}.zip !");
                        Console.WriteLine(exc.Message);
                    }
                }
            }
        }
    }
}