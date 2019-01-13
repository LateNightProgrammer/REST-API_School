using AutoMapper;
using SriSloka.Model;
using SriSloka.ViewModel;

namespace SriSloka.Api.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();

            CreateMap<StudentContactDetailsDto, StudentDetails>();
            CreateMap<StudentDetails, StudentContactDetailsDto>();

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            CreateMap<StudentsEnrollmentsDto, Enrollments>();
            CreateMap<Enrollments, StudentsEnrollmentsDto>();

            CreateMap<StandardDto, Standard>();
            CreateMap<Standard, StandardDto>();

            CreateMap<SubjectDto, Subject>();
            CreateMap<Subject, SubjectDto>();

            CreateMap<TraitsDto, Traits>();
            CreateMap<Traits, TraitsDto>();

            CreateMap<AttendanceDto, Attendance>();
            CreateMap<Attendance, AttendanceDto>();

            CreateMap<AuthorisedCareTakersDto, AuthorisedCareTakers>();
            CreateMap<AuthorisedCareTakers, AuthorisedCareTakersDto>();

            CreateMap<HomeworkSubmissionDto, HomeworkSubmission>();
            CreateMap<HomeworkSubmission, HomeworkSubmissionDto>();

            CreateMap<TransportDto, Transport>();
            CreateMap<Transport, TransportDto>();

            CreateMap<StaffDto, Staff>();
            CreateMap<Staff, StaffDto>();

        }
    }
}
