using System;
using System.Collections.Generic;
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
        async public static Task ProcessCurrencyAsync(Currency currency)
        {
            //Console.WriteLine($"Processing currency {currency.Symbol}");
            if (currency.Status == Currency.CurrencyStatus.WaitingForProcessing)
            {
                currency.Status = Currency.CurrencyStatus.Processing;
                if (!File.Exists(string.Format($"sources/{currency.Symbol}-1m-{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}.csv")))
                {
                    Console.WriteLine($"Downloading currency {currency.Symbol}");
                    await Task.Run(() => DownloadCurrencyAsync(currency.Symbol, "1m"));
                    Console.WriteLine($"Currency {currency.Symbol} downloaded!");
                }
                if (!File.Exists(string.Format($"data/{currency.Symbol}-1m-agg.csv")))
                {
                    //Console.WriteLine($"Preparing data for {currency.Symbol}!");
                    DataFrame df = new DataFrame();
                    foreach (string file in Directory.GetFiles("sources", string.Format($"{currency.Symbol}-1m-*.csv")).ToList())
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
                    ProcessResults($"data/{currency}-1m.csv");
                    //Console.WriteLine($"Data for {currency} ready!");
                    currency.Status = Currency.CurrencyStatus.WaitingForProcessing;
                }
                else
                {
                    //Console.WriteLine($"Data for {currency} restoring!");
                    currency.Status = Currency.CurrencyStatus.Searching;
                    DataFrame current_df = DataFrames.CountBinaryData(BinanceApi.BinanceApi.GetKlinesDataFrame($"{currency}", "1m"));
                    current_df = DataFrames.CountRanges(current_df);
                    string binaryData = current_df[current_df.Rows.Count - 1, 45].ToString();
                    string Range_High_Low_One_Minute_Ago = current_df[current_df.Rows.Count - 1, 46].ToString();
                    string Range_High_Low_Two_Minute_Ago = current_df[current_df.Rows.Count - 1, 47].ToString();
                    string Range_High_Low_Three_Minute_Ago = current_df[current_df.Rows.Count - 1, 48].ToString();
                    string Range_High_Low_Four_Minute_Ago = current_df[current_df.Rows.Count - 1, 49].ToString();
                    string Range_High_Low_Five_Minute_Ago = current_df[current_df.Rows.Count - 1, 50].ToString();
                    //--------------------------------//
                    List<DataFrameResultsCombination> results = new List<DataFrameResultsCombination>();
                    StreamReader sr = new StreamReader($"data/{currency}-1m-agg.csv");
                    string line = "";
                    int shouldBuy = 0;
                    int shouldntBuy = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.ToLower().StartsWith($"{currency}|{binaryData}|true|{Range_High_Low_One_Minute_Ago}|{Range_High_Low_Two_Minute_Ago}|{Range_High_Low_Three_Minute_Ago}|{Range_High_Low_Four_Minute_Ago}|{Range_High_Low_Five_Minute_Ago}|".ToLower()))
                        {
                            shouldBuy = Convert.ToInt32(line.Split('|').ToList()[8]);
                        }
                        if (line.ToLower().StartsWith($"{currency}|{binaryData}|false|{Range_High_Low_One_Minute_Ago}|{Range_High_Low_Two_Minute_Ago}|{Range_High_Low_Three_Minute_Ago}|{Range_High_Low_Four_Minute_Ago}|{Range_High_Low_Five_Minute_Ago}|".ToLower()))
                        {
                            shouldntBuy = Convert.ToInt32(line.Split('|').ToList()[8]);
                        }
                    }
                    sr.Close();
                    Console.WriteLine($"Data for {currency} restored!");
                    Console.WriteLine($"Should buy: {shouldBuy}");
                    Console.WriteLine($"Shouldnt buy: {shouldntBuy}");
                    Console.WriteLine($"{currency}|{binaryData}|true|{Range_High_Low_One_Minute_Ago}|{Range_High_Low_Two_Minute_Ago}|{Range_High_Low_Three_Minute_Ago}|{Range_High_Low_Four_Minute_Ago}|{Range_High_Low_Five_Minute_Ago}|");
                    if (shouldBuy > shouldntBuy)
                    {
                        Price price = BinanceApi.BinanceApi.GetCurrentPrice(currency.Symbol);
                        if (price.price < 50)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"Should buy {currency}!");
                            Console.WriteLine();
                            OrdersPair ordersPair = new OrdersPair();
                            Order order = BinanceApi.BinanceApi.CreateOrder(currency.Symbol, Math.Round(15 / price.price, GlobalStore.Symbols.Where(s => s.Symbol == currency.Symbol).Select(s => s.QuantityDecimalPlaces).First()), price.price, "BUY");
                            Console.WriteLine("Order status: " + order.status);
                            if (order.status == "FILLED")
                            {
                                decimal commission = GlobalStore.Symbols.Where(s => s.Symbol == order.symbol).Select(s => s.Commission).First() * order.cummulativeQuoteQty;
                                Order backOrder = BinanceApi.BinanceApi.CreateOrder(currency.Symbol, order.executedQty, Math.Round((order.cummulativeQuoteQty + (order.cummulativeQuoteQty / 100) + commission) / order.executedQty, GlobalStore.Symbols.Where(s => s.Symbol == order.symbol).Select(s => s.PriceDecimalPlaces).First()), "SELL");
                                ordersPair.FirstOrder = order;
                                ordersPair.SecondOrder = order;
                                GlobalStore.Account.Orders.Add(ordersPair);
                            }
                        }
                        else
                        {
                            Console.Write($"Shouldn't buy {currency} because of too high price!");
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"Shouldn't buy {currency}!");
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                    currency.Status = Currency.CurrencyStatus.Processed;
                }
            }
            else
            {
                //Console.WriteLine($"Skipping {currency.Symbol}!");
            }
            //Console.WriteLine($"Currency {currency.Symbol} processed (Async)");
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

        public static void ProcessResults(string fileName)
        {
            List<DataFrameResultsCombination> results = new List<DataFrameResultsCombination>();
            StreamReader sr = new StreamReader(fileName);
            string line = "";
            bool firstLine = true;
            while ((line = sr.ReadLine()) != null)
            {
                if (!firstLine)
                {
                    List<string> fields = line.Split('|').ToList();
                    DataFrameResultsCombination row = new DataFrameResultsCombination()
                    {
                        symbol = fields[43],
                        shouldBuy = fields[44],
                        binary = fields[45],
                        oneMinute = fields[46],
                        twoMinute = fields[47],
                        threeMinute = fields[48],
                        fourMinute = fields[49],
                        fiveMinute = fields[50]
                    };
                    results.Add(row);
                }
                firstLine = false;
            }
            sr.Close();
            //var q = from x in results
            //        group x by x.symbol into g
            //        let count = g.Count()
            //        orderby count descending
            //        select new { Value = g.Key, Count = count };
            var consolidatedChildren = results.GroupBy(c => new
            {
                c.symbol,
                c.shouldBuy,
                c.binary,
                c.oneMinute,
                c.twoMinute,
                c.threeMinute,
                c.fourMinute,
                c.fiveMinute
            }).Select(gcs => new DataFrameResultsCombination()
            {
                symbol = gcs.Key.symbol,
                shouldBuy = gcs.Key.shouldBuy,
                binary = gcs.Key.binary,
                oneMinute = gcs.Key.oneMinute,
                twoMinute = gcs.Key.twoMinute,
                threeMinute = gcs.Key.threeMinute,
                fourMinute = gcs.Key.fourMinute,
                fiveMinute = gcs.Key.fiveMinute,
                count = gcs.Count()
            });
            StreamWriter sw = new StreamWriter(fileName.Replace(".csv", "-agg.csv"));
            foreach (DataFrameResultsCombination res in consolidatedChildren)
            {
                sw.WriteLine($"{res.symbol}|{res.binary}|{res.shouldBuy}|{res.oneMinute}|{res.twoMinute}|{res.threeMinute}|{res.fourMinute}|{res.fiveMinute}|{res.count}");
            }
            sw.Close();
        }
    }
}