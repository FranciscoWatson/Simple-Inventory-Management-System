using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Simple_Inventory_Managment_System.Repository_Pattern;
using MongoDB.Driver;

namespace Simple_Inventory_Managment_System.Simple_Factory
{
    public class ProductRepositoryFactory
    {
        public static IProductRepository CreateProductRepository(IConfiguration configuration)
        {
            var useMongoDB = bool.Parse(configuration.GetSection("UseMongoDB").Value);

            if (useMongoDB)
            {
                var mongoDBConnectionString = configuration.GetConnectionString("MongoDBConnection");
                var mongoClient = new MongoClient(mongoDBConnectionString);
                var mongoDatabase = mongoClient.GetDatabase("SIMS");
                return new MongoDBProductRepository(mongoDatabase);
            }
            else
            {
                var sqlServerConnectionString = configuration.GetConnectionString("SqlServerConnection");
                var sqlConnection = new SqlConnection(sqlServerConnectionString);
                return new SqlProductRepository(sqlConnection);
            }
        }
    }
}
