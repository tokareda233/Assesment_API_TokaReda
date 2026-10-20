using Assesment_API_TokaReda.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_API_TokaReda.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Application> applications { get; set; }
        public DbSet<CandidateProfile> candidateProfiles { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(c => c.Email).IsUnique();

            modelBuilder.Entity<Application>()
                .HasIndex(c => new { c.JobId, c.CandidateProfileId }).IsUnique();

            modelBuilder.Entity<User>()
               .HasOne(c => c.CandidateProfile)
               .WithOne(c => c.Candidate)
               .HasForeignKey<CandidateProfile>(c => c.CadidateId);

            modelBuilder.Entity<User>()
                .HasMany(c => c.companies)
                .WithOne(c => c.Employer)
                .HasForeignKey(c => c.EmployerId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<CandidateProfile>()
                .HasMany(c => c.Applications)
                .WithOne(c => c.CandidateProfile)
                .HasForeignKey(c => c.CandidateProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Job>()
               .HasMany(c => c.Applications)
               .WithOne(c => c.Job)
               .HasForeignKey(c => c.JobId)
               .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FullName="Ahmed Hassan",
                    Email="ahmed@gmail.com",
                    Password="123456",
                    Role="Candidate",
                    CreatedAt=new DateTime(2026-09-01)
                    
                    
                },
                 new User
                 {
                     Id = 2,
                     FullName = "Mona Hassan",
                     Email = "mona@gmail.com",
                     Password = "123456",
                     Role = "Candidate",
                     CreatedAt = new DateTime(2026 - 08 - 01)


                 }
                 , new User
                 {
                     Id = 3,
                     FullName = "Sara Hassan",
                     Email = "sara@gmail.com",
                     Password = "123456",
                     Role = "Employer",
                     CreatedAt = new DateTime(2026 - 09 - 02)


                 },
                  new User
                  {
                      Id = 4,
                      FullName = "Omer Hassan",
                      Email = "omer@gmail.com",
                      Password = "123456",
                      Role = "Admin",
                      CreatedAt = new DateTime(2026 - 09 - 03)


                  }

                );

            modelBuilder.Entity<CandidateProfile>()
                .HasData(
                new CandidateProfile
                {
                    Id=1,
                    Phone="01120099839",
                    ResumeURL="example.com/resume1",
                    Skill="ASP.Net Core",
                    YearsOfExperience=3,
                    CadidateId=1
                },
                 new CandidateProfile
                 {
                     Id = 2,
                     Phone = "01120099839",
                     ResumeURL = "example.com/resume2",
                     Skill = "Java",
                     YearsOfExperience = 2,
                     CadidateId = 2
                 }

                );

            modelBuilder.Entity<Company>()
                .HasData(
                new Company
                {
                    Id=1,
                    Name="Tech Solution",
                    Description="wertyuiop",
                    Website= "https:/techsolution.exapmlr.com",
                    Location="Cairo",
                    EmployerId=3

                },
                 new Company
                 {
                     Id = 2,
                     Name = "Future systemd",
                     Description = "wertghjkyuiop",
                     Website = "https:/futureSystems.exapmle.com",
                     Location = "Giza",
                     EmployerId = 3

                 }

                );


            modelBuilder.Entity<Job>()
                .HasData(
                new Job
                {
                    Id=1,
                    Title="back",
                    Description="wertyuiopdfghjkl",
                    Salary=30000,
                    Location="Cairo",
                    EmploymentType="FullTime",
                    PostedDate=new DateTime(2026-10-01),
                    Deadline=new DateTime(2026-11-01),
                    Status="Open",
                    CompanyId=1,

                },

                new Job
                {
                    Id = 2,
                    Title = "front",
                    Description = "wertyuiopdfghjkl",
                    Salary = 25000,
                    Location = "Giza",
                    EmploymentType = "Contract",
                    PostedDate = new DateTime(2026 - 10 - 02),
                    Deadline = new DateTime(2026 - 11 - 02),
                    Status = "Open",
                    CompanyId = 2,

                }

                );

            modelBuilder.Entity<Application>()
                .HasData(
                new Application
                {
                    Id=1,
                    ApplicationDate=new DateTime(2026-10-05),
                    Status="Pending",
                    CoverLetter="asdfghjklsdfghj",
                    CandidateProfileId=1,
                    JobId=1,
                },
                 new Application
                 {
                     Id = 2,
                     ApplicationDate = new DateTime(2026 - 10 - 02),
                     Status = "UnderReview",
                     CoverLetter = "asdfghjklsdfghj",
                     CandidateProfileId = 2,
                     JobId = 2,
                 }
                );


        }



    }
}
