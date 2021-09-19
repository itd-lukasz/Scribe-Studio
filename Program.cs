using System;
using System.Collections.Generic;
using System.Threading;
using binanceBotNetCore.Logic.BinanceApi;

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
