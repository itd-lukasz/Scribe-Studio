using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Tools;
using Microsoft.Data.Analysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace binanceBotNetCore.Logic.BinanceApi
{
    public static class BinanceApi
    {
        public static void DownloadFile(string symbol, string interval, DateTime date)
        {
            WebClient client = new WebClient();
            client.DownloadFile($"https://data.binance.vision/data/spot/daily/klines/{symbol}/{interval}/{symbol}-{interval}-{date.ToString("yyyy-MM-dd")}.zip", $"sources/download/{symbol}-{interval}-{date.ToString("yyyy-MM-dd")}.zip");
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
            return JsonConvert.DeserializeObject<Price>(resp.Result);
        }

        public static List<Price> GetInterestingCurrenciesAsync(List<Price> prices)
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
                foreach(DataFrameRow row in df.Rows)
                {
                    Console.WriteLine(GetCurrentPrice(row[0].ToString()));
                }
            }
            return prices;
        }

    }
}