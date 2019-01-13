using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SriSloka.Api.Controllers;
using SriSloka.Data;
using SriSloka.Model;
using SriSloka.ViewModel;
using Xunit;

namespace SriSloka.Api.Tests
{
	[Collection("Unit test collection")]
	public class StudentsControllerTests
	{
		private readonly Mock<IRepository<Student>> _studentRepository;

		private readonly Mock<IMapper> _autoMapper;

		private readonly Mock<ILogger<StudentsController>> _studentLogger;

		private readonly Mock<SriSlokaDbContext> _dbContext;

		private readonly Mock<RoleManager<IdentityRole>> _roleManager;

		private readonly Mock<UserManager<ApplicationUser>> _userManager;

		private readonly Mock<IConfiguration> _configuration;

		public StudentsControllerTests()
		{
			_studentRepository = new Mock<IRepository<Student>>();

			_autoMapper = new Mock<IMapper>();

			_studentLogger = new Mock<ILogger<StudentsController>>();

			var options = new DbContextOptions<SriSlokaDbContext>();

			_dbContext = new Mock<SriSlokaDbContext>(options);

			_roleManager = GetRoleManagerMock();

			_userManager = GetUserManagerMock();

			_configuration = new Mock<IConfiguration>();
		}

		[Fact]
		public void GetStudentsByName_ShouldHitMappingAsExpected()
		{
			var studentController = new StudentsController(_studentRepository.Object,
				_autoMapper.Object, _studentLogger.Object, _dbContext.Object,
				_roleManager.Object, _userManager.Object, _configuration.Object);

			var searchLiteral = "test";

			var mockResult = new List<Student>()
			{
				new Student("test","hello",DateTime.Now,Gender.Male)
				{
					StudentDetails = new StudentDetails
					{
						Address = new Address()
					},
				}
			};

			_studentRepository.Setup(x => x.FindByIncludeAsync(It.IsAny<Expression<Func<Student, bool>>>(),
				y => y.StudentDetails, z => z.StudentDetails.Address)).ReturnsAsync(mockResult);

			Task.Run(async () =>
			{
				await studentController.Students(searchLiteral);
				// Actual test code here.
			}).GetAwaiter().GetResult();

			_autoMapper.Verify(x => x.Map(It.IsAny<Student>(), It.IsAny<StudentDto>()), Times.Once);
		}

		[Fact]
		public void GetStudentsById_ShouldHitMappingAsExpected()
		{
			var studentController = new StudentsController(_studentRepository.Object,
				_autoMapper.Object, _studentLogger.Object, _dbContext.Object,
				_roleManager.Object, _userManager.Object, _configuration.Object);

			var searchLiteral = 12;

			var mockResult = new List<Student>()
			{
				new Student("test","hello",DateTime.Now,Gender.Male)
				{
					StudentId= 12,
					StudentDetails = new StudentDetails
					{
						Address = new Address()
					},
				}
			};

			_studentRepository.Setup(x => x.FindByIncludeAsync(It.IsAny<Expression<Func<Student, bool>>>(),
				y => y.StudentDetails, z => z.StudentDetails.Address)).ReturnsAsync(mockResult);

			Task.Run(async () =>
			{
				await studentController.Students(searchLiteral);
				// Actual test code here.
			}).GetAwaiter().GetResult();

			_autoMapper.Verify(x => x.Map(It.IsAny<Student>(), It.IsAny<StudentDto>()), Times.Once);
		}



		private Mock<UserManager<ApplicationUser>> GetUserManagerMock()
		{
			var mockUserManager = new Mock<UserManager<ApplicationUser>>(
				new Mock<IUserStore<ApplicationUser>>().Object,
				new Mock<IOptions<IdentityOptions>>().Object,
				new Mock<IPasswordHasher<ApplicationUser>>().Object,
				new IUserValidator<ApplicationUser>[0],
				new IPasswordValidator<ApplicationUser>[0],
				new Mock<ILookupNormalizer>().Object,
				new Mock<IdentityErrorDescriber>().Object,
				new Mock<IServiceProvider>().Object,
				new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

			return mockUserManager;
		}

		private Mock<RoleManager<IdentityRole>> GetRoleManagerMock()
		{
			var mockRoleManager = new Mock<RoleManager<IdentityRole>>(
				new Mock<IRoleStore<IdentityRole>>().Object,
				new IRoleValidator<IdentityRole>[0],
				new Mock<ILookupNormalizer>().Object,
				new Mock<IdentityErrorDescriber>().Object,
				new Mock<ILogger<RoleManager<IdentityRole>>>().Object);

			return mockRoleManager;
		}
	}
}
