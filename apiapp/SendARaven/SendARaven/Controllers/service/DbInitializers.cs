using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers.service
{
    using System.Data.Entity;
    using Models;

    public class DbInitializers : DropCreateDatabaseIfModelChanges<EntityDbContext>
    {

        protected override void Seed(EntityDbContext context)
        {
            context.Database.CreateIfNotExists();
            GetDeveloperRegisterEntities().ForEach( c => context.DeveloperRegisterEntities.Add(c));
        }

        

        public List<DeveloperRegisterEntity>  GetDeveloperRegisterEntities()
        {
            var categories = new List<DeveloperRegisterEntity>
            {
                new DeveloperRegisterEntity("1","2","3","4","222")

            };
            return categories;
        }

       


    }
}