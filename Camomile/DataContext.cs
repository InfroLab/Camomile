using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Camomile
{
    public class UserContext : DbContext
    {
        //Personal note: I could use connection strings in AppConfig
        public UserContext() : base("UserDB"){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}