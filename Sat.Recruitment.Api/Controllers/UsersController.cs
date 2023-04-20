using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("/user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var errors = "";

            Utils.UserDataValidator.ValidateErrors(name, email, address, phone, ref errors);

            if (errors != null && errors != "")
                return new Result(false, errors);

            User newUser = userType switch
            {
                "SuperUser" => new SuperUser(name, email, address, phone, userType, decimal.Parse(money)),
                "Premium" => new PremiumUser(name, email, address, phone, userType, decimal.Parse(money)),
                _ => new NormalUser(name, email, address, phone, userType, decimal.Parse(money)),
            };

            foreach (var user in Utils.UserReader.GetUsersFromFile())
            {
                if (user == newUser)
                {
                    Debug.WriteLine("The user is duplicated");
                    return new Result(false, "The user is duplicated");
                }
            }
            Utils.UserWriter.WriteUser(newUser.ToString());
            Debug.WriteLine("User Created");
            return new Result(true, "User Created");
        }
    }
}
