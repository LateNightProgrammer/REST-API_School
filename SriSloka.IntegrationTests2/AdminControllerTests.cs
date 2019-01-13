using System;
using SriSloka.Data;
using SriSloka.Model;
using Xunit;

namespace SriSloka.Api.Tests
{
    [Collection("Integration test collection")]
    public class AdminControllerIntegrationTests : IntegrationTestBase
    {
        [Fact]
        public void CreateTests()
        {
            using (var context = GivenSriSlokaDbContext())
            {
                var standardRepository = new Repository<Standard>(context);

                var standard = new Standard
                {
                    Name = "Class1",
                    Description = "This is first standard.",
                    IsDelete = false,
                };

                standardRepository.Insert(standard);


                var standards = standardRepository.All();

                //Assert.Equal(standards.Count(), 1);


            }
        }

    [Fact]
      public void DateTimeTest()
    {
      var dateTime = DateTime.Today.AddMonths(-4).AddDays(-18);
      var formatedstring = dateTime.ToString("yyyyMdd");
      var formatedstring2 = dateTime.ToString("yyyyMd");
      Console.WriteLine(dateTime.ToString("yyyyMdd"));
      Console.WriteLine(dateTime.ToString("yyyyMd"));
      Console.ReadLine();
    }
    }
}
