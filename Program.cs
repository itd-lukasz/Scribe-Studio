using System;
using System.Collections.Generic;
using System.IO;
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
            //binanceBotNetCore.Logic.BinanceApi.BinanceApi.AccountStatus();
            //binanceBotNetCore.Logic.BinanceApi.BinanceApi.CreateOrder("ETHUSDT", 1);
            MainAsync().Wait();
            // or, if you want to avoid exceptions being wrapped into AggregateException:
            //  MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            Console.WriteLine("Binance Bot .Net Core");
            Account account = new Account();
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
                Console.WriteLine($"Current time: {startTime.ToLongTimeString()}, End time: {endTime.ToLongTimeString()}");
                prices = BinanceApi.GetInterestingCurrenciesAsync(prices, account);
                startTime = DateTime.Now;
                Thread.Sleep(10000);
            }
            account.SaveAccount();
        }
    }
}