using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyMeService.Wcf.Providers
{
    public class Users : List<User>
    {
        public static Users Load()
        {
            Users users = new Users();

            users.Add(new User()
            {
                UserName = "miguel",
                Roles = new List<string>() { "user", "admin" }
            });
            users.Add(new User()
            {
                UserName = "elena",
                Roles = new List<string>() { "user" }
            });
            users.Add(new User()
            {
                UserName = "victoria",
                Roles = new List<string>() { "user" }
            });

            return users;
        }

        public User FindByName(string userName)
        {
            return this.Find(u => u.UserName == userName);
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}