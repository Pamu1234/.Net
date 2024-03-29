﻿using FluentApiPlayground.Core.Entities;
using FluentApiPlayground.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiPlayground.Infrastructure.Data
{

    public class CoursesContext:DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDb)\MSSQLLocalDB;Database=CourseDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }


    }
   
}
