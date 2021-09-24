using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Engine;
using binanceBotNetCore.Logic.Helpers;
using binanceBotNetCore.Logic.Tools;
using Microsoft.Data.Analysis;

namespace binanceBotNetCore
{
    class Program
    {
        static void Main()
        {
            Console.ResetColor();
            GlobalStore.Symbols = BinanceApi.ExchangeInfo();
            //BinanceApi.AccountStatus();
            //Price price = BinanceApi.GetCurrentPrice("TRXUSDT");
            ////Console.WriteLine(price);
            //BinanceApi.GetAllTrades("TRXUSDT");
            //BinanceApi.GetOrder("TRXUSDT", "9863");
            ////BinanceApi.ExchangeInfo();
            //try
            //{
            //    Order order = BinanceApi.CreateOrder("TRXUSDT", Math.Round(15 / price.price, 1), price.price-1, "BUY");
            //    if (order.status == "FILLED")
            //    {
            //        decimal commission = GlobalStore.Symbols.Where(s => s.Symbol == order.symbol).Select(s => s.Commission).First() * order.cummulativeQuoteQty;
            //        Order backOrder = BinanceApi.CreateOrder("TRXUSDT", order.executedQty, Math.Round((order.cummulativeQuoteQty + (order.cummulativeQuoteQty / 100) + commission) / order.executedQty, 5), "SELL");
            //        Console.WriteLine("done!");
            //    }
            //}
            //catch(Exception exc)
            //{
            //    Console.WriteLine(exc.Message);
            //}
            //BinanceApi.AccountStatus();
            //Console.ReadKey();
            //binanceBotNetCore.Logic.BinanceApi.BinanceApi.GetCurrentPrice("IDEXUSDT");
            //Console.WriteLine("-----");
            //binanceBotNetCore.Logic.BinanceApi.BinanceApi.GetKlinesDataFrame("IDEXUSDT", "1m");
            //Core.ProcessResults("data/AVAXUSDT-1m.csv");
            MainAsync().Wait();
            // or, if you want to avoid exceptions being wrapped into AggregateException:
            //  MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            Console.WriteLine("Binance Bot .Net Core");
            GlobalStore.Account = new Account();
            GlobalStore.Account.LoadAccount();
            List<Price> prices = new List<Price>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddHours(6);
            if (!Directory.Exists("sources"))
            {
                Directory.CreateDirectory("sources");
            }
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            if (!Directory.Exists("sources/download"))
            {
                Directory.CreateDirectory("sources/download");
            }
            // Task.Run(() => Core.ProcessCurrencyAsync("IDEXUSDT"));
            // BinanceApi.DownloadFile("IDEXUSDT", "1m", DateTime.Now.AddDays(-1));
            // DataFrames.CountBinaryData(Kline.ParseCsv("sources/IDEXUSDT-1m-2021-09-19.csv"));
            Console.WriteLine($"Start time: {startTime.ToLongTimeString()}, End time: {endTime.ToLongTimeString()}");
            while (startTime < endTime)
            {
                try
                {
                    //Console.WriteLine($"Current time: {startTime.ToLongTimeString()}, End time: {endTime.ToLongTimeString()}");
                    prices = BinanceApi.GetInterestingCurrenciesAsync(prices);
                    startTime = DateTime.Now;
                    GlobalStore.Account.ProcessOrders();
                    GlobalStore.Account.SaveAccount();
                    Thread.Sleep(10000);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("Exception in main method!");
                    Console.WriteLine(exc.Message);
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                }
            }
            GlobalStore.Account.SaveAccount();
        }
    }
}