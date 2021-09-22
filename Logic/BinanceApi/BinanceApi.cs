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

        public static void CreateOrder(string symbol, decimal quantity)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            // client.DefaultRequestHeaders.Add("X-MBX-APIKEY", "soLQxiMF81zDng22Qw1SFD42WZd9WO9aF2sVNlqlVhWTU26vJt5agBa038tzC9m8");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", "YnRuuGGYr1IPoPg9uP8kuInXiTVOpPdBVUn0zQ14fBxxU9DCwavqsa5MwxFxkZk7");
            //HMACSHA256 sign = new HMACSHA256(Encoding.ASCII.GetBytes("soLQxiMF81zDng22Qw1SFD42WZd9WO9aF2sVNlqlVhWTU26vJt5agBa038tzC9m8"));
            HMACSHA256 sign = new HMACSHA256(Encoding.ASCII.GetBytes("jzF9PZpQ5MFSAPOEpQUaOitpoc2nIB9HS68pRrZaSiyb8AUGxvnbe00VS1LoQgTg"));
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign("jzF9PZpQ5MFSAPOEpQUaOitpoc2nIB9HS68pRrZaSiyb8AUGxvnbe00VS1LoQgTg", $"symbol={symbol}&side=BUY&type=MARKET&quantity={quantity}&timestamp={ts}");
            HttpResponseMessage response = client.PostAsync($"https://testnet.binance.vision/api/v3/order?symbol={symbol}&side=BUY&type=MARKET&quantity={quantity}&timestamp={ts}&signature={GetHexString(signedBytes)}", null).Result;
            var resp = response.Content.ReadAsStringAsync();
            Console.WriteLine(resp.Result);
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }

        public static void AccountStatus()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            // client.DefaultRequestHeaders.Add("X-MBX-APIKEY", "soLQxiMF81zDng22Qw1SFD42WZd9WO9aF2sVNlqlVhWTU26vJt5agBa038tzC9m8");
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", "YnRuuGGYr1IPoPg9uP8kuInXiTVOpPdBVUn0zQ14fBxxU9DCwavqsa5MwxFxkZk7");
            //HMACSHA256 sign = new HMACSHA256(Encoding.ASCII.GetBytes("soLQxiMF81zDng22Qw1SFD42WZd9WO9aF2sVNlqlVhWTU26vJt5agBa038tzC9m8"));
            HMACSHA256 sign = new HMACSHA256(Encoding.ASCII.GetBytes("jzF9PZpQ5MFSAPOEpQUaOitpoc2nIB9HS68pRrZaSiyb8AUGxvnbe00VS1LoQgTg"));
            long ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var signedBytes = Sign("jzF9PZpQ5MFSAPOEpQUaOitpoc2nIB9HS68pRrZaSiyb8AUGxvnbe00VS1LoQgTg", $"timestamp={ts}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://testnet.binance.vision/api/v3/account?timestamp={ts}&signature={GetHexString(signedBytes)}").Result;
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
            HttpResponseMessage response = client.GetAsync($"https://testnet.binance.com/api/v1/ticker/price?symbol={symbol}").Result;
            var resp = response.Content.ReadAsStringAsync();
            Console.WriteLine(resp.Result);
            return JsonConvert.DeserializeObject<Price>(resp.Result);
        }

        public static DataFrame GetKlinesDataFrame(string symbol, string interval)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"https://testnet.binance.com/api/v3/klines?limit=10&symbol={symbol}&interval={interval}").Result;
            var resp = response.Content.ReadAsStringAsync();
            string array = resp.Result;
            array = array.Replace("[[", "[");
            array = array.Replace("]]", "]");
            List<Kline> klines = new List<Kline>();
            foreach(string item in array.Split(new string[] {"],["}, StringSplitOptions.None))
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

        public static List<Price> GetInterestingCurrenciesAsync(List<Price> prices, Account account)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "binance test bot");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("https://testnet.binance.com/api/v1/ticker/allPrices").Result;
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
            if (dates.Count > 6)
            {
                prices = prices.Where(p => p.time.ToLongTimeString() != dates[6]).ToList();
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
                df.PrettyPrint();
                for(index = 0; index < df.Rows.Count; index++)
                {
                    if (!account.UnderChecking.Contains(df[index, 0].ToString()) && !df[index, 0].ToString().EndsWith("DOWNUSDT"))
                    {
                        account.UnderChecking.Add(df[index, 0].ToString());
                        account.UnderChecking = account.UnderChecking.Distinct().ToList();
                        account.ProcessCurrenciesAsync();
                    }
                }
            }
            return prices;
        }

    }
}