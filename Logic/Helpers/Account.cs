using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using binanceBotNetCore.Logic.BinanceApi;
using binanceBotNetCore.Logic.Engine;
using Newtonsoft.Json;

namespace binanceBotNetCore.Logic.Helpers
{
    public class Account
    {
        public decimal BalanceUSDT { get; set; }
        public List<WalletPosition> Wallet { get; set; }
        public List<Currency> ProcessCurrencies { get; set; }
        public List<OrdersPair> Orders { get; set; }

        public Account()
        {
            BalanceUSDT = 100;
            ProcessCurrencies = new List<Currency>();
            Orders = new List<OrdersPair>();
        }

        async public void ProcessCurrenciesAsync()
        {
            foreach (Currency currency in ProcessCurrencies.Distinct().ToList())
            {
                Task.Run(() => Core.ProcessCurrencyAsync(currency));
            }
        }

        async public void ProcessOrders()
        {
            foreach (OrdersPair ordersPair in Orders)
            {
                if (ordersPair.FirstOrder.status != "FILLED")
                {
                    Task.Run(() => ordersPair.FirstOrder.RefreshStatus());
                }
                if (ordersPair.SecondOrder.status != "FILLED")
                {
                    Task.Run(() => ordersPair.SecondOrder.RefreshStatus());
                }
            }
        }

        public void SaveAccount()
        {
            string this_class = JsonConvert.SerializeObject(this);
            StreamWriter sw = new StreamWriter("account.json");
            sw.Write(this_class);
            sw.Close();
        }

        public void LoadAccount()
        {
            try
            {
                StreamReader sr = new StreamReader("account.json");
                Account account = JsonConvert.DeserializeObject<Account>(sr.ReadToEnd());
                sr.Close();
                BalanceUSDT = account.BalanceUSDT;
                Wallet = account.Wallet;
                Orders = account.Orders;
            }
            catch (Exception exc)
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