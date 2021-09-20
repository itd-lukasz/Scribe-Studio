using binanceBotNetCore.Logic.Tools;
using Microsoft.Data.Analysis;
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
        public int NumberOfTrades { get; set; }
        public decimal TakerBuyBaseAssetVolume { get; set; }
        public decimal TakerBuyQuoteAssetVolume { get; set; }

        public static DataFrame ParseCsv(string filename)
        {
            DataFrame df = new DataFrame();
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("index"));
            df.Columns.Add(new PrimitiveDataFrameColumn<Int64>("OpenTime"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Open"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("High"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Low"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Close"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Volume"));
            df.Columns.Add(new PrimitiveDataFrameColumn<Int64>("CloseTime"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("QuoteAssetVolume"));
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("NumberOfTrades"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("TakerBuyBaseAssetVolume"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("TakerBuyQuoteAssetVolume"));
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("StartTime"));
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("EndTime"));
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("SumOpenClose"));
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("SumHighLow"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLow"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenClose"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowOneMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseOneMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowTwoMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseTwoMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowThreeMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseThreeMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowFourMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseFourMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowFiveMinuteAgo"));
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseFiveMinuteAgo"));
            df.Columns.Add(new StringDataFrameColumn("Currency"));
            int index = 0;
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                List<string> values = line.Split(',').ToList();
                df = df.Append(new List<KeyValuePair<string, object>>(){
                    new KeyValuePair<string, object>("index", index),
                    new KeyValuePair<string, object>("OpenTime", Convert.ToInt64(values[0])),
                    new KeyValuePair<string, object>("Open", Convert.ToDecimal(values[1].Replace(".", ","))),
                    new KeyValuePair<string, object>("High", Convert.ToDecimal(values[2].Replace(".", ","))),
                    new KeyValuePair<string, object>("Low", Convert.ToDecimal(values[3].Replace(".", ","))),
                    new KeyValuePair<string, object>("Close", Convert.ToDecimal(values[4].Replace(".", ","))),
                    new KeyValuePair<string, object>("Volume", Convert.ToDecimal(values[5].Replace(".", ","))),
                    new KeyValuePair<string, object>("CloseTime", Convert.ToInt64(values[6].Replace(".", ","))),
                    new KeyValuePair<string, object>("QuoteAssetVolume", Convert.ToDecimal(values[7].Replace(".", ","))),
                    new KeyValuePair<string, object>("NumberOfTrades", Convert.ToInt32(values[8].Replace(".", ","))),
                    new KeyValuePair<string, object>("TakerBuyBaseAssetVolume", Convert.ToDecimal(values[9].Replace(".", ","))),
                    new KeyValuePair<string, object>("TakerBuyQuoteAssetVolume", Convert.ToDecimal(values[10].Replace(".", ","))),
                    new KeyValuePair<string, object>("StartTime", DataFrameUtils.UnixTimeStampToDateTime(Convert.ToDouble(values[0].Replace(".", ",")))),
                    new KeyValuePair<string, object>("EndTime", DataFrameUtils.UnixTimeStampToDateTime(Convert.ToDouble(values[6].Replace(".", ",")))),
                    new KeyValuePair<string, object>("SumOpenClose", Convert.ToDecimal(values[1].Replace(".", ",")) - Convert.ToDecimal(values[4].Replace(".", ","))),
                    new KeyValuePair<string, object>("SumHighLow", Convert.ToDecimal(values[2].Replace(".", ",")) - Convert.ToDecimal(values[3].Replace(".", ",")))
                });
            index++;
            }
            return df;
        }
    }
}