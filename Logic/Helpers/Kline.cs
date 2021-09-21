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
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("index")); //0
            df.Columns.Add(new PrimitiveDataFrameColumn<Int64>("OpenTime")); //1
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Open")); //2
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("High")); //3
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Low"));  //4
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Close")); //5
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("Volume")); //6
            df.Columns.Add(new PrimitiveDataFrameColumn<Int64>("CloseTime")); //7
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("QuoteAssetVolume")); //8
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("NumberOfTrades")); //9
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("TakerBuyBaseAssetVolume")); //10
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("TakerBuyQuoteAssetVolume")); //11
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("StartTime")); //12
            df.Columns.Add(new PrimitiveDataFrameColumn<DateTime>("EndTime"));  //13
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("SumOpenClose"));  //14
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("SumHighLow")); //15
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLow")); //16
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenClose")); //17
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowOneMinuteAgo")); //18
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseOneMinuteAgo")); //19
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowTwoMinuteAgo")); //20
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseTwoMinuteAgo")); //21
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowThreeMinuteAgo")); //22
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseThreeMinuteAgo")); //23
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowFourMinuteAgo")); //24
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseFourMinuteAgo")); //25
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentHighLowFiveMinuteAgo")); //26
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("PercentOpenCloseFiveMinuteAgo")); //27
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("OpenOneMinuteAgo")); //28
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("CloseOneMinuteAgo")); //29
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("OpenTwoMinuteAgo")); //30
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("CloseTwoMinuteAgo")); //31
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("OpenThreeMinuteAgo")); //32
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("CloseThreeMinuteAgo")); //33
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("OpenFourMinuteAgo")); //34
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("CloseFourMinuteAgo")); //35
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("OpenFiveMinuteAgo")); //36
            df.Columns.Add(new PrimitiveDataFrameColumn<decimal>("CloseFiveMinuteAgo")); //37
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("UpMinuteAgo")); //38
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("UpTwoMinuteAgo")); //39
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("UpThreeMinuteAgo")); //40
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("UpFourMinuteAgo")); //41
            df.Columns.Add(new PrimitiveDataFrameColumn<int>("UpFiveMinuteAgo")); //42
            df.Columns.Add(new StringDataFrameColumn("Currency")); //43
            df.Columns.Add(new PrimitiveDataFrameColumn<bool>("ShouldBuy")); //44
            df.Columns.Add(new StringDataFrameColumn("BinaryData")); //45
            df.Columns.Add(new StringDataFrameColumn("Range_High_Low_One_Minute_Ago")); //46
            df.Columns.Add(new StringDataFrameColumn("Range_High_Low_Two_Minute_Ago")); //47
            df.Columns.Add(new StringDataFrameColumn("Range_High_Low_Three_Minute_Ago")); //48
            df.Columns.Add(new StringDataFrameColumn("Range_High_Low_Four_Minute_Ago")); //49
            df.Columns.Add(new StringDataFrameColumn("Range_High_Low_Five_Minute_Ago")); //50
            df.Columns.Add(new StringDataFrameColumn("Range_Open_Close_One_Minute_Ago")); //51
            df.Columns.Add(new StringDataFrameColumn("Range_Open_Close_Two_Minute_Ago")); //52
            df.Columns.Add(new StringDataFrameColumn("Range_Open_Close_Three_Minute_Ago")); //53
            df.Columns.Add(new StringDataFrameColumn("Range_Open_Close_Four_Minute_Ago")); //54
            df.Columns.Add(new StringDataFrameColumn("Range_Open_Close_Five_Minute_Ago")); //55
            int index = 0;
            StreamReader sr = new StreamReader(filename);
            FileInfo fi = new FileInfo(filename);
            string currency = fi.Name.Substring(0, fi.Name.IndexOf('-'));
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
                    new KeyValuePair<string, object>("SumOpenClose", Convert.ToDecimal(values[4].Replace(".", ",")) - Convert.ToDecimal(values[1].Replace(".", ","))),
                    new KeyValuePair<string, object>("SumHighLow", Convert.ToDecimal(values[2].Replace(".", ",")) - Convert.ToDecimal(values[3].Replace(".", ","))),
                    new KeyValuePair<string, object>("PercentHighLow", ((Convert.ToDecimal(values[2].Replace(".", ","))/Convert.ToDecimal(values[3].Replace(".", ","))) -1 ) * 100),
                    new KeyValuePair<string, object>("PercentOpenClose", ((Convert.ToDecimal(values[4].Replace(".", ","))/Convert.ToDecimal(values[1].Replace(".", ","))) -1 ) * 100),
                    new KeyValuePair<string, object>("ShouldBuy", Convert.ToDecimal(values[4].Replace(".", ",")) > Convert.ToDecimal(values[1].Replace(".", ","))),
                    new KeyValuePair<string, object>("Currency", currency)
                });
                index++;
            }
            return df;
        }
    }
}