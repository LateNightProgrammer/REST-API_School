using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SriSloka.Data;
using SriSloka.Model;

namespace SriSloka.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Teacher")]
	public class TeacherController : BaseApiController
	{
		private readonly IRepository<Teacher> _teacherRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<TeacherController> _logger;

		public TeacherController(IRepository<Teacher> teacherRepository,
		  IMapper mapper, ILogger<TeacherController> logger, SriSlokaDbContext context,
			RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
		  IConfiguration configuration)
		  : base(context, roleManager, userManager, configuration)
		{
			_teacherRepository = teacherRepository;
			_mapper = mapper;
			_logger = logger;
		}

		// Get Schedule for month

		// Get Today's schedule 

		// Classes grouped by subjects

		// ClassTeacher-- Students

		// Update Exams and marks

		// Update Remarks and achievements for students
	}
}
