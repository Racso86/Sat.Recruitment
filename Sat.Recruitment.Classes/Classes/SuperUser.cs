using System.Security.Policy;
using System;

namespace Sat.Recruitment.Classes
{
    public sealed class SuperUser : User
    {
        public SuperUser(string name, string email, string address, string phone, string userType, decimal money) : base(name, email, address, phone, userType, money)
        {
            CalculateGiftAndSetCurrentMoney();
        }
        protected override void CalculateGiftAndSetCurrentMoney()
        {
            if (Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = Money * percentage;
                Money = Money + gif;
            }
        }
    }
}
