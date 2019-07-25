using System;
using Microsoft.EntityFrameworkCore;
using SendARaven.Models;

namespace SendARaven.Controllers.service
{

    public class EntityDbContext : DbContext
    {
        string s1 = "Server=tcp:sendaraventestsql.database.windows.net,1433;Initial Catalog=raven;Persist Security Info=False;" +
                    "User ID=ganesh;Password=Bangalore@123;" +
                    "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private String connectionString =
            "Server=tcp:sendaraventestsql.database.windows.net,1433;" +
            "Initial Catalog=hack19test2;Persist Security Info=False;" +
            "User ID=ganesh;Password=Bangalore@123;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private String connectionString2 =
            "Server=tcp:sendravenserver.database.windows.net,1433;Initial Catalog=sendaraven;Persist Security Info=False;User ID=chaitanya;Password=Bangalore@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString2);
        }
        

        public DbSet<TenantDetailsEntity> TenantDetailsEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        //public DbSet<ChannelEntity> ChannelEntities { get; set; }
        //public DbSet<TemplateEntity> TemplateEntities { get; set; }

    }
}