using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using binanceBotNetCore.Logic.Engine;
using Newtonsoft.Json;

namespace binanceBotNetCore.Logic.Helpers
{
    public class Account
    {
        public decimal BalanceUSDT { get; set; }
        public List<WalletPosition> Wallet { get; set; }
        public List<string> UnderChecking { get; set; }

        public Account()
        {
            BalanceUSDT = 100;
            UnderChecking = new List<string>();
            LoadAccount();
        }

        async public void ProcessCurrenciesAsync()
        {
            foreach(string currency in UnderChecking.Distinct().ToList())
            {
                Console.WriteLine($"Processing currency {currency}");
                Task.Run(()=> Core.ProcessCurrencyAsync(currency));
            }
        }

        public void SaveAccount()
        {
            string this_class = JsonConvert.SerializeObject(this);
            StreamWriter sw = new StreamWriter("account.json");
            sw.Write(this_class);
            sw.Close();
        }

        private void LoadAccount()
        {
            try
            {
                StreamReader sr = new StreamReader("account.json");
                Account acccount = JsonConvert.DeserializeObject<Account>(sr.ReadToEnd());
                BalanceUSDT = acccount.BalanceUSDT;
                Wallet = acccount.Wallet;
            }
            catch(Exception exc)
            {
                Console.WriteLine("Account restoring failed!");
                Console.WriteLine(exc.Message);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Press any key to continue");
                Console.WriteLine("-------------------------");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}