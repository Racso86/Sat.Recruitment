using System;
using System.IO;

namespace Sat.Recruitment.Utils
{
    public static class UserWriter
    {
        public static void WriteUser(string user)
        {
            File.AppendAllText(Directory.GetCurrentDirectory() + "/Files/Users.txt", Environment.NewLine + user);
        }
    }
}
