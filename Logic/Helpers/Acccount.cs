using System;
using System.Collections.Generic;

namespace binanceBotNetCore.Logic.Helpers
{
    public class Account
    {
        public decimal BalanceUSDT { get; set; }
        public List<WalletPosition> Wallet { get; set; }

        public Account()
        {
            BalanceUSDT = 100;
            LoadAccount();
        }

        public void SaveAccount()
        {
            throw new NotImplementedException();
        }

        private void LoadAccount()
        {
            throw new NotImplementedException();
        }
    }
}