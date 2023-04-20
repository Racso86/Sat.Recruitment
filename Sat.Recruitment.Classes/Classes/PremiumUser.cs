using System.Security.Policy;
using System;

namespace Sat.Recruitment.Classes
{
    public sealed class PremiumUser : User
    {
        public PremiumUser(string name, string email, string address, string phone, string userType, decimal money) : base(name, email, address, phone, userType, money)
        {
            CalculateGiftAndSetCurrentMoney();
        }
        protected override void CalculateGiftAndSetCurrentMoney()
        {
            if (Money > 100)
            {
                var gif = Money * 2;
                Money = Money + gif;
            }
        }
    }
}
