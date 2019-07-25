using System;
using System.Web;
using System.Data.Entity;

namespace SendARaven.Controllers.service
{
    using Models;
    using DbContext = System.Data.Entity.DbContext;

    public class EntityDbContext : DbContext
    {

        public EntityDbContext()
        {
            string s1 = "Server=tcp:sendaraventestsql.database.windows.net,1433;Initial Catalog=raven;Persist Security Info=False;" +
                        "User ID=ganesh;Password=Bangalore@123;" +
                        "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
           

            this.Database.Connection.ConnectionString = s1;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeveloperRegisterEntity>().ToTable("developer");
            modelBuilder.Entity<User1>().ToTable("user1");
           
        }

        public override DbSet<User1> Set<User1>()
        {
            return base.Set<User1>();
        }


        public DbSet<DeveloperRegisterEntity> DeveloperRegisterEntities { get; set; }
        
        public DbSet<User1> Users { get; set; }



      

    }
}