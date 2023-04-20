using System;
using System.Diagnostics;

namespace Sat.Recruitment.Classes
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; } = "Normal";
        public decimal Money { get; set; } = 0;

        public User(string name, string email, string address, string phone, string userType, decimal money)
        {
            Name = name;
            Email = NormalizeEmail(email);
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = money;
        }

        public string NormalizeEmail(string email)
        {
            try
            {
                var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                return string.Join("@", new string[] { aux[0], aux[1] });
            } 
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                throw new Exception($"Could not normalize email: {Email}, is the email valid?");
            }
        }

        public static bool operator == (User a, User b)
        {
            return a.Name.Equals(b.Name) && a.Email.Equals(b.Email) && a.Address.Equals(b.Address) ? true : false;
        }

        public static bool operator != (User a, User b)
        {
            return a.Name.Equals(b.Name) && a.Email.Equals(b.Email) && a.Address.Equals(b.Address) ? false : true;
        }

        protected abstract void CalculateGiftAndSetCurrentMoney();

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Name == user.Name &&
                   Email == user.Email &&
                   Address == user.Address;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Email, Address, Phone, UserType, Money);
        }

        public override string ToString()
        {
            return $"{Name},{Email},{Phone},{Address},{UserType},{Money}";
        }
    }
}
