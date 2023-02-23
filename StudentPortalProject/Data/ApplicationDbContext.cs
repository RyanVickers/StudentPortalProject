using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Models;

namespace StudentPortalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public DbSet<LectureFile> LectureFiles { get; set; }
        public DbSet<AssignmentFile> AssignmentFiles { get; set; }
        public DbSet<SubmissionFile> SubmissionFiles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //Create roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id="1", Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole {Id="2", Name = "Teacher", NormalizedName = "TEACHER" },
                new IdentityRole {Id="3", Name = "Admin", NormalizedName = "ADMIN" }
            );

            //Create test users
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "student@test.com",
                    NormalizedUserName = "STUDENT@TEST.COM",
                    Email = "student@test.com",
                    NormalizedEmail = "STUDENT@TEST.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Test#1"),
                    FirstName = "Student",
                    LastName = "User"

                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "teacher@test.com",
                    NormalizedUserName = "TEACHER@TEST.COM",
                    Email = "teacher@test.com",
                    NormalizedEmail = "TEACHER@TEST.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Test#1"),
                    FirstName = "Teacher",
                    LastName = "User"
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Test#1"),
                    FirstName = "Admin",
                    LastName = "User"
                }
            );

            //Assign roles to user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "3", RoleId = "3" }
            );

            //Add Enrollment table
            modelBuilder.Entity<Enrollment>()
               .HasKey(x => new { x.CourseId, x.StudentId });

            modelBuilder.Entity<ApplicationUser>()
                        .HasMany(x => x.EnrolledCourses)
                        .WithMany(x => x.Students)
                        .UsingEntity<Enrollment>(x =>
                        {
                            x.ToTable("Enrollments");
                            x.HasKey(ct => new { ct.CourseId, ct.StudentId });
                        });

            modelBuilder.Entity<Course>()
              .HasOne(x => x.Teacher)
              .WithMany()
              .HasForeignKey(x => x.TeacherId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupMember>()
               .HasKey(x => new { x.GroupId, x.StudentId });

        }
        public DbSet<StudentPortalProject.Models.Assignment> Assignment { get; set; }
        public DbSet<StudentPortalProject.Models.Announcement> Announcement { get; set; }
    }
}