using Sat.Recruitment.Classes;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Utils
{
    public static class UserReader
    {
        private static readonly List<User> _users = new List<User>();

        private static StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        public static List<User> GetUsersFromFile()
        {
            var reader = ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;

                var Name = line.Split(',')[0].ToString();
                var Email = line.Split(',')[1].ToString();
                var Phone = line.Split(',')[2].ToString();
                var Address = line.Split(',')[3].ToString();
                var UserType = line.Split(',')[4].ToString();
                var Money = line.Split(',')[5].ToString();

                User user = UserType switch
                {
                    "SuperUser" => new SuperUser(Name, Email, Address, Phone, UserType, decimal.Parse(Money)),

                    "Premium" => new PremiumUser(Name, Email, Address, Phone, UserType, decimal.Parse(Money)),

                    _ => new NormalUser(Name, Email, Address, Phone, UserType, decimal.Parse(Money)),
                };
                _users.Add(user);
            }
            reader.Close();
            return _users;
        }
    }
}
