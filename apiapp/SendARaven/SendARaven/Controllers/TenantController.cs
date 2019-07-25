using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Swagger.Annotations;

namespace SendARaven.Controllers
{
    using System.Data.SqlClient;
    using System.Web.Services.Protocols;
    using Models;
    using service;
    using Swashbuckle.Application;

    /**
     * Note @{BaseURl} = /v1/api/developer
     */
    public class TenantController : BaseController
    {

        protected DBCoreService dbCoreService;

        protected TenantController()
        {
            this.dbCoreService = new DBCoreService();
        }

        // GET /v1/api/developer/GetByTenantId/
        [SwaggerOperation("GetByTenantId")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [HttpGet]
        public TenantDetailsEntity GetByTenantId(String tenantId )
        {
            TenantDetailsEntity tenant;
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            using (var context = new EntityDbContext())
            {
                tenant = context.TenantDetailsEntities.Single(ten => ten.TenantId == tenantId);
            }

            return tenant;
        }

        // POST /v1/api/developer
        [SwaggerOperation("Register")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [HttpPost]
        public TenantDetailsEntity Register([FromBody] ResisterDeveloperRequest request)
        {
            GetHeaders(request,false);

            if (!ModelState.IsValid || request.apiKey != null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
           
            return dbCoreService.SaveDevEntity(request);
            
        }

        [SwaggerOperation("list")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpGet]
        public List<TenantDetailsEntity> List()
        {
            List<TenantDetailsEntity> allTenants;
            using (var context = new EntityDbContext())
            {
                allTenants = context.TenantDetailsEntities.ToList();
            }

            return allTenants;




            //            string str = $"Server=tcp:sendaraventestsql.database.windows.net,1433;" +
            //                                      "Initial Catalog=raven;Persist Security Info=False;" +
            //                                      "User ID={0};" +
            //                                      "Password={1}" +
            //                                      ";MultipleActiveResultSets=False;" +
            //                                      "Encrypt=True;TrustServerCertificate=False;" +
            //                                      "Connection Timeout=30;";
            //
            //            string connectionString = 
            //             string.Format(str, "ganesh", "Bangalore@123");
            //
            //            string queryString = "SELECT * from dbo.product";
            //
            //            // Specify the parameter value.
            //            int paramValue = 5;
            //
            //            // Create and open the connection in a using block. This
            //            // ensures that all resources will be closed and disposed
            //            // when the code exits.
            //            using (SqlConnection connection =
            //                new SqlConnection(connectionString))
            //            {
            //                // Create the Command and Parameter objects.
            //                SqlCommand command = new SqlCommand(queryString, connection);
            //
            //                // Open the connection in a try/catch block. 
            //                // Create and execute the DataReader, writing the result
            //                // set to the console window.
            //                try
            //                {
            //                    connection.Open();
            //                    SqlDataReader reader = command.ExecuteReader();
            //                    while (reader.Read())
            //                    {
            //                        Console.WriteLine("\t{0}\t{1}\t{2}",
            //                            reader[0], reader[1], reader[2]);
            //                    }
            //
            //                    reader.Close();
            //                }
            //                catch (Exception ex)
            //                {
            //                    Console.WriteLine(ex.Message);
            //                }
            //
            //                Console.ReadLine();
            //            }

        }
}
}
