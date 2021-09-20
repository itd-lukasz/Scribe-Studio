using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Helpers;

namespace binanceBotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binance Bot .Net Core");
            List<Price> prices = new List<Price>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddMinutes(30);
            if (!Directory.Exists("sources"))
            {
                Directory.CreateDirectory("sources");
            }
            if (!Directory.Exists("sources/download"))
            {
                Directory.CreateDirectory("sources/download");
            }
            BinanceApi.DownloadFile("IDEXUSDT", "1m", DateTime.Now.AddDays(-1));
            Console.WriteLine(Kline.ParseCsv("sources/IDEXUSDT-1m-2021-09-19.csv").Rows.Count);
            Console.WriteLine($"Start time: {startTime.ToLongTimeString()}, End time: {endTime.ToLongTimeString()}");
            while (startTime < endTime)
            {
                Console.WriteLine($"Current time: {startTime.ToLongTimeString()}, End time: {endTime.ToLongTimeString()}");
                prices = BinanceApi.GetInterestingCurrenciesAsync(prices);
                Thread.Sleep(10000);
                startTime = DateTime.Now;
            }
        }
    }
}
