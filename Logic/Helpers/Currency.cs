using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.Helpers
{
    public class Currency
    {
        public enum CurrencyStatus
        {
            WaitingForProcessing,
            Processing,
            Searching,
            Processed
        }

        public string Symbol { get; set; }

        public CurrencyStatus Status { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
