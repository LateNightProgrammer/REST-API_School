using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SriSloka.Api.ActionFilters;
using SriSloka.Api.ValidationHelpers;
using SriSloka.Data;
using SriSloka.Model;
using SriSloka.SharedKernel;
using SriSloka.ViewModel;

namespace SriSloka.Api.Controllers
{
	/// <summary>
	/// Students related services.
	/// </summary>
	//[ServiceFilter(typeof(LogFilter))]
	[Produces("application/json")]
	public class StudentsController : BaseApiController
	{
		private readonly IRepository<Student> _studentRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<StudentsController> _logger;
		public StudentsController(IRepository<Student> studentRepository,
		  IMapper mapper, ILogger<StudentsController> logger,
		  SriSlokaDbContext context,
			RoleManager<IdentityRole> roleManager,
		  UserManager<ApplicationUser> userManager,
		  IConfiguration configuration)
		  : base(context, roleManager,  userManager, configuration)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
			_logger = logger;
		}

		/// <summary>
		/// Search students by their first or last name. 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/[controller]/{name}")]
		public async Task<IEnumerable<StudentDto>> Students(string name)
		{
			_logger.LogInformation("About to get all Students by name.");

			try
			{
				var students = await _studentRepository.FindByIncludeAsync
				(x => (x.Firstname.Contains(name) || x.Lastname.Contains(name)),
					x => x.StudentDetails, x => x.StudentDetails.Address);

				var studentDtos = new List<StudentDto>();

				foreach (var student in students)
				{
					var dto = new StudentDto();

					_mapper.Map(student, dto);

					_mapper.Map(student.StudentDetails, dto.StudentContactDetails);

					_mapper.Map(student.StudentDetails.Address, dto.AddressDetails);

					studentDtos.Add(dto);
				}

				return studentDtos;
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		/// <summary>
		/// Search students by their Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/[controller]/{id}")]
		public async Task<StudentDto> Students(int id)
		{
			_logger.LogInformation("About to get all Students by name.");

			try
			{
				var students = await _studentRepository.FindByIncludeAsync
				(x => (x.StudentId == id),
				  x => x.StudentDetails, x => x.StudentDetails.Address);

				var studentDtos = new List<StudentDto>();

				var student = students.FirstOrDefault();

				if (student == null)
				{
					return null;
				}

				var dto = new StudentDto();

				_mapper.Map(student, dto);

				_mapper.Map(student.StudentDetails, dto.StudentContactDetails);

				_mapper.Map(student.StudentDetails.Address, dto.AddressDetails);

				studentDtos.Add(dto);

				return dto;
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		/// <summary>
		/// Find student by date of birth. Date format(ISO8601)
		/// </summary>
		/// <param name="dob"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/[controller]/FindByDob")]
		public async Task<IEnumerable<StudentDto>> StudentsByDob(DateTime dob)
		{
			if (dob == DateTime.MinValue)
			{
				_logger.LogCritical($"Invalid Dob: {dob}");

				throw new ValidationException("Invalid object. Date of birth value is incorrect.");
			}

			_logger.LogInformation("About to get all Students by Dob.");

			try
			{
				var students = await _studentRepository.FindByIncludeAsync
				(x => x.DateOfBirth == dob,
					x => x.StudentDetails, x => x.StudentDetails.Address);

				var studentDtos = new List<StudentDto>();

				foreach (var student in students)
				{
					var dto = new StudentDto();

					_mapper.Map(student, dto);

					_mapper.Map(student.StudentDetails, dto.StudentContactDetails);

					_mapper.Map(student.StudentDetails.Address, dto.AddressDetails);

					studentDtos.Add(dto);
				}

				return studentDtos;
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		/// <summary>
		/// Get all students by their standard.
		/// </summary>
		/// <param name="standardId"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/[controller]/FindByStandard")]
		public async Task<IEnumerable<StudentDto>> StudentsByStandard(int standardId)
		{
			if (standardId == 0)
			{
				_logger.LogCritical($"Invalid standard id");

				throw new ValidationException("Invalid object. standard id value is incorrect.");
			}

			_logger.LogInformation("About to get all Students by Dob.");

			try
			{
				var students = await _studentRepository.FindByIncludeAsync
				(x => x.Enrollments.Any(y => y.StandardId == standardId && y.IsActive),
					x => x.Enrollments);

				var studentDtos = new List<StudentDto>();

				foreach (var student in students)
				{
					var dto = new StudentDto();

					_mapper.Map(student, dto);

					studentDtos.Add(dto);
				}

				return studentDtos;
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="studentDto"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("api/[controller]")]
		[ValidateModel]
		public async Task<IActionResult> Students([FromBody]StudentDto studentDto)
		{
			_logger.LogInformation("Called API to Create Student.");

			if (studentDto == null)
			{
				_logger.LogCritical("Student object can't be null. About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			try
			{
				_logger.LogInformation(studentDto.ToJson());

				var student = new Student(studentDto.Firstname, studentDto.Lastname, studentDto.DateOfBirth, studentDto.Sex);

				_mapper.Map(studentDto, student);
				_mapper.Map(studentDto.StudentContactDetails, student.StudentDetails);
				_mapper.Map(studentDto.AddressDetails, student.StudentDetails.Address);

				await _studentRepository.InsertAsync(student);
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}

			return Ok();
		}

		/// <summary>
		/// Only gets student entity related stuff.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("api/[controller]")]
		public async Task<IEnumerable<StudentDto>> StudentsAsync()
		{
			_logger.LogInformation("About to get all Students data.");

			var students = await _studentRepository.AllIncludeAsync(x => x.StudentDetails,
				x => x.StudentDetails.Address, x => x.Enrollments);

			var studentDtos = new List<StudentDto>();

			foreach (var student in students)
			{
				var dto = new StudentDto();

				_mapper.Map(student, dto);

				_mapper.Map(student.StudentDetails, dto.StudentContactDetails);

				_mapper.Map(student.StudentDetails.Address, dto.AddressDetails);

				studentDtos.Add(dto);
			}

			return studentDtos;
		}

		/// <summary>
		/// Todo: Not going to work. Incomplete..
		/// </summary>
		/// <returns></returns>
		//[HttpGet]
		//[Route("api/[controller]/All")]
		//public async Task<IEnumerable<Student>> GetAllAsync()
		//{
		//	_logger.LogInformation("About to get all Students data.");

		//	return await _studentRepository.AllIncludeAsync(x => x.AcadamicHistory,
		//		x => x.Enrollments, x => x.CareTakers, x => x.HomeworkSubmissions,
		//		x => x.Transport, x => x.Fees, x => x.StudentAttendance);
		//}

		[HttpPut]
		[Route("api/[controller]")]
		[ValidateModel]
		public async Task<IActionResult> StudentsUpdate([FromBody]StudentDto studentDto)
		{
			if (studentDto == null || studentDto.StudentId == 0)
			{
				_logger.LogCritical("Student object can't be null. About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation($"About to deactivate a student Id:{studentDto.StudentId}");

			if (!studentDto.IsActive && string.IsNullOrEmpty(studentDto.StudentContactDetails.ReasonForLeaving))
			{
				throw new ValidationException("You must mention the reason for the delete.");
			}

			var students = await _studentRepository.FindByIncludeAsync(x => x.StudentId == studentDto.StudentId,
				x => x.StudentDetails, x => x.StudentDetails.Address);

			var student = students.FirstOrDefault();
			if (student == null)
			{
				throw new ValidationException($"Not a valid student Id:{studentDto.StudentId}");
			}

			try
			{
				_mapper.Map(studentDto, student);
				_mapper.Map(studentDto.AddressDetails, student.StudentDetails.Address);
				_mapper.Map(studentDto.StudentContactDetails, student.StudentDetails);

				student.StudentDetails.ObjectState = ObjectState.Modified;
				student.StudentDetails.Address.ObjectState = ObjectState.Modified;

				await _studentRepository.UpdateAsync(student);
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}

			return Ok();
		}

		[HttpPut]
		[Route("api/[controller]/Delete")]
		[ValidateModel]
		public async Task<IActionResult> Delete(StudentDto studentDto)
		{
			if (studentDto == null)
			{
				_logger.LogCritical("Student object can't be null. About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation($"About to deactivate a student Id:{studentDto.StudentId}");

			studentDto.IsActive = false;

			if (string.IsNullOrEmpty(studentDto.StudentContactDetails.ReasonForLeaving))
			{
				throw new ValidationException("You must mention the reason for the delete.");
			}

			try
			{
				var student = _studentRepository.FindByKey(studentDto.StudentId);

				_mapper.Map(studentDto, student);

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}


		#region Enrollments
		[HttpGet]
		[Route("api/[controller]/{studentId}/Enrollments")]
		public async Task<List<StudentsEnrollmentsDto>> Enrollments(int studentId)
		{
			_logger.LogInformation("About to get all Students data.");

			var students = await _studentRepository
				.FindByIncludeAsync(x => x.StudentId == studentId, x => x.Enrollments);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				_logger.LogWarning($"Invalid student Id: {studentId}");

				throw new ValidationException($"Invalid student Id: {studentId}");
			}

			var studentsEnrollmentsDtos = new List<StudentsEnrollmentsDto>();

			foreach (var enrollment in student.Enrollments)
			{
				var dto = new StudentsEnrollmentsDto();

				_mapper.Map(enrollment, dto);

				studentsEnrollmentsDtos.Add(dto);
			}

			return studentsEnrollmentsDtos;
		}

		[HttpPost]
		[Route("api/[controller]/{studentId}/Enrollments")]
		[ValidateModel]
		public async Task<IActionResult> Enrollments(int studentId, [FromBody]StudentsEnrollmentsDto studentEnrollmentDto)
		{
			_logger.LogInformation("Called API to Create Student Enrollment.");

			if (studentEnrollmentDto == null)
			{
				_logger.LogCritical("Student Enrollment object can't be null. About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation(studentEnrollmentDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == studentId, x => x.Enrollments);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			if (studentEnrollmentDto.StandardId == 0)
			{
				throw new ValidationException("Invalid StandardId. Student object can't be null");
			}

			try
			{

				if (studentEnrollmentDto.EnrollmentsId == 0)
				{
					var enrollment = new Enrollments(studentEnrollmentDto.StandardId)
					{
						ObjectState = ObjectState.Added
					};

					_mapper.Map(studentEnrollmentDto, enrollment);

					// Create/update a new enrollment.
					student.Enrollments.Add(enrollment);
				}

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}


		[HttpPut]
		[Route("api/[controller]/{studentId}/Enrollments")]
		[ValidateModel]
		public async Task<IActionResult> Enrollments([FromBody]StudentsEnrollmentsDto studentEnrollmentDto)
		{
			_logger.LogInformation("Called API to Create Student Enrollment.");

			if (studentEnrollmentDto == null)
			{
				_logger.LogCritical("Student Enrollment object can't be null. About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation(studentEnrollmentDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == studentEnrollmentDto.StudentId, x => x.Enrollments);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			if (studentEnrollmentDto.StandardId == 0)
			{
				throw new ValidationException("Invalid StandardId. Student object can't be null");
			}

			try
			{
				var enrollment =
					student.Enrollments
						.First(x => x.EnrollmentsId == studentEnrollmentDto.EnrollmentsId);

				_mapper.Map(studentEnrollmentDto, enrollment);

				enrollment.ObjectState = ObjectState.Modified;

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}
		#endregion

		#region Attandance

		[HttpGet]
		[Route("api/[controller]/{studentId}/Attendance/{from}/{to}")]
		public async Task<List<AttendanceDto>> Attendance(int studentId, DateTime from, DateTime? to)
		{
			_logger.LogInformation("About to get all Students data.");

			var students = await _studentRepository
				.FindByIncludeAsync(x => x.StudentId == studentId && x.IsActive, x => x.StudentAttendance);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				_logger.LogWarning($"Invalid student Id: {studentId}");

				throw new ValidationException($"Invalid student Id: {studentId}");
			}

			var studentAttendance = new List<AttendanceDto>();

			var availableAttendance = (to == null)
				? student.StudentAttendance.Where(x => x.Date >= from)
				: student.StudentAttendance.Where(x => x.Date >= from && x.Date <= to);

			foreach (var attendance in availableAttendance)
			{
				var dto = new AttendanceDto();

				_mapper.Map(attendance, dto);

				studentAttendance.Add(dto);
			}

			return studentAttendance;
		}

		[HttpPost]
		[Route("api/[controller]/{studentId}/attendance")]
		[ValidateModel]
		public async Task<IActionResult> Attendance(int studentId, [FromBody]AttendanceDto attendanceDto)
		{
			_logger.LogInformation("Called API to Create Student attendance.");

			if (attendanceDto == null)
			{
				_logger.LogCritical("Student attendance object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Attendance object can't be null");
			}

			_logger.LogInformation(attendanceDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == studentId,
				x => x.StudentAttendance);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var attandance = new Attendance()
				{
					ObjectState = ObjectState.Added,
					StudentId = studentId
				};

				_mapper.Map(attendanceDto, attandance);

				// Create/update a new enrollment.
				student.StudentAttendance.Add(attandance);

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		[HttpPut]
		[Route("api/[controller]/{studentId}/Attendance")]
		[ValidateModel]
		public async Task<IActionResult> Attendance([FromBody]AttendanceDto attendanceDto)
		{
			_logger.LogInformation("Called API to Create Student attendance");

			if (attendanceDto == null)
			{
				_logger.LogCritical("Student attendance object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation(attendanceDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == attendanceDto.StudentId,
				x => x.StudentAttendance);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var attendance =
					student.StudentAttendance
						.First(x => x.AttendanceId == attendanceDto.AttendanceId);

				_mapper.Map(attendanceDto, attendance);

				attendance.ObjectState = ObjectState.Modified;

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController, Update Attendance", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		#endregion

		#region CareTakers
		[HttpGet]
		[Route("api/[controller]/{studentId}/CareTakers")]
		public async Task<List<AuthorisedCareTakersDto>> CareTakers(int studentId)
		{
			_logger.LogInformation($"About to get all Student's {studentId} CareTakers data.");

			var students = await _studentRepository
				.FindByIncludeAsync(x => x.StudentId == studentId && x.IsActive, x => x.CareTakers);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				_logger.LogWarning($"Invalid student Id: {studentId}");

				throw new ValidationException($"Invalid student Id: {studentId}");
			}

			var careTakers = new List<AuthorisedCareTakersDto>();

			foreach (var careTaker in student.CareTakers)
			{
				var dto = new AuthorisedCareTakersDto();

				_mapper.Map(careTaker, dto);

				careTakers.Add(dto);
			}

			return careTakers;
		}

		[HttpPost]
		[Route("api/[controller]/{studentId}/CareTakers")]
		[ValidateModel]
		public async Task<IActionResult> CareTakers(int studentId, [FromBody]AuthorisedCareTakersDto careTakersDto)
		{
			_logger.LogInformation("Called API to Create Student caretakers.");

			if (careTakersDto == null)
			{
				_logger.LogCritical("Student caretakers object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. CareTakers object can't be null");
			}

			_logger.LogInformation(careTakersDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == studentId,
					x => x.CareTakers);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var careTaker = new AuthorisedCareTakers(studentId)
				{
					ObjectState = ObjectState.Added
				};

				_mapper.Map(careTakersDto, careTaker);

				// Create/update a new enrollment.
				student.CareTakers.Add(careTaker);

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}


		[HttpPut]
		[Route("api/[controller]/{studentId}/CareTakers")]
		[ValidateModel]
		public async Task<IActionResult> CareTakers([FromBody]AuthorisedCareTakersDto careTakersDto)
		{
			_logger.LogInformation("Called API to Create Student careTakers");

			if (careTakersDto == null)
			{
				_logger.LogCritical("Student's CareTakers object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation(careTakersDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == careTakersDto.StudentId,
					x => x.CareTakers);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var careTaker =
					student.CareTakers
						.First(x => x.AuthorisedCareTakersId == careTakersDto.AuthorisedCareTakersId);

				_mapper.Map(careTakersDto, careTaker);

				careTaker.ObjectState = ObjectState.Modified;

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController, Update CareTakers", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		#endregion

		#region HomeworkSubmissions
		//Todo: It would be great if we limit the homework by date
		[HttpGet]
		[Route("api/[controller]/{studentId}/HomeworkSubmissions")]
		public async Task<List<HomeworkSubmissionDto>> HomeworkSubmissions(int studentId)
		{
			_logger.LogInformation($"About to get all Student's {studentId} HomeworkSubmissions data.");

			var students = await _studentRepository
				.FindByIncludeAsync(x => x.StudentId == studentId && x.IsActive, x => x.HomeworkSubmissions);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				_logger.LogWarning($"Invalid student Id: {studentId}");

				throw new ValidationException($"Invalid student Id: {studentId}");
			}

			var homeworkSubmissionsDto = new List<HomeworkSubmissionDto>();

			foreach (var homework in student.HomeworkSubmissions)
			{
				var dto = new HomeworkSubmissionDto();

				_mapper.Map(homework, dto);

				homeworkSubmissionsDto.Add(dto);
			}

			return homeworkSubmissionsDto;
		}

		[HttpPost]
		[Route("api/[controller]/{studentId}/HomeworkSubmissions")]
		[ValidateModel]
		public async Task<IActionResult> HomeworkSubmissions(int studentId, [FromBody]HomeworkSubmissionDto homeworksDto)
		{
			_logger.LogInformation("Called API to Create Student homeworks.");

			if (homeworksDto == null)
			{
				_logger.LogCritical("Student homeworks object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Homeworks object can't be null");
			}

			_logger.LogInformation(homeworksDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == studentId,
					x => x.HomeworkSubmissions);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var homeworkSubmission = new HomeworkSubmission(studentId)
				{
					ObjectState = ObjectState.Added
				};

				_mapper.Map(homeworksDto, homeworkSubmission);

				// Create/update a new enrollment.
				student.HomeworkSubmissions.Add(homeworkSubmission);

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		[HttpPut]
		[Route("api/[controller]/{studentId}/HomeworkSubmissions")]
		[ValidateModel]
		public async Task<IActionResult> HomeworkSubmissions([FromBody]HomeworkSubmissionDto homeworkSubmissionsDto)
		{
			_logger.LogInformation("Called API to Create Student homework submissions");

			if (homeworkSubmissionsDto == null)
			{
				_logger.LogCritical("Student's homeworksDto object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation(homeworkSubmissionsDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == homeworkSubmissionsDto.StudentId,
					x => x.HomeworkSubmissions);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var homeworkSubmission =
					student.HomeworkSubmissions
						.First(x => x.HomeworkId == homeworkSubmissionsDto.HomeworkId);

				_mapper.Map(homeworkSubmissionsDto, homeworkSubmission);

				homeworkSubmission.ObjectState = ObjectState.Modified;

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController, Update HomeworkSubmission", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}

		#endregion

		#region Transport
		[HttpGet]
		[Route("api/[controller]/{studentId}/Transport")]
		public async Task<List<TransportDto>> Transport(int studentId)
		{
			_logger.LogInformation($"About to get all Student's {studentId} Transport data.");

			var students = await _studentRepository
				.FindByIncludeAsync(x => x.StudentId == studentId && x.IsActive, x => x.Transport);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				_logger.LogWarning($"Invalid student Id: {studentId}");

				throw new ValidationException($"Invalid student Id: {studentId}");
			}

			var transportDto = new List<TransportDto>();

			foreach (var transport in student.Transport)
			{
				var dto = new TransportDto();

				_mapper.Map(transport, dto);

				transportDto.Add(dto);
			}

			return transportDto;
		}


		[HttpPost]
		[Route("api/[controller]/{studentId}/Transport")]
		[ValidateModel]
		public async Task<IActionResult> Transport(int studentId, [FromBody]TransportDto transportDto)
		{
			_logger.LogInformation("Called API to Create Student transport.");

			if (transportDto == null)
			{
				_logger.LogCritical("Student transport object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Transport object can't be null");
			}

			_logger.LogInformation(transportDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == studentId,
					x => x.Transport);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var transport = new Transport(studentId)
				{
					ObjectState = ObjectState.Added,
					StudentId = studentId
				};

				_mapper.Map(transportDto, transport);

				// Create/update a new enrollment.
				student.Transport.Add(transport);

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}


		[HttpPut]
		[Route("api/[controller]/{studentId}/Transport")]
		[ValidateModel]
		public async Task<IActionResult> Transport([FromBody]TransportDto transportDto)
		{
			_logger.LogInformation("Called API to Create Student transport");

			if (transportDto == null)
			{
				_logger.LogCritical("Student's transportDto object can't be null. " +
									"About to throw validation exception.");

				throw new ValidationException("Invalid object. Student object can't be null");
			}

			_logger.LogInformation(transportDto.ToJson());

			var students = await
				_studentRepository.FindByIncludeAsync(x => x.StudentId == transportDto.StudentId,
					x => x.Transport);

			var student = students.FirstOrDefault();

			if (student == null)
			{
				throw new ValidationException("Invalid studentId. Student object can't be null");
			}
			try
			{
				var transport =
					student.Transport
						.First(x => x.TransportId == transportDto.TransportId);

				_mapper.Map(transportDto, transport);

				transport.ObjectState = ObjectState.Modified;

				await _studentRepository.UpdateAsync(student);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError("StudentController, Update transport", ex);

				throw new InvalidOperationException(ex.Message);
			}
		}
		#endregion
	}
}
