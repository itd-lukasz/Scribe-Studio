using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Tools;
using Microsoft.Data.Analysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace binanceBotNetCore.Logic.BinanceApi
{
    public static class BinanceApi{

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
            prices = prices.OrderBy(p => p.symbol).ThenByDescending(p => p.time).ToList();
            DataFrame df = new DataFrame();
            df.Columns.Add(new StringDataFrameColumn("symbol"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("price"));
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("time"));
            foreach (Price price in prices)
            {
                df.Append(new List<KeyValuePair<string, object>>(){
                    new KeyValuePair<string, object>("symbol", price.symbol),
                    new KeyValuePair<string, object>("price", price.price),
                    new KeyValuePair<string, object>("time", price.time)}, true);
            }
            df.PrettyPrint();
            // JObject json = JObject.Parse(resp.Result);
            // System.Console.WriteLine(json);
            return prices;
        }

    }
}