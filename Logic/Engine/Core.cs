using System;
using System.IO;
using System.Linq;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Helpers;
using Microsoft.Data.Analysis;

namespace binanceBotNetCore.Logic.Engine
{
    public static class Core
    {
        public static void ProcessCurrency(string currency)
        {
            if (!File.Exists(string.Format($"sources/{currency}-1m-{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}.csv")))
            {
                DownloadCurrency(currency, "1m");
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
            }
            else
            {
                DataFrame df = DataFrame.LoadCsv($"data/{currency}-1m.csv", '|');
                Console.WriteLine(df.Rows);
            }
        }

        private static void DownloadCurrency(string currency, string interval)
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