using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers.service
{
    using Models;

    public class DbInitializers 
    {
       
        //        protected override void Seed(EntityDbContext context)
        //        {
        //            GetDeveloperRegisterEntities().ForEach( c => context.TenantDetailsEntities.Add(c));
        //             GetUser1().ForEach(c => context.Users.Add(c));
        //            context.SaveChanges();
        //        }



        public List<TenantDetailsEntity>  GetDeveloperRegisterEntities()
        {
            var categories = new List<TenantDetailsEntity>
            {

            };
            return categories;
        }

        public List<UserEntity> GetUser1()
        {
            var users = new List<UserEntity>
            {
                new UserEntity
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