using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendARaven.Controllers.service
{
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using Models;
    using Newtonsoft.Json;

    public static class DbCoreServiceFactory
    {
        public static DBCoreService coreService = new DBCoreService();
    }


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


        public User1 SaveUserEntity(RegisterUserRequest request)
        {
            User1 entity = new User1() {
                UserId = request.userId,
                TenantId = request.tenantId,
                Attributes = request.attributes
                };


            try
            {
                dbContext.Database.SqlQuery<User1>("exec dbo.InsertUser @userId, @tenantId, @json ",
                        new SqlParameter
                        {
                            ParameterName = "userId",
                            Value = entity.UserId
                        }, new SqlParameter
                        {
                            ParameterName = "tenantId",
                            Value = entity.TenantId
                        },
                        new SqlParameter
                        {
                            ParameterName = "json",
                            Value = JsonConvert.SerializeObject(entity.Attributes)
                        }

                    )
                    .ToList<User1>();
            }
            catch (Exception e)
            {
                Console.Write("exception while saving ", e);
            }


            //            var query = this.dbContext.Users.Add(entity);
            //            this.dbContext.SaveChanges();
            //            
            //            return query;
            
            return entity;

        }

        public User1 GetUserEntity(string userId)
        {

            var query = this.dbContext.Users.First(p => p.UserId == userId);

            this.dbContext.SaveChanges();
            return query;

        }


        public DeveloperRegisterEntity GetDevEntityEmail(String email)
        {

            var query = this.dbContext.DeveloperRegisterEntities.First(p => p.Email == email);
            return query;

        }

        public DeveloperRegisterEntity GetDevEntity(String tenantID)
        {

            var query = this.dbContext.DeveloperRegisterEntities.First(p => p.TenantId == tenantID);
            return query;

        }

        public List<User1> GetUsers(string querySt)
        {
            List<User1> result = new List<User1>(dbContext.Set<User1>().SqlQuery(querySt));
            return result;

        }
    }
}