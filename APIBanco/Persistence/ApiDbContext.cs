using System.Collections.Generic;
using APIBanco.Entities;

namespace APIBanco.Persistence
{
    public class ApiDbContext
    {
        public List<User> Users { get; set; }
        public List<Account> Accounts { get; set; }

        public ApiDbContext()
        {
            Users = new List<User>();
            Accounts = new List<Account>();
        }
    }
}
