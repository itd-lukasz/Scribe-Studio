using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.Tools
{
    public static class WindowFunctions
    {
        public static void CountDirection(this DataFrame df)
        {
            DataFrame currencies = df.Columns["symbol"].ValueCounts();
            foreach (DataFrameRow currency in currencies.Rows)
            {
                DataFrame local_df = df.Filter(df.Columns["symbol"].ElementwiseEquals(currency[0].ToString()));
                if (local_df.Rows.Count > 1)
                {
                    int index = 0;
                    local_df = local_df.OrderBy("time");
                    foreach (DataFrameRow row in local_df.Rows)
                    {
                        if (index > 0)
                        {
                            string direction = "n/a";
                            if (Convert.ToDecimal(row[2]) > Convert.ToDecimal(local_df[index - 1, 2]))
                            {
                                direction = "up";
                            }
                            if (Convert.ToDecimal(row[2]) < Convert.ToDecimal(local_df[index - 1, 2]))
                            {
                                direction = "down";
                            }
                            if (Convert.ToDecimal(row[2]) == Convert.ToDecimal(local_df[index - 1, 2]))
                            {
                                direction = "equal";
                            }
                            df[Convert.ToInt32(row[0]), 4] = direction;
                        }
                        index++;
                    }
                }
            }
        }

        public static void FindBestCurrencies(this DataFrame df)
        {
            DataFrame currencies = df.Columns["symbol"].ValueCounts();
            int index = 0;
            foreach (DataFrameRow currency in currencies.Rows)
            {
                DataFrame local_df = df.Filter(df.Columns["symbol"].ElementwiseEquals(currency[0].ToString()));
                local_df = local_df.Filter(local_df.Columns["direction"].ElementwiseEquals("up"));
                currencies[index, 1] = local_df.Rows.Count;
                index++;
            }
            currencies = currencies.Filter(currencies.Columns["Counts"].ElementwiseGreaterThan(4));
            currencies.PrettyPrint();
            if (currencies.Rows.Count > 0)
            {
                Console.ReadKey();
            }
        }
    }
}
