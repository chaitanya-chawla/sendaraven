using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers.service
{
    using System.Data.Entity;
    using Models;

    public class DbInitializers : NullDatabaseInitializer<EntityDbContext>
    {
        public override void InitializeDatabase(EntityDbContext context)
        {
            base.InitializeDatabase(context);
//            GetDeveloperRegisterEntities().ForEach(c => context.DeveloperRegisterEntities.Add(c));
//             GetUser1().ForEach(c => context.Users.Add(c));
//            context.SaveChanges();
        }
        //        protected override void Seed(EntityDbContext context)
        //        {
        //            GetDeveloperRegisterEntities().ForEach( c => context.DeveloperRegisterEntities.Add(c));
        //             GetUser1().ForEach(c => context.Users.Add(c));
        //            context.SaveChanges();
        //        }



        public List<DeveloperRegisterEntity>  GetDeveloperRegisterEntities()
        {
            var categories = new List<DeveloperRegisterEntity>
            {
                new DeveloperRegisterEntity("1","2","3","4","222")

            };
            return categories;
        }

        public List<User1> GetUser1()
        {
            var users = new List<User1>
            {
                new User1
                {
                    UserId = "u111",
                    TenantId = "tete",
                    Attributes = null
                }

            };
            return users;
        }




    }
}