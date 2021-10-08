using System;
using Microsoft.Data.Analysis;

namespace binanceBotNetCore.Logic.Engine
{
    public static class Figures
    {
        public static DataFrame CountNightlyStar(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 91] = false;
                if (index >= 2)
                {
                    decimal before_prev_open = Convert.ToDecimal(df[index - 2, 2]);
                    decimal before_prev_close = Convert.ToDecimal(df[index - 2, 5]);
                    decimal current_open = Convert.ToDecimal(df[index, 2]);
                    decimal current_close = Convert.ToDecimal(df[index, 5]);
                    if (current_close < current_open && before_prev_open < before_prev_close)
                    {
                        df[index, 91] = true;
                    }
                }
            }
            return df;
        }

        public static DataFrame CountAccessionBear(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 92] = false;
                if (index >= 2)
                {
                    decimal prev_open = Convert.ToDecimal(df[index - 1, 2]);
                    decimal prev_close = Convert.ToDecimal(df[index - 1, 5]);
                    decimal current_open = Convert.ToDecimal(df[index, 2]);
                    decimal current_close = Convert.ToDecimal(df[index, 5]);
                    if (prev_open < prev_close && current_open > current_close)
                    {
                        decimal prev_height = prev_close - prev_open;
                        decimal current_height = current_open - current_close;
                        if (current_height > prev_height)
                        {
                            df[index, 92] = true;
                        }
                    }
                }
            }
            return df;
        }

        public static DataFrame CountDarkCloud(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 93] = false;
                if (index >= 1)
                {
                    decimal prev_open = Convert.ToDecimal(df[index - 1, 2]);
                    decimal prev_close = Convert.ToDecimal(df[index - 1, 5]);
                    decimal current_open = Convert.ToDecimal(df[index, 2]);
                    decimal current_close = Convert.ToDecimal(df[index, 5]);
                    if (prev_open < prev_close && current_open > current_close)
                    {
                        decimal prev_height = prev_close - prev_open;
                        decimal current_height = current_open - current_close;
                        if (current_height < prev_height && current_height >= (prev_height / 2.0m))
                        {
                            df[index, 93] = true;
                        }
                    }
                }
            }
            return df;
        }

        public static DataFrame CountFallingStar(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 94] = false;
                decimal current_high = Convert.ToDecimal(df[index, 3]);
                decimal current_low = Convert.ToDecimal(df[index, 4]);
                decimal current_open = Convert.ToDecimal(df[index, 2]);
                decimal current_close = Convert.ToDecimal(df[index, 5]);
                decimal range_top = Convert.ToDecimal(df[index, 5]);
                if (current_open > range_top)
                {
                    range_top = current_open;
                }
                decimal one_percent = Math.Round((current_high - current_low) / 100.0m, 8);
                if (range_top <= (current_low + (one_percent * 30)))
                {
                    df[index, 94] = true;
                }
            }
            return df;
        }

        public static DataFrame CountMorningStar(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 95] = false;
                if (index >= 2)
                {
                    decimal before_prev_open = Convert.ToDecimal(df[index - 2, 2]);
                    decimal before_prev_close = Convert.ToDecimal(df[index - 2, 5]);
                    decimal current_open = Convert.ToDecimal(df[index, 2]);
                    decimal current_close = Convert.ToDecimal(df[index, 5]);
                    if (current_close > current_open && before_prev_open > before_prev_close)
                    {
                        df[index, 95] = true;
                    }
                }
            }
            return df;
        }

        public static DataFrame CountAccessionBoom(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 96] = false;
                if (index >= 1)
                {
                    decimal prev_open = Convert.ToDecimal(df[index - 1, 2]);
                    decimal prev_close = Convert.ToDecimal(df[index - 1, 5]);
                    decimal current_open = Convert.ToDecimal(df[index, 2]);
                    decimal current_close = Convert.ToDecimal(df[index, 5]);
                    if (prev_open > prev_close && current_open < current_close)
                    {
                        decimal prev_height = prev_close - prev_open;
                        decimal current_height = current_open - current_close;
                        if (current_height > prev_height)
                        {
                            df[index, 96] = true;
                        }
                    }
                }
            }
            return df;
        }

        public static DataFrame CountPenetration(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 97] = false;
                if (index >= 1)
                {
                    decimal prev_open = Convert.ToDecimal(df[index - 1, 2]);
                    decimal prev_close = Convert.ToDecimal(df[index - 1, 5]);
                    decimal current_open = Convert.ToDecimal(df[index, 2]);
                    decimal current_close = Convert.ToDecimal(df[index, 5]);
                    if (prev_open > prev_close && current_open < current_close)
                    {
                        decimal prev_height = prev_open - prev_close;
                        decimal current_height = current_close - current_open;
                        if (current_height < prev_height && current_height >= (prev_height / 2.0m))
                        {
                            df[index, 97] = true;
                        }
                    }
                }
            }
            return df;
        }

        public static DataFrame CountPinbar(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 98] = false;
                decimal current_high = Convert.ToDecimal(df[index, 3]);
                decimal current_low = Convert.ToDecimal(df[index, 4]);
                decimal current_open = Convert.ToDecimal(df[index, 2]);
                decimal current_close = Convert.ToDecimal(df[index, 5]);
                decimal range_bottom = current_close;
                if (current_open < range_bottom)
                {
                    range_bottom = current_open;
                }
                decimal one_percent = Math.Round((current_high - current_low) / 100.0m, 8);
                if (range_bottom >= (current_high - (one_percent * 30)))
                {
                    df[index, 98] = true;
                }
            }
            return df;
        }

        public static DataFrame CountDoji(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                df[index, 99] = false;
                decimal current_high = Convert.ToDecimal(df[index, 3]);
                decimal current_low = Convert.ToDecimal(df[index, 4]);
                decimal current_open = Convert.ToDecimal(df[index, 2]);
                decimal current_close = Convert.ToDecimal(df[index, 5]);
                decimal half = (current_high - current_low) / 2.0m;
                decimal one_percent = Math.Round((current_high - current_low) / 100.0m, 8);
                decimal range_top = current_open;
                decimal range_bottom = current_close;
                if (range_top < range_bottom)
                {
                    range_bottom = current_open;
                    range_top = current_close;
                }
                if ((((current_low + half) + (one_percent * 10)) > range_top) && (((current_low + half) - (one_percent * 10)) < range_bottom))
                {
                    df[index, 99] = true;
                }
            }
            return df;
        }

        public static DataFrame CountBinaryData(DataFrame df)
        {
            for (int index = 0; index < df.Rows.Count; index++)
            {
                if (index > 9)
                {
                    df[index, 100] = string.Format($"{ReturnFigureValue(Convert.ToBoolean(df[index - 1, 91]), Convert.ToBoolean(df[index - 1, 92]), Convert.ToBoolean(df[index - 1, 93]), Convert.ToBoolean(df[index - 1, 94]), Convert.ToBoolean(df[index - 1, 95]), Convert.ToBoolean(df[index - 1, 96]), Convert.ToBoolean(df[index - 1, 97]), Convert.ToBoolean(df[index - 1, 98]), Convert.ToBoolean(df[index - 1, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 2, 91]), Convert.ToBoolean(df[index - 2, 92]), Convert.ToBoolean(df[index - 2, 93]), Convert.ToBoolean(df[index - 2, 94]), Convert.ToBoolean(df[index - 2, 95]), Convert.ToBoolean(df[index - 2, 96]), Convert.ToBoolean(df[index - 2, 97]), Convert.ToBoolean(df[index - 2, 98]), Convert.ToBoolean(df[index - 2, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 3, 91]), Convert.ToBoolean(df[index - 3, 92]), Convert.ToBoolean(df[index - 3, 93]), Convert.ToBoolean(df[index - 3, 94]), Convert.ToBoolean(df[index - 3, 95]), Convert.ToBoolean(df[index - 3, 96]), Convert.ToBoolean(df[index - 3, 97]), Convert.ToBoolean(df[index - 3, 98]), Convert.ToBoolean(df[index - 3, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 4, 91]), Convert.ToBoolean(df[index - 4, 92]), Convert.ToBoolean(df[index - 4, 93]), Convert.ToBoolean(df[index - 4, 94]), Convert.ToBoolean(df[index - 4, 95]), Convert.ToBoolean(df[index - 4, 96]), Convert.ToBoolean(df[index - 4, 97]), Convert.ToBoolean(df[index - 4, 98]), Convert.ToBoolean(df[index - 4, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 5, 91]), Convert.ToBoolean(df[index - 5, 92]), Convert.ToBoolean(df[index - 5, 93]), Convert.ToBoolean(df[index - 5, 94]), Convert.ToBoolean(df[index - 5, 95]), Convert.ToBoolean(df[index - 5, 96]), Convert.ToBoolean(df[index - 5, 97]), Convert.ToBoolean(df[index - 5, 98]), Convert.ToBoolean(df[index - 5, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 6, 91]), Convert.ToBoolean(df[index - 6, 92]), Convert.ToBoolean(df[index - 6, 93]), Convert.ToBoolean(df[index - 6, 94]), Convert.ToBoolean(df[index - 6, 95]), Convert.ToBoolean(df[index - 6, 96]), Convert.ToBoolean(df[index - 6, 97]), Convert.ToBoolean(df[index - 6, 98]), Convert.ToBoolean(df[index - 6, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 8, 91]), Convert.ToBoolean(df[index - 8, 92]), Convert.ToBoolean(df[index - 8, 93]), Convert.ToBoolean(df[index - 8, 94]), Convert.ToBoolean(df[index - 8, 95]), Convert.ToBoolean(df[index - 8, 96]), Convert.ToBoolean(df[index - 8, 97]), Convert.ToBoolean(df[index - 8, 98]), Convert.ToBoolean(df[index - 8, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 9, 91]), Convert.ToBoolean(df[index - 9, 92]), Convert.ToBoolean(df[index - 9, 93]), Convert.ToBoolean(df[index - 9, 94]), Convert.ToBoolean(df[index - 9, 95]), Convert.ToBoolean(df[index - 9, 96]), Convert.ToBoolean(df[index - 9, 97]), Convert.ToBoolean(df[index - 9, 98]), Convert.ToBoolean(df[index - 9, 99]))}" +
                                                   $"{ReturnFigureValue(Convert.ToBoolean(df[index - 10, 91]), Convert.ToBoolean(df[index - 10, 92]), Convert.ToBoolean(df[index - 10, 93]), Convert.ToBoolean(df[index - 10, 94]), Convert.ToBoolean(df[index - 10, 95]), Convert.ToBoolean(df[index - 10, 96]), Convert.ToBoolean(df[index - 10, 97]), Convert.ToBoolean(df[index - 10, 98]), Convert.ToBoolean(df[index - 10, 99]))}");
                }
            }
            return df;
        }

        private static string ReturnFigureValue(bool NightlyStar, bool AccessionBear, bool DarkCloud, bool FallingStar, bool MorningStar, bool AccessionBoom, bool Penetration, bool Pinbar, bool Doji)
        {
            if (NightlyStar)
                return "1";
            if (AccessionBear)
                return "2";
            if (DarkCloud)
                return "3";
            if (FallingStar)
                return "4";
            if (MorningStar)
                return "5";
            if (AccessionBoom)
                return "6";
            if (Penetration)
                return "7";
            if (Pinbar)
                return "8";
            if (Doji)
                return "9";
            return "-1";
        }
    }
}