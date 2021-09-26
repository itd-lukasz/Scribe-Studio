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
                if (index > 9)
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
                    df[index, 28] = (((Convert.ToDecimal(df[index - 1, 3])/Convert.ToDecimal(df[index - 6, 4])) - 1) * 100); //Precent High Low 6m ago
                    df[index, 29] = (((Convert.ToDecimal(df[index - 1, 5])/Convert.ToDecimal(df[index - 6, 2])) - 1) * 100); //Precent Open Close 6m ago
                    df[index, 30] = (((Convert.ToDecimal(df[index - 2, 3])/Convert.ToDecimal(df[index - 7, 4])) - 1) * 100); //Precent High Low 7m ago
                    df[index, 31] = (((Convert.ToDecimal(df[index - 2, 5])/Convert.ToDecimal(df[index - 7, 2])) - 1) * 100); //Precent Open Close 7m ago
                    df[index, 32] = (((Convert.ToDecimal(df[index - 3, 3])/Convert.ToDecimal(df[index - 8, 4])) - 1) * 100); //Precent High Low 8m ago
                    df[index, 33] = (((Convert.ToDecimal(df[index - 3, 5])/Convert.ToDecimal(df[index - 8, 2])) - 1) * 100); //Precent Open Close 8m ago
                    df[index, 34] = (((Convert.ToDecimal(df[index - 4, 3])/Convert.ToDecimal(df[index - 9, 4])) - 1) * 100); //Precent High Low 9m ago
                    df[index, 35] = (((Convert.ToDecimal(df[index - 4, 5])/Convert.ToDecimal(df[index - 9, 2])) - 1) * 100); //Precent Open Close 9m ago
                    df[index, 36] = (((Convert.ToDecimal(df[index - 5, 3])/Convert.ToDecimal(df[index - 10, 4])) - 1) * 100); //Precent High Low 10m ago
                    df[index, 37] = (((Convert.ToDecimal(df[index - 5, 5])/Convert.ToDecimal(df[index - 10, 2])) - 1) * 100); //Precent Open Close 10m ago
                    df[index, 38] = df[index - 1, 2]; //Open 1m ago
                    df[index, 39] = df[index - 1, 5]; //Close 1m ago
                    df[index, 40] = df[index - 2, 2]; //Open 2m ago
                    df[index, 41] = df[index - 2, 5]; //Close 2m ago
                    df[index, 42] = df[index - 3, 2]; //Open 3m ago
                    df[index, 43] = df[index - 3, 5]; //Close 3m ago
                    df[index, 44] = df[index - 4, 2]; //Open 4m ago
                    df[index, 45] = df[index - 4, 5]; //Close 4m ago
                    df[index, 46] = df[index - 5, 2]; //Open 5m ago
                    df[index, 47] = df[index - 5, 5]; //Close 5m ago
                    df[index, 48] = df[index - 1, 2]; //Open 6m ago
                    df[index, 49] = df[index - 1, 5]; //Close 6m ago
                    df[index, 50] = df[index - 2, 2]; //Open 7m ago
                    df[index, 51] = df[index - 2, 5]; //Close 7m ago
                    df[index, 52] = df[index - 3, 2]; //Open 8m ago
                    df[index, 53] = df[index - 3, 5]; //Close 8m ago
                    df[index, 54] = df[index - 4, 2]; //Open 9m ago
                    df[index, 55] = df[index - 4, 5]; //Close 9m ago
                    df[index, 56] = df[index - 5, 2]; //Open 10m ago
                    df[index, 57] = df[index - 5, 5]; //Close 10m ago
                    df[index, 58] = Convert.ToInt32(Convert.ToDecimal(df[index - 1, 2]) < Convert.ToDecimal(df[index - 1, 5])); //Up 1m ago
                    df[index, 59] = Convert.ToInt32(Convert.ToDecimal(df[index - 2, 2]) < Convert.ToDecimal(df[index - 2, 5])); //Up 2m ago
                    df[index, 60] = Convert.ToInt32(Convert.ToDecimal(df[index - 3, 2]) < Convert.ToDecimal(df[index - 3, 5])); //Up 3m ago
                    df[index, 61] = Convert.ToInt32(Convert.ToDecimal(df[index - 4, 2]) < Convert.ToDecimal(df[index - 4, 5])); //Up 4m ago
                    df[index, 62] = Convert.ToInt32(Convert.ToDecimal(df[index - 5, 2]) < Convert.ToDecimal(df[index - 5, 5])); //Up 5m ago
                    df[index, 63] = Convert.ToInt32(Convert.ToDecimal(df[index - 1, 2]) < Convert.ToDecimal(df[index - 1, 5])); //Up 6m ago
                    df[index, 64] = Convert.ToInt32(Convert.ToDecimal(df[index - 2, 2]) < Convert.ToDecimal(df[index - 2, 5])); //Up 7m ago
                    df[index, 65] = Convert.ToInt32(Convert.ToDecimal(df[index - 3, 2]) < Convert.ToDecimal(df[index - 3, 5])); //Up 8m ago
                    df[index, 66] = Convert.ToInt32(Convert.ToDecimal(df[index - 4, 2]) < Convert.ToDecimal(df[index - 4, 5])); //Up 9m ago
                    df[index, 67] = Convert.ToInt32(Convert.ToDecimal(df[index - 5, 2]) < Convert.ToDecimal(df[index - 5, 5])); //Up 10m ago
                    df[index, 70] = string.Format($"{Convert.ToInt32(Convert.ToDecimal(df[index - 1, 2]) < Convert.ToDecimal(df[index - 1, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 2, 2]) < Convert.ToDecimal(df[index - 2, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 3, 2]) < Convert.ToDecimal(df[index - 3, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 4, 2]) < Convert.ToDecimal(df[index - 4, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 5, 2]) < Convert.ToDecimal(df[index - 5, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 6, 2]) < Convert.ToDecimal(df[index - 6, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 7, 2]) < Convert.ToDecimal(df[index - 7, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 8, 2]) < Convert.ToDecimal(df[index - 8, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 9, 2]) < Convert.ToDecimal(df[index - 9, 5]))}" +
                                                  $"{Convert.ToInt32(Convert.ToDecimal(df[index - 10, 2]) < Convert.ToDecimal(df[index - 10, 5]))}");
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
                            df[index, 71] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 1m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 19]) &&
                            Convert.ToDecimal(df[index, 19]) < tuple.End)
                        {
                            df[index, 81] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 1m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 20]) &&
                            Convert.ToDecimal(df[index, 20]) < tuple.End)
                        {
                            df[index, 72] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 2m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 21]) &&
                            Convert.ToDecimal(df[index, 21]) < tuple.End)
                        {
                            df[index, 82] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 2m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 22]) &&
                            Convert.ToDecimal(df[index, 22]) < tuple.End)
                        {
                            df[index, 73] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 3m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 23]) &&
                            Convert.ToDecimal(df[index, 23]) < tuple.End)
                        {
                            df[index, 83] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 3m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 24]) &&
                            Convert.ToDecimal(df[index, 24]) < tuple.End)
                        {
                            df[index, 74] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 4m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 25]) &&
                            Convert.ToDecimal(df[index, 25]) < tuple.End)
                        {
                            df[index, 84] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 4m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 26]) &&
                            Convert.ToDecimal(df[index, 26]) < tuple.End)
                        {
                            df[index, 75] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 5m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 27]) &&
                            Convert.ToDecimal(df[index, 27]) < tuple.End)
                        {
                            df[index, 85] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 5m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 28]) &&
                            Convert.ToDecimal(df[index, 28]) < tuple.End)
                        {
                            df[index, 76] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 6m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 29]) &&
                            Convert.ToDecimal(df[index, 29]) < tuple.End)
                        {
                            df[index, 86] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 6m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 30]) &&
                            Convert.ToDecimal(df[index, 30]) < tuple.End)
                        {
                            df[index, 77] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 7m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 31]) &&
                            Convert.ToDecimal(df[index, 31]) < tuple.End)
                        {
                            df[index, 87] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 7m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 32]) &&
                            Convert.ToDecimal(df[index, 32]) < tuple.End)
                        {
                            df[index, 78] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 8m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 33]) &&
                            Convert.ToDecimal(df[index, 33]) < tuple.End)
                        {
                            df[index, 88] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 8m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 34]) &&
                            Convert.ToDecimal(df[index, 34]) < tuple.End)
                        {
                            df[index, 79] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 9m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 35]) &&
                            Convert.ToDecimal(df[index, 35]) < tuple.End)
                        {
                            df[index, 89] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 9m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 36]) &&
                            Convert.ToDecimal(df[index, 36]) < tuple.End)
                        {
                            df[index, 80] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 10m ago    
                        }
                        if (tuple.Begin <= Convert.ToDecimal(df[index, 37]) &&
                            Convert.ToDecimal(df[index, 37]) < tuple.End)
                        {
                            df[index, 90] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 10m ago    
                        }
                    }
                    foreach(var tuple in ranges_minus)
                    {
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 18]) &&
                            Convert.ToDecimal(df[index, 18]) > tuple.End)
                        {
                            df[index, 71] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 1m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 19]) &&
                            Convert.ToDecimal(df[index, 19]) > tuple.End)
                        {
                            df[index, 81] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 1m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 20]) &&
                            Convert.ToDecimal(df[index, 20]) > tuple.End)
                        {
                            df[index, 72] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 2m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 21]) &&
                            Convert.ToDecimal(df[index, 21]) > tuple.End)
                        {
                            df[index, 82] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 2m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 22]) &&
                            Convert.ToDecimal(df[index, 22]) > tuple.End)
                        {
                            df[index, 73] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 3m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 23]) &&
                            Convert.ToDecimal(df[index, 23]) > tuple.End)
                        {
                            df[index, 83] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 3m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 24]) &&
                            Convert.ToDecimal(df[index, 24]) > tuple.End)
                        {
                            df[index, 74] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 4m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 25]) &&
                            Convert.ToDecimal(df[index, 25]) > tuple.End)
                        {
                            df[index, 84] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 4m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 26]) &&
                            Convert.ToDecimal(df[index, 26]) > tuple.End)
                        {
                            df[index, 75] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 5m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 27]) &&
                            Convert.ToDecimal(df[index, 27]) > tuple.End)
                        {
                            df[index, 85] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 5m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 28]) &&
                            Convert.ToDecimal(df[index, 28]) > tuple.End)
                        {
                            df[index, 76] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 6m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 29]) &&
                            Convert.ToDecimal(df[index, 29]) > tuple.End)
                        {
                            df[index, 86] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 6m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 30]) &&
                            Convert.ToDecimal(df[index, 30]) > tuple.End)
                        {
                            df[index, 77] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 7m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 31]) &&
                            Convert.ToDecimal(df[index, 31]) > tuple.End)
                        {
                            df[index, 87] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 7m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 32]) &&
                            Convert.ToDecimal(df[index, 32]) > tuple.End)
                        {
                            df[index, 78] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 8m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 33]) &&
                            Convert.ToDecimal(df[index, 33]) > tuple.End)
                        {
                            df[index, 88] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 8m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 34]) &&
                            Convert.ToDecimal(df[index, 34]) > tuple.End)
                        {
                            df[index, 79] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 9m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 35]) &&
                            Convert.ToDecimal(df[index, 35]) > tuple.End)
                        {
                            df[index, 89] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 9m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 36]) &&
                            Convert.ToDecimal(df[index, 36]) > tuple.End)
                        {
                            df[index, 80] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range HL 10m ago    
                        }
                        if (tuple.Begin >= Convert.ToDecimal(df[index, 37]) &&
                            Convert.ToDecimal(df[index, 37]) > tuple.End)
                        {
                            df[index, 90] = string.Format($"{tuple.Begin} - {tuple.End}"); //Range OC 10m ago    
                        }
                    }
                }
            }
            return df;
        }
    }
}