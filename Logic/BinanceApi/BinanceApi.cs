using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Helpers;
using binanceBotNetCore.Logic.Tools;
using Microsoft.Data.Analysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace binanceBotNetCore.Logic.BinanceApi
{
    public static class BinanceApi
    {
        static string host = "api1.binance.com";
        //test values:
        //static string apiKey = "YnRuuGGYr1IPoPg9uP8kuInXiTVOpPdBVUn0zQ14fBxxU9DCwavqsa5MwxFxkZk7";
        //static string secret = "jzF9PZpQ5MFSAPOEpQUaOitpoc2nIB9HS68pRrZaSiyb8AUGxvnbe00VS1LoQgTg";
        //prod values:
        static string apiKey = "hG9DjB44Paq3kdoh0tHbVYoULQkBrC9mk8RdVW1ZxU6WQiBA61kgy8P0dbEINUxq";
        static string secret = "oMKQ9Y8an5XCW8pVONAQV0aRQFtLH2Js5rayhJVswjKHyoY7yTSjTNHMTQqEMVGO";

        private static string GetHexString(byte[] bytes)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                builder.Append($"{b:x2}");
            }
            return builder.ToString();
        }

        private static byte[] Sign(string secret, string content)
        {
            var signedBytes = new HMACSHA256(Encoding.UTF8.GetBytes(secret))
                .ComputeHash(Encoding.UTF8.GetBytes(content));
            return signedBytes;
        }

        public static Order CreateOrder(string symbol, decimal quantity, decimal price, string side = "")
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            long ts = BinanceApi.GetTimestamp();
            ts = ts + 500;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (side == "BUY" || side == "")
            {
                var signedBytes = Sign(secret, $"recvWindow=5000&symbol={symbol}&side={side}&type=LIMIT&quantity={quantity.ToString().Replace(",", ".")}&timeInForce=IOC&timestamp={ts}&price={price.ToString().Replace(",", ".")}");
                HttpResponseMessage response = client.PostAsync($"https://{host}/api/v3/order?recvWindow=5000&symbol={symbol}&side={side}&type=LIMIT&quantity={quantity.ToString().Replace(",", ".")}&timeInForce=IOC&timestamp={ts}&signature={GetHexString(signedBytes)}&price={price.ToString().Replace(",", ".")}", null).Result;
                var resp = response.Content.ReadAsStringAsync();
                if (resp.Result.ToLower().Contains("code"))
                {
                    Console.WriteLine(resp.Result);
                    //Console.WriteLine(response.Headers.ToString());
                    //Console.WriteLine(response.StatusCode);
                    Console.WriteLine(response.Content);
                    throw new InvalidOperationException("Operation failed!");
                }
                else
                {
                    Console.WriteLine($"Bought {symbol} per {price} for {quantity}");
                    return JsonConvert.DeserializeObject<Order>(resp.Result);
                }
            }
            if (side == "SELL")
            {
                var signedBytes = Sign(secret, $"recvWindow=5000&symbol={symbol}&side={side}&type=LIMIT&quantity={quantity.ToString().Replace(",", ".")}&timeInForce=GTC&timestamp={ts}&price={price.ToString().Replace(",", ".")}");
                Console.WriteLine($"recvWindow=5000&symbol={symbol}&side={side}&type=LIMIT&quantity={quantity.ToString().Replace(",", ".")}&timeInForce=GTC&timestamp={ts}&price={price.ToString().Replace(",", ".")}");
                HttpResponseMessage response = client.PostAsync($"https://{host}/api/v3/order?recvWindow=5000&symbol={symbol}&side={side}&type=LIMIT&quantity={quantity.ToString().Replace(",", ".")}&timeInForce=GTC&timestamp={ts}&signature={GetHexString(signedBytes)}&price={price.ToString().Replace(",", ".")}", null).Result;
                var resp = response.Content.ReadAsStringAsync();
                if (resp.Result.ToLower().Contains("code"))
                {
                    Console.WriteLine(resp.Result);
                    //Console.WriteLine(response.Headers.ToString());
                    //Console.WriteLine(response.StatusCode);
                    Console.WriteLine(response.Content);
                    throw new InvalidOperationException("Operation failed!");
                }
                else
                {
                    Console.WriteLine($"Sold {symbol} per {price} for {quantity} units");
                    return JsonConvert.DeserializeObject<Order>(resp.Result);
                }
            }
            return null;
        }

        public static List<Order> GetAllOrders(string symbol)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long startTime = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign(secret, $"startTime={startTime}&symbol={symbol}&timestamp={ts}");
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/allOrders?startTime={startTime}&symbol={symbol}&timestamp={ts}&signature={GetHexString(signedBytes)}").Result;
            var resp = response.Content.ReadAsStringAsync();
            Console.WriteLine(resp.Result);
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            return JsonConvert.DeserializeObject<List<Order>>(resp.Result);
        }

        public static Order GetOrder(string symbol, string orderId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign(secret, $"orderId={orderId}&symbol={symbol}&timestamp={ts}");
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/order?orderId={orderId}&symbol={symbol}&timestamp={ts}&signature={GetHexString(signedBytes)}").Result;
            var resp = response.Content.ReadAsStringAsync();
            if (resp.Result.ToLower().Contains("code"))
            {
                Console.WriteLine(resp.Result);
                Console.WriteLine(response.Headers.ToString());
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content);
                throw new InvalidOperationException("Operation failed!");
            }
            return JsonConvert.DeserializeObject<Order>(resp.Result);
        }

        public static void GetAllTrades(string symbol)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign(secret, $"symbol={symbol}&timestamp={ts}");
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/myTrades?symbol={symbol}&timestamp={ts}&signature={GetHexString(signedBytes)}").Result;
            var resp = response.Content.ReadAsStringAsync();
            Console.WriteLine(resp.Result);
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }

        public static Trade GetTrade(string symbol, string orderId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign(secret, $"orderId={orderId}&symbol={symbol}&timestamp={ts}");
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/myTrades?orderId={orderId}&symbol={symbol}&timestamp={ts}&signature={GetHexString(signedBytes)}").Result;
            var resp = response.Content.ReadAsStringAsync();
            if (resp.Result.ToLower().Contains("code"))
            {
                Console.WriteLine(resp.Result);
                Console.WriteLine(response.Headers.ToString());
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content);
                throw new InvalidOperationException("Operation failed!");
            }
            return JsonConvert.DeserializeObject<Trade>(resp.Result.Replace("[", "").Replace("]", ""));
        }

        public static List<ExchangeSymbol> ExchangeInfo()
        {
            List<ExchangeSymbol> exchangeSymbols = new List<ExchangeSymbol>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/exchangeInfo").Result;
            var resp = response.Content.ReadAsStringAsync();
            dynamic o = JObject.Parse(resp.Result);
            //Console.WriteLine(o.symbols);
            foreach (JObject item in o.symbols)
            {
                ExchangeSymbol exchangeSymbol = new ExchangeSymbol()
                {
                    Symbol = item["symbol"].ToString(),
                    Commission = CheckCommission(item["symbol"].ToString())
                };
                JToken filters = item["filters"];
                foreach (var filter in filters)
                {
                    if (filter["filterType"].ToString() == "LOT_SIZE")
                    {
                        exchangeSymbol.QuantityStep = Convert.ToDecimal(filter["stepSize"]);
                    }
                    if (filter["filterType"].ToString() == "PRICE_FILTER")
                    {
                        exchangeSymbol.PriceStep = Convert.ToDecimal(filter["tickSize"]);
                    }
                }
                exchangeSymbols.Add(exchangeSymbol);
            }
            return exchangeSymbols;
        }

        private static decimal CheckCommission(string symbol)
        {
            return 0.001m;
        }

        public static void AccountStatus()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiKey);
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign(secret, $"timestamp={ts}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/account?timestamp={ts}&signature={GetHexString(signedBytes)}").Result;
            var resp = response.Content.ReadAsStringAsync();
            Console.WriteLine(resp.Result);
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }

        public static void DownloadFile(string symbol, string interval, DateTime date)
        {
            WebClient client = new WebClient();
            client.DownloadFile(new Uri($"https://data.binance.vision/data/spot/daily/klines/{symbol}/{interval}/{symbol}-{interval}-{date.ToString("yyyy-MM-dd")}.zip"), $"sources/download/{symbol}-{interval}-{date.ToString("yyyy-MM-dd")}.zip");
            UnzipFile($"{symbol}-{interval}-{date.ToString("yyyy-MM-dd")}.zip");
        }

        private static void UnzipFile(string file)
        {
            System.IO.Compression.ZipFile.ExtractToDirectory($"sources/download/{file}", $"sources", true);
        }

        public static Price GetCurrentPrice(string symbol)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v1/ticker/price?symbol={symbol}").Result;
            var resp = response.Content.ReadAsStringAsync();
            Console.WriteLine(resp.Result);
            return JsonConvert.DeserializeObject<Price>(resp.Result);
        }

        public static Int64 GetTimestamp()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/time").Result;
            var resp = response.Content.ReadAsStringAsync();
            dynamic o = JObject.Parse(resp.Result);
            return Convert.ToInt64(o.serverTime);
        }

        public static DataFrame GetKlinesDataFrame(string symbol, string interval)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v3/klines?limit=11&symbol={symbol}&interval={interval}").Result;
            var resp = response.Content.ReadAsStringAsync();
            string array = resp.Result;
            array = array.Replace("[[", "[");
            array = array.Replace("]]", "]");
            List<Kline> klines = new List<Kline>();
            foreach (string item in array.Split(new string[] { "],[" }, StringSplitOptions.None))
            {
                List<string> fields = new List<string>();
                if (item.StartsWith("["))
                {
                    fields = item.Remove(0, 1).Split(",").ToList();
                }
                if (item.EndsWith("]"))
                {
                    fields = item.Substring(0, item.Length - 2).Split(",").ToList();
                }
                if (!item.StartsWith("[") && !item.EndsWith("]"))
                {
                    fields = item.Split(",").ToList();
                }
                klines.Add(new Kline()
                {
                    OpenTime = Convert.ToInt64(fields[0].Replace("\"", "").Replace(".", ",")),
                    Open = Convert.ToDecimal(fields[1].Replace("\"", "").Replace(".", ",")),
                    High = Convert.ToDecimal(fields[2].Replace("\"", "").Replace(".", ",")),
                    Low = Convert.ToDecimal(fields[3].Replace("\"", "").Replace(".", ",")),
                    Close = Convert.ToDecimal(fields[4].Replace("\"", "").Replace(".", ",")),
                    Volume = Convert.ToDecimal(fields[5].Replace("\"", "").Replace(".", ",")),
                    CloseTime = Convert.ToInt64(fields[6].Replace("\"", "").Replace(".", ",")),
                    QuoteAssetVolume = Convert.ToDecimal(fields[7].Replace("\"", "").Replace(".", ",")),
                    NumberOfTrades = Convert.ToInt32(fields[8].Replace("\"", "").Replace(".", ",")),
                    TakerBuyBaseAssetVolume = Convert.ToDecimal(fields[9].Replace("\"", "").Replace(".", ",")),
                    TakerBuyQuoteAssetVolume = Convert.ToDecimal(fields[10].Replace("\"", "").Replace(".", ","))
                });
            }
            return Kline.ParseList(klines, symbol);
        }

        public static List<Price> GetInterestingCurrencies(List<Price> prices)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://{host}/api/v1/ticker/allPrices").Result;
            var resp = response.Content.ReadAsStringAsync();
            if (prices.Count == 0)
            {
                prices = JsonConvert.DeserializeObject<List<Price>>(resp.Result);
            }
            else
            {
                prices.AddRange(JsonConvert.DeserializeObject<List<Price>>(resp.Result));
            }
            prices = prices.Where(s => s.symbol.ToLower().Contains("usdt")).ToList();
            prices = prices.OrderBy(p => p.symbol).ThenByDescending(p => p.time).ToList();
            List<string> dates = prices.Select(s => s.time.ToLongTimeString()).Distinct().ToList();
            dates = dates.OrderByDescending(s => s).ToList();
            if (dates.Count > 11)
            {
                prices = prices.Where(p => p.time.ToLongTimeString() != dates[11]).ToList();
            }
            DataFrame df = new DataFrame();
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("index"));
            df.Columns.Add(new StringDataFrameColumn("symbol"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("price"));
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("time"));
            df.Columns.Add(new StringDataFrameColumn("direction"));
            int index = 0;
            foreach (Price price in prices)
            {
                df.Append(new List<KeyValuePair<string, object>>(){
                    new KeyValuePair<string, object>("index", index),
                    new KeyValuePair<string, object>("symbol", price.symbol),
                    new KeyValuePair<string, object>("price", price.price),
                    new KeyValuePair<string, object>("time", price.time),
                    new KeyValuePair<string, object>("direction", "n/a")}, true);
                index++;
            }
            df.CountDirection();
            df = df.FindBestCurrencies();
            if (df.Rows.Count > 0)
            {
                //df.PrettyPrint();
                for (index = 0; index < df.Rows.Count; index++)
                {
                    if (!GlobalStore.Account.ProcessCurrencies.Select(s => s.Symbol).ToList().Contains(df[index, 0].ToString())
                        && !df[index, 0].ToString().EndsWith("DOWNUSDT")
                        && !df[index, 0].ToString().EndsWith("UPUSDT"))
                    {
                        ExchangeSymbol symbol = GlobalStore.Symbols.Where(s => s.Symbol == df[index, 0].ToString()).First();
                        if (symbol.PriceDecimalPlaces >= 5 && symbol.QuantityDecimalPlaces > 0)
                        {
                            Currency currency = new Currency()
                            {
                                Symbol = df[index, 0].ToString(),
                                Status = Currency.CurrencyStatus.WaitingForProcessing
                            };
                            GlobalStore.Account.ProcessCurrencies.Add(currency);
                            GlobalStore.Account.ProcessCurrencies = GlobalStore.Account.ProcessCurrencies.Distinct().ToList();
                            GlobalStore.Account.ProcessCurrencies = GlobalStore.Account.ProcessCurrencies.OrderBy(o => o.Symbol).ToList();
                            GlobalStore.Account.ProcessWaitingCurrencies();
                            GlobalStore.Account.ProcessCurrencies = GlobalStore.Account.ProcessCurrencies.Where(c => c.Status != Currency.CurrencyStatus.Processed).ToList();
                        }
                    }
                }
            }
            return prices;
        }

    }
}