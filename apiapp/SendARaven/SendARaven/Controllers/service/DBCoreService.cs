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


        public List<TenantDetailsEntity> ListDeveloperRegisterEntities()
        {
            this.dbContext.Database.BeginTransaction();
            IQueryable<TenantDetailsEntity> query = this.dbContext.TenantDetailsEntities;

            var list =  query.ToList();
            this.dbContext.Database.CurrentTransaction.Commit();
            return list;
        }

        public TenantDetailsEntity SaveDevEntity(ResisterDeveloperRequest request )
        {

            String apikey = Guid.NewGuid().ToString();

            String tenantKey = Guid.NewGuid().ToString();
            TenantDetailsEntity entity = new TenantDetailsEntity(apikey,tenantKey, request.Email,request.CompanyName,request.Name);
            
            var query = this.dbContext.TenantDetailsEntities.Add(entity).Entity;
            this.dbContext.SaveChanges();
            return query;

        }


        public UserEntity SaveUserEntity()
        {
            String apikey = Guid.NewGuid().ToString();
            Dictionary<String, String> a 
                = new Dictionary<String, String>();
            a.Add("a","b");
            a.Add("a1", "b1");

            UserEntity entity = new UserEntity() {
                UserId = apikey ,
                TenantId = "1212",
                Attributes = a
                };

            var query = this.dbContext.UserEntities.Add(entity).Entity;
            this.dbContext.SaveChanges();
            
            return query;

        }

        public UserEntity GetUserEntity(string userId)
        {

            var query = this.dbContext.UserEntities.First(p => p.UserId == userId);

            this.dbContext.SaveChanges();

            return query;

        }



        public TenantDetailsEntity GetDevEntity(String tenantID)
        {

            var query = this.dbContext.TenantDetailsEntities.First(p => p.TenantId == tenantID);
            return query;

        }

    }
}