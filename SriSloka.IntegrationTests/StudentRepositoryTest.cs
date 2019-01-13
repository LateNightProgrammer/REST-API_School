using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using SriSloka.Data;
using SriSloka.Model;
using Xunit;

namespace SriSloka.IntegrationTests
{
    [Collection("Integration test collection")]
    public class StudentRepositoryTest : IntegrationTestBase
    {
        [Fact]
        public void CreateAStudentTest()
        {
            using (var context = GivenSriSlokaDbContext())
            {
                var studentRepository = new Repository<Student>(context);

                var student = new Student
                {
                    Firstname = "First Student",
                    Lastname = "Lastname",
                    IsActive = true,
                    DateOfBirth = new DateTime(),
                    Sex = Gender.Male,
                    InsertedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                };

                studentRepository.Insert(student);

                context.SaveChanges();

                var allStudents = studentRepository.All();

                allStudents.Count().Should().Be(0);

            }
        }
    }
}
