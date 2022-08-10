using FluentApiPlayground.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluentApiPlayground.Infrastructure.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(c => c.Title).HasColumnName("CourseName");
            modelBuilder.Entity<Student>().Property(a => a.FirstMidName).HasColumnName("FirstName");
            modelBuilder.Entity<Course>().ToTable("Course", schema: "CourseData");

            modelBuilder.Entity<Student>().HasData(new Student
            {
                ID = 1,
                LastName = "Sawrate",
                FirstMidName = "Parmeshwar",
                EnrollmentDate = new DateTime()
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                ID = 2,
                LastName = "Patil",
                FirstMidName = "Sandwiskj",
                EnrollmentDate = new DateTime()
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseID = 111,
                Title = "C#.Net",
                Credits = 3
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                ID = 3,
                LastName = "Pande",
                FirstMidName = "fjhgsjdn",
                EnrollmentDate = new DateTime()
            });

        }
    }
}
