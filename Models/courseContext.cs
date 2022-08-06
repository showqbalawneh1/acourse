using System;
using Microsoft.EntityFrameworkCore;

namespace Acourse.Models
{
    public class courseContext : DbContext
    {
        public courseContext(DbContextOptions<courseContext> options)
           : base(options)
        { }
        public DbSet<course> courses { get; set; }
        public DbSet<field> fields { get; set; }
        public DbSet<user> uesrs  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>().HasData(
                new course
                {
                    courseId = 1,
                    cname = "c++",
                    describtion = "this is a good course",
                    fieldId = 1
                },
                 new course
                 {
                     courseId = 2,
                     cname = "java",
                     describtion = "this is a good course java",
                     fieldId = 1
                 },
                  new course
                  {
                      courseId = 3,
                      cname = "physics",
                      describtion = "this is a good course",
                      fieldId = 2
                  },
                  new course
                  {
                      courseId = 4,
                      cname = "dental lab",
                      describtion = "this is a good course",
                      fieldId = 3
                  }
            ); modelBuilder.Entity<user>().HasData(
                new user
                {
                    userId = 1,
                    uname = "showq",
                    password = "123",
                    email = "showq@hotmail"
                },
                 new user
                 {
                     userId = 2,
                     uname = "suha",
                     password = "123",
                     email = "suha@hotmail"
                 }
            );
            modelBuilder.Entity<field>().HasData(
                new field { fieldId = 2, fname = "scienes" , description = "scienes fields" },
                new field { fieldId = 1, fname = "it" , description = "it fields" },
                new field { fieldId = 3, fname = "medicin" , description = "medicin fields" }
            );
        }
    }
}

