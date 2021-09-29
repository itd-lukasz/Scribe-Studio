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
            Console.Clear();
            Console.ResetColor();
            GlobalStore.Symbols = BinanceApi.ExchangeInfo();
            //var s = GlobalStore.Symbols.Where(s => s.Symbol == "ARPAUSDT").First();
            //var s2 = GlobalStore.Symbols.Where(s => s.Symbol == "ZILUSDT").First();
            GlobalStore.Units = 10;
            GlobalStore.Percent = 0.2m;
            GlobalStore.OrderValue = 23;
            //recvWindow=5000&symbol=ARPAUSDT&side=SELL&type=LIMIT&quantity=189.21060000&timeInForce=GTC&timestamp=1632860971691&price=0.06886
            //BinanceApi.CreateOrder("ARPAUSDT", )
            //BinanceApi.GetTrade("ARPAUSDT", "188770090");
            //var o = BinanceApi.GetOrder("TRXUSDT", "1331746270");
            //Order.AddMissingOrders(BinanceApi.GetAllOrders("QTUMUSDT"));
            //Order.AddMissingOrders(BinanceApi.GetAllOrders("TRXUSDT"));
            //Order.AddMissingOrders(BinanceApi.GetAllOrders("KAVAUSDT"));
            //Order.AddMissingOrders(BinanceApi.GetAllOrders("SRMUSDT"));
            //Order.AddMissingOrders(BinanceApi.GetAllOrders("ICPUSDT"));
            //List<Order> orders = BinanceApi.GetAllOrders("XTZUSDT");
            //foreach(Order order in orders)
            //{

            //}
            //ExchangeSymbol exchangeSymbol = GlobalStore.Symbols.Where(s => s.Symbol == "IOTXUSDT").First();
            ////decimal commission = s.Commission * 0.57m;
            //decimal commission = exchangeSymbol.Commission * 0.06136m;
            //Console.WriteLine("Price decimal places: " + exchangeSymbol.PriceDecimalPlaces);
            //Console.WriteLine("Price step: " + exchangeSymbol.PriceStep);
            //Order backOrder = BinanceApi.CreateOrder(exchangeSymbol.Symbol, 212, Math.Round((0.06136m + ((0.06136m / 100) * GlobalStore.Percent) + commission), exchangeSymbol.PriceDecimalPlaces), "SELL");
            MainLogic();
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
            //MainAsync().Wait();
            // or, if you want to avoid exceptions being wrapped into AggregateException:
            //  MainAsync().GetAwaiter().GetResult();
        }

        static void MainLogic()
        {
            Console.WriteLine("Binance Bot .Net Core - Synchro mode");
            GlobalStore.Account = new Account();
            GlobalStore.Account.LoadAccount();
            GlobalStore.Account.BalanceUSDT = 46.3404m;
            List<Price> prices = new List<Price>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddHours(48);
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
            Console.WriteLine($"Start time: {startTime.ToLongTimeString()}, End time: {endTime.ToLongTimeString()}");
            while (startTime < endTime)
            {
                try
                {
                    prices = BinanceApi.GetInterestingCurrencies(prices);
                    startTime = DateTime.Now;
                    GlobalStore.Account.ProcessOrders();
                    GlobalStore.Account.SaveAccount();
                    Console.ResetColor();
                    foreach (string currency in GlobalStore.Account.OrdersCurrencies)
                    {
                        List<Order> orders = BinanceApi.GetAllOrders(currency);
                        Order.AddMissingOrders(orders);
                    }
                    Thread.Sleep(5000);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("Exception in main method!");
                    Console.WriteLine(exc.Message);
                    Console.WriteLine("########################################################");
                    Console.WriteLine("Source:");
                    Console.WriteLine(exc.Source);
                    Console.WriteLine("Stack trace");
                    Console.WriteLine(exc.StackTrace);
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                }
            }
            GlobalStore.Account.SaveAccount();
        }

        [Obsolete]
        static async Task MainAsync()
        {
            Console.WriteLine("Binance Bot .Net Core - Async mode");
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
                    prices = BinanceApi.GetInterestingCurrencies(prices);
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