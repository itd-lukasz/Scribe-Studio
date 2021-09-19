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
            for (int i = 0; i<10; i++)
            {
                prices = BinanceApi.GetInterestingCurrenciesAsync(prices);
                Thread.Sleep(5000);
            }
        }
    }
}
