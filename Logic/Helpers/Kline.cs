using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace binanceBotNetCore.Logic.Helpers
{
    public class Kline
    {
        public Int64 OpenTime { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public Int64 CloseTime { get; set; }
        public decimal QuoteAssetVolume { get; set; }
        public Int64 NumberOfTrades { get; set; }
        public decimal TakerBuyBaseAssetVolume { get; set; }
        public decimal TakerBuyQuoteAssetVolume { get; set; }

        public static List<Kline> ParseCsv(string filename)
        {
            List<Kline> klines = new List<Kline>();
            StreamReader sr = new StreamReader(filename);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                List<string> values = line.Split(',').ToList();
                Kline kline = new Kline()
                {
                    OpenTime = Convert.ToInt64(values[0]),
                    Open = Convert.ToDecimal(values[1].Replace(".", ",")),
                    High = Convert.ToDecimal(values[2].Replace(".", ",")),
                    Low = Convert.ToDecimal(values[3].Replace(".", ",")),
                    Close = Convert.ToDecimal(values[4].Replace(".", ",")),
                    Volume = Convert.ToDecimal(values[5].Replace(".", ",")),
                    CloseTime = Convert.ToInt64(values[6]),
                    QuoteAssetVolume = Convert.ToDecimal(values[7].Replace(".", ",")),
                    NumberOfTrades = Convert.ToInt64(values[8]),
                    TakerBuyBaseAssetVolume = Convert.ToDecimal(values[9].Replace(".", ",")),
                    TakerBuyQuoteAssetVolume = Convert.ToDecimal(values[10].Replace(".", ","))
                };
                klines.Add(kline);
            }
            return klines;
        }
    }
}