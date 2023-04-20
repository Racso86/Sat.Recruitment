using System;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace Sat.Recruitment.Classes
{
    public sealed class NormalUser : User
    {
        public NormalUser(string name, string email, string address, string phone, string userType, decimal money) : base (name, email, address, phone, userType, money)
        {
            CalculateGiftAndSetCurrentMoney();
        }
        protected override void CalculateGiftAndSetCurrentMoney()
        {
            if (this.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gift = this.Money * percentage;
                Money = Money + gift;
            }
            if (this.Money < 100)
            {
                if (this.Money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gift = this.Money * percentage;
                    Money = Money + gift;
                }
            }
        }
    }
}
