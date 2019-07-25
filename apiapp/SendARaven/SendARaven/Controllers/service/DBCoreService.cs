using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp.Extensions;

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
            List<TenantDetailsEntity> allTenants;
            using (var context = new EntityDbContext())
            {
                allTenants = context.TenantDetailsEntities.ToList(); 
            }

            return allTenants;
            //this.dbContext.Database.BeginTransaction();
            //IQueryable<TenantDetailsEntity> query = this.dbContext.TenantDetailsEntities;

            //var list =  query.ToList();
            //this.dbContext.Database.CurrentTransaction.Commit();
            //return list;
        }

        public TenantDetailsEntity SaveDevEntity(ResisterDeveloperRequest request )
        {

            String apikey = Guid.NewGuid().ToString();

            String tenantKey = Guid.NewGuid().ToString();

            TenantDetailsEntity tenant = new TenantDetailsEntity(apikey, tenantKey, request.Email, request.CompanyName);

            using (var context = new EntityDbContext())
            {
                context.TenantDetailsEntities.Add(tenant);
                context.SaveChanges();
            }

            return tenant;

        }


        public void SaveUserEntity(UserEntity user)
        {
            using (var context = new EntityDbContext())
            {
                dbContext.Database.ExecuteSqlCommand("InsertUser @userId, @tenantId, @attributes",
                    parameters: new[] { user.UserId, user.TenantId, JsonConvert.SerializeObject(user.Attributes) });
            }

            
            
        }

        public List<ChannelEntity> GetActiveChannelsByType(Enums.ChannelType channelType, string tenantId)
        {
            List<ChannelEntity> channelEntities;
            using (var context = new EntityDbContext())
            {
                channelEntities = context.ChannelEntities.Where(channel => channel.ChannelType== channelType && channel.TenantId == tenantId && channel.Status==1).ToList();
            }

            return channelEntities;
        }
        public List<UserChannelInformation> GetUserChannelInformation(string userId, string tenantId)
        {
            List<UserChannelInformation> userChannelInformations;
            using (var context = new EntityDbContext())
            {
                userChannelInformations = context.UserChannelInformations.Where(channel => channel.UserId == userId && channel.TenantId == tenantId).ToList();
            }

            return userChannelInformations;
        }

        

        public UserEntity GetUserEntity(string userId, string tenantId)
        {
            UserEntity user;
            using (var context = new EntityDbContext())
            {
                user = context.UserEntities.Single(use => use.UserId == userId && use.TenantId == tenantId);
            }

            return user;
        }

        public List<UserEntity> GetUsersByAttributes(Dictionary<string,string> attributes, string tenantId)
        {

            List<UserEntity> users;
            string query = "select * from myuser where ";

            int counter = 0;
            int endPoint = attributes.Count;
            foreach (var attr in attributes)
            {
                query = query + " ( JSON_VALUE(attributes, '$." + attr.Key + " ') " + " = " + "'" + attr.Value + "' ) ";

                if (counter != endPoint - 1)
                {
                    query = query + " and ";
                }
                counter++;
            }

            using (var dbContext = new EntityDbContext())
            {
                users = dbContext.UserEntities.FromSql(query).ToList();
            }

            return users;
        }



        public TenantDetailsEntity GetDevEntity(String tenantID)
        {

            var query = this.dbContext.TenantDetailsEntities.First(p => p.TenantId == tenantID);
            return query;

        }

    }
}