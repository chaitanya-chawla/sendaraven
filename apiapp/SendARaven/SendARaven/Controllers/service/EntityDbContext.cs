using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections.Generic;

namespace SendARaven.Controllers.service
{
    using System.Data.SqlClient;
    using Models;
    using DbContext = System.Data.Entity.DbContext;

    public class EntityDbContext : DbContext
    {

        public EntityDbContext() 
        {
             this.Database.Connection.ConnectionString = "Server=tcp:sendaraventestsql.database.windows.net,1433;Initial Catalog=raven;Persist Security Info=False;" +
                                                         "User ID=ganesh;Password=Bangalore@123;" +
                                                         "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeveloperRegisterEntity>().ToTable("developer");
            modelBuilder.Entity<UserEntity>().ToTable("developer");

        }
        

        public DbSet<DeveloperRegisterEntity> DeveloperRegisterEntities { get; set; }

    }
}