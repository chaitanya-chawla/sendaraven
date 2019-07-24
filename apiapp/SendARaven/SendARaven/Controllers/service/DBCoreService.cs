using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers.service
{
    using System.Security.Cryptography;
    using Models;

    public class DBCoreService
    {
        private EntityDbContext dbContext;
        public DBCoreService()
        {

            this.dbContext = new EntityDbContext();
        }


        public List<DeveloperRegisterEntity> ListDeveloperRegisterEntities()
        {
            this.dbContext.Database.BeginTransaction();
            IQueryable<DeveloperRegisterEntity> query = this.dbContext.DeveloperRegisterEntities;

            var list =  query.ToList();
            this.dbContext.Database.CurrentTransaction.Commit();
            return list;
        }

        public DeveloperRegisterEntity SaveDevEntity(ResisterDeveloperRequest request )
        {

            String apikey = Guid.NewGuid().ToString();

            String tenantKey = Guid.NewGuid().ToString();
            DeveloperRegisterEntity entity = new DeveloperRegisterEntity(apikey,tenantKey, request.Email,request.CompanyName,request.Name);
            
            var query = this.dbContext.DeveloperRegisterEntities.Add(entity);
            this.dbContext.SaveChanges();
            return query;

        }


        public User1 SaveUserEntity()
        {
            String apikey = Guid.NewGuid().ToString();
            Dictionary<String, String> a 
                = new Dictionary<String, String>();
            a.Add("a","b");
            a.Add("a1", "b1");

            User1 entity = new User1() {
                UserId = apikey ,
                TenantId = "1212",
                Attributes = a
                };

            var query = this.dbContext.Users.Add(entity);
            this.dbContext.SaveChanges();
            
            return query;

        }

        public User1 GetUserEntity(string userId)
        {

            var query = this.dbContext.Users.First(p => p.UserId == userId);

            this.dbContext.SaveChanges();

            return query;

        }



        public DeveloperRegisterEntity GetDevEntity(String tenantID)
        {

            var query = this.dbContext.DeveloperRegisterEntities.First(p => p.TenantId == tenantID);
            return query;

        }

    }
}