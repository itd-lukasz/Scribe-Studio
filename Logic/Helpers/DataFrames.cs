using System;
using System.Collections.Generic;
using Microsoft.Data.Analysis;
using Newtonsoft.Json;
using System.IO;

namespace binanceBotNetCore.Logic.Helpers
{
    public static class DataFrames
    {
        public static DataFrame FindDoji(DataFrame df)
        {
            if (df.Columns["Doji"] == null)
            {
                throw new Exception("Missing column Doji!");
            }
            throw new NotImplementedException();
            return df;
        }

        public static DataFrame CountBinaryData(DataFrame df)
        {
            int index = 0;
            foreach(DataFrameRow row in df.Rows)
            {
                if (index > 4)
                {
                    df[index, 18] = (((Convert.ToDecimal(df[index - 1, 3])/Convert.ToDecimal(df[index - 1, 4])) - 1) * 100); //Precent High Low 1m ago
                    df[index, 19] = (((Convert.ToDecimal(df[index - 1, 5])/Convert.ToDecimal(df[index - 1, 2])) - 1) * 100); //Precent Open Close 1m ago
                    df[index, 20] = (((Convert.ToDecimal(df[index - 2, 3])/Convert.ToDecimal(df[index - 2, 4])) - 1) * 100); //Precent High Low 2m ago
                    df[index, 21] = (((Convert.ToDecimal(df[index - 2, 5])/Convert.ToDecimal(df[index - 2, 2])) - 1) * 100); //Precent Open Close 2m ago
                    df[index, 22] = (((Convert.ToDecimal(df[index - 3, 3])/Convert.ToDecimal(df[index - 3, 4])) - 1) * 100); //Precent High Low 3m ago
                    df[index, 23] = (((Convert.ToDecimal(df[index - 3, 5])/Convert.ToDecimal(df[index - 3, 2])) - 1) * 100); //Precent Open Close 3m ago
                    df[index, 24] = (((Convert.ToDecimal(df[index - 4, 3])/Convert.ToDecimal(df[index - 4, 4])) - 1) * 100); //Precent High Low 4m ago
                    df[index, 25] = (((Convert.ToDecimal(df[index - 4, 5])/Convert.ToDecimal(df[index - 4, 2])) - 1) * 100); //Precent Open Close 4m ago
                    df[index, 26] = (((Convert.ToDecimal(df[index - 5, 3])/Convert.ToDecimal(df[index - 5, 4])) - 1) * 100); //Precent High Low 5m ago
                    df[index, 27] = (((Convert.ToDecimal(df[index - 5, 5])/Convert.ToDecimal(df[index - 5, 2])) - 1) * 100); //Precent Open Close 5m ago
                    df[index, 28] = df[index - 1, 2]; //Open 1m ago
                    df[index, 29] = df[index - 1, 5]; //Close 1m ago
                    df[index, 30] = df[index - 2, 2]; //Open 2m ago
                    df[index, 31] = df[index - 2, 5]; //Close 2m ago
                    df[index, 32] = df[index - 3, 2]; //Open 3m ago
                    df[index, 33] = df[index - 3, 5]; //Close 3m ago
                    df[index, 34] = df[index - 4, 2]; //Open 4m ago
                    df[index, 35] = df[index - 4, 5]; //Close 4m ago
                    df[index, 36] = df[index - 5, 2]; //Open 5m ago
                    df[index, 37] = df[index - 5, 5]; //Close 5m ago
                    df[index, 38] = Convert.ToInt32(Convert.ToDecimal(df[index - 1, 2]) < Convert.ToDecimal(df[index - 1, 5])); //Up 1m ago
                    df[index, 39] = Convert.ToInt32(Convert.ToDecimal(df[index - 2, 2]) < Convert.ToDecimal(df[index - 2, 5])); //Up 2m ago
                    df[index, 40] = Convert.ToInt32(Convert.ToDecimal(df[index - 3, 2]) < Convert.ToDecimal(df[index - 3, 5])); //Up 3m ago
                    df[index, 41] = Convert.ToInt32(Convert.ToDecimal(df[index - 4, 2]) < Convert.ToDecimal(df[index - 4, 5])); //Up 4m ago
                    df[index, 42] = Convert.ToInt32(Convert.ToDecimal(df[index - 5, 2]) < Convert.ToDecimal(df[index - 5, 5])); //Up 5m ago
                    df[index, 45] = string.Format($"{Convert.ToInt32(Convert.ToDecimal(df[index - 1, 2]) < Convert.ToDecimal(df[index - 1, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 2, 2]) < Convert.ToDecimal(df[index - 2, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 3, 2]) < Convert.ToDecimal(df[index - 3, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 4, 2]) < Convert.ToDecimal(df[index - 4, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 5, 2]) < Convert.ToDecimal(df[index - 5, 5]))}");
                }
                index++;
            }
            return df;
        }

        public static DataFrame CountRanges(DataFrame df)
        {
            var ranges =  new List<(decimal Begin, decimal End)>
            {
                (0.0m, 0.25m), (0.25m, 0.5m), (0.5m, 1m), (1, 2),
                (2, 3), (3, 4), (4, 5), (5, 7), (7, 10), (10, 15),
                (15, 25), (25, 50), (50, 100), (100, 1000000)
            };
            var ranges_minus =  new List<(decimal Begin, decimal End)>
            {
                (0m, -0.25m), (-0.25m, -0.5m), (-0.5m, -1m), (-1, -2),
                (-2, -3), (-3, -4), (-4, -5), (-5, -7),
                (-7, -10), (-10, -15), (-15, -25), (-25, -50), (-50, -100), (-100, -1000000)
            };
            for(int index = 0; index < df.Rows.Count; index++)
            {
                if (index > 4)
                {
                    foreach(var tuple in ranges)
                    {
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 18]) &&
                            Convert.ToDecimal(df[index, 18]) < tuple.End)
                        {
                            df[index, 46] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 1m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 19]) &&
                            Convert.ToDecimal(df[index, 19]) < tuple.End)
                        {
                            df[index, 51] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 1m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 20]) &&
                            Convert.ToDecimal(df[index, 20]) < tuple.End)
                        {
                            df[index, 47] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 2m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 21]) &&
                            Convert.ToDecimal(df[index, 21]) < tuple.End)
                        {
                            df[index, 52] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 2m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 22]) &&
                            Convert.ToDecimal(df[index, 22]) < tuple.End)
                        {
                            df[index, 48] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 3m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 23]) &&
                            Convert.ToDecimal(df[index, 23]) < tuple.End)
                        {
                            df[index, 53] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 3m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 24]) &&
                            Convert.ToDecimal(df[index, 24]) < tuple.End)
                        {
                            df[index, 49] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 4m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 25]) &&
                            Convert.ToDecimal(df[index, 25]) < tuple.End)
                        {
                            df[index, 54] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 4m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 26]) &&
                            Convert.ToDecimal(df[index, 26]) < tuple.End)
                        {
                            df[index, 50] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 5m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 27]) &&
                            Convert.ToDecimal(df[index, 27]) < tuple.End)
                        {
                            df[index, 55] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 5m ago    
                        }
                    }
                    foreach(var tuple in ranges_minus)
                    {
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 18]) &&
                            Convert.ToDecimal(df[index, 18]) > tuple.End)
                        {
                            df[index, 46] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 1m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 19]) &&
                            Convert.ToDecimal(df[index, 19]) > tuple.End)
                        {
                            df[index, 51] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 1m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 20]) &&
                            Convert.ToDecimal(df[index, 20]) > tuple.End)
                        {
                            df[index, 47] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 2m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 21]) &&
                            Convert.ToDecimal(df[index, 21]) > tuple.End)
                        {
                            df[index, 52] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 2m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 22]) &&
                            Convert.ToDecimal(df[index, 22]) > tuple.End)
                        {
                            df[index, 48] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 3m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 23]) &&
                            Convert.ToDecimal(df[index, 23]) > tuple.End)
                        {
                            df[index, 53] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 3m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 24]) &&
                            Convert.ToDecimal(df[index, 24]) > tuple.End)
                        {
                            df[index, 49] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 4m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 25]) &&
                            Convert.ToDecimal(df[index, 25]) > tuple.End)
                        {
                            df[index, 54] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 4m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 26]) &&
                            Convert.ToDecimal(df[index, 26]) > tuple.End)
                        {
                            df[index, 50] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 5m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 27]) &&
                            Convert.ToDecimal(df[index, 27]) > tuple.End)
                        {
                            df[index, 55] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 5m ago    
                        }
                    }
                }
            }
            return df;
        }
    }
}