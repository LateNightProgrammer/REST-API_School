using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SriSloka.Data;

namespace SriSloka.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected static SriSlokaDbContext GivenSriSlokaDbContext(bool beginTransaction = true)
        {
            var context = new SriSlokaDbContext(new DbContextOptionsBuilder()
                .UseSqlServer(SrislokaTestConnection.ConnectionString)
                .Options);

            if (beginTransaction)
                context.Database.BeginTransaction();
            return context;
        }

        private static SqlConnectionStringBuilder SrislokaTestConnection =>
            new SqlConnectionStringBuilder
            {
                DataSource = @".\\SqlExpress",
                InitialCatalog = "SrislokaTest",
                IntegratedSecurity = true
            };
    }
}
