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
    }
}
