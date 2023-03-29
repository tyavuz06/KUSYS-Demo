using KUSYS_Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Data
{
    public class DBInitializer
    {
        public DBInitializer()
        {
            var context = new KUSYSContext();

            if (context.Database.EnsureDeleted())
            {
                context.Courses.AddRange(SeedCourses());
                context.Students.AddRange(SeedStudents());
                context.Database.Migrate();
                context.SaveChanges();
               
                context.StudentCourses.AddRange(SeedSelectedCourses());
                context.SaveChanges();
                
            }
        }

        private List<Course> SeedCourses()
        {
            var list = new List<Course>();
            list.AddRange(new List<Course>() {
                new Course() { Name = "Introduction to Computer Science" } ,
                new Course() { Name = "Algorithms" },
                new Course() { Name = "Calculus" },
                new Course() { Name = "Physics" }
            });

            return list;
        }

        private List<Student> SeedStudents()
        {
            var list = new List<Student>();
            list.AddRange(new List<Student>() {
                new Student() { Name = "TURGUT YAVUZ", SurName = "ÜNLÜ", IdentityNo = "11122233344",  BirthDate = new DateTime()}
            });

            return list;
        }

        private List<StudentCourse> SeedSelectedCourses()
        {
            var list = new List<StudentCourse>();
            list.AddRange(new List<StudentCourse>() {
                new StudentCourse() { CourseId = 1, StudentId = 1},
                new StudentCourse() { CourseId = 3, StudentId = 1},
                new StudentCourse() { CourseId = 4, StudentId = 1}
            });

            return list;
        }
    }
}
