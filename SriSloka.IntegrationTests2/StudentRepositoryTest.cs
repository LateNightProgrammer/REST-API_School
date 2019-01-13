using System;
using System.Linq;
using SriSloka.Data;
using SriSloka.Model;
using SriSloka.SharedKernel;
using SriSloka.ViewModel;
using Xunit;

namespace SriSloka.Api.Tests
{
    [Collection("Integration test collection")]
    public class StudentRepositoryIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void CreateAStudentTest()
        {
            using (var context = GivenSriSlokaDbContext())
            {
                var studentRepository = new Repository<Student>(context);

                var addressRepository = new Repository<Address>(context);

                var studentDetailsRepository = new Repository<StudentDetails>(context);

                var student = new StudentDto("First Student", "Lastname", 
                    DateTime.Now, Gender.Female);

                var address = new AddressDto("Street1", "Stree2", 500082);

                //addressRepository.Insert(address);
                
                var studentDetails = new StudentContactDetailsDto()
                {
                    FatherLastname = "father's lastname",
                    FatherFirstname = "firstname" ,
                    MotherLastname = "M Lastname",
                    MotherFirstname = "M First",
                    FatherMobileNumber = "12346879884",
                    FatherHighestQualification = Qualification.Phd,
                    FatherWorkingAs = "Engineer",
                    MotherHighestQualification = Qualification.Metric,
                    MotherWokringAs = "house wife"
                };
                student.StudentContactDetails = studentDetails;
                student.AddressDetails = address;

                Console.WriteLine(student.ToJson());

               // studentRepository.Insert(student);

               // address.StudentId = studentDetails.StudentId = student.StudentId;

                //studentDetailsRepository.Insert(studentDetails);

                //addressRepository.Insert(address);

                var retrievedAddress = student.StudentContactDetails;

                //var allStudents = studentRepository.All();

                //foreach(var s in allStudents)
                //    Console.WriteLine(s.Firstname);

            }
        }

        [Fact]
        public void TestStudentEnrollments()
        {
            using (var context = GivenSriSlokaDbContext())
            {
                var enrollments = new Enrollments(3)
                {
                    StudentId = 2,
                    IsActive = true,
                    EnrollmentDate = DateTime.Now
                };

                var studentRepository = new Repository<Student>(context);

                var student = studentRepository.FindByInclude(x => x.StudentId == 2, x => x.Enrollments)
                    .FirstOrDefault();

                student?.Enrollments.Add(enrollments);

                enrollments.ObjectState = ObjectState.Added;

                studentRepository.Update(student);

                var studentWithEnrollments =
                    studentRepository.FindByInclude(x => x.StudentId == 2, x => x.Enrollments).FirstOrDefault();

                Assert.True(studentWithEnrollments?.Enrollments.Count > 0);
            }
        }

        [Fact]
        public void TestEnrollmentsDto()
        {
            
        }
    }
}
