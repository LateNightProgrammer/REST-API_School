using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SriSloka.Data.Mapping;
using SriSloka.Model;

namespace SriSloka.Data
{
  public class SriSlokaDbContext : IdentityDbContext<ApplicationUser>
  {
    public SriSlokaDbContext(DbContextOptions<SriSlokaDbContext> options)
        : base(options)
    {
    }

    public DbSet<AcadamicHistory> AcadamicHistory { get; set; }
    public DbSet<AchievementsCategory> AchievementsCategory { get; set; }
    public DbSet<Achievements> Achievements { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<AuthorisedCareTakers> AuthorisedCareTakers { get; set; }
    public DbSet<Enrollments> Enrollments { get; set; }
    public DbSet<Exam> Exam { get; set; }
    public DbSet<ExamCategory> ExamCategory { get; set; }
    public DbSet<ExamResults> ExamResults { get; set; }
    public DbSet<Expenses> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
    public DbSet<Fee> Fee { get; set; }
    public DbSet<Homework> Homework { get; set; }
    public DbSet<Liabilities> Liabilities { get; set; }
    public DbSet<Observations> Observations { get; set; }
    public DbSet<Transport> PublicTransport { get; set; }
    public DbSet<Salary> Salary { get; set; }
    public DbSet<Schedule> Schedule { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Standard> Standard { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<TeacherClass> TeacherClass { get; set; }
    public DbSet<Terms> Terms { get; set; }

    public DbSet<Token> Tokens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.AddConfiguration(new AcadamicHistoryDbMap());
      builder.AddConfiguration(new AchievementsDbMap());
      builder.AddConfiguration(new AchievementsCategoryDbMap());
      builder.AddConfiguration(new AddressDbMap());
      builder.AddConfiguration(new AttendanceDbMap());
      builder.AddConfiguration(new AuthorisedCareTakersDbMap());
      builder.AddConfiguration(new ApplicationUserDbMap());
      builder.AddConfiguration(new EnrollmentsDbMap());
      builder.AddConfiguration(new ExamDbMap());
      builder.AddConfiguration(new ExamCategoryDbMap());
      builder.AddConfiguration(new ExamResultsDbMap());
      builder.AddConfiguration(new ExpensesDbMap());
      builder.AddConfiguration(new FeeDbMap());
      builder.AddConfiguration(new HomeworkDbMap());
      builder.AddConfiguration(new LiabilitiesDbMap());
      builder.AddConfiguration(new ObservationsDbMap());
      builder.AddConfiguration(new PhotosDbMap());
      builder.AddConfiguration(new TransportDbMap());
      builder.AddConfiguration(new SalaryDbMap());
      builder.AddConfiguration(new ScheduleDbMap());
      builder.AddConfiguration(new StaffDbMap());
      builder.AddConfiguration(new StandardDbMap());
      builder.AddConfiguration(new TeacherDbMap());
      builder.AddConfiguration(new TermsDbMap());
      builder.AddConfiguration(new TraitsDbMap());
      builder.AddConfiguration(new StudentDbMap());
      builder.AddConfiguration(new StudentDetailsDbMap());
      builder.AddConfiguration(new SubjectDbMap());

      builder.AddConfiguration(new LogDbMap());

      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }
  }
}
