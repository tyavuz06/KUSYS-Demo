using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Entities
{
    public class Student
    {
        public Student()
        {
            Course = new HashSet<Course>();
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdentityNo { get; set; }

        public ICollection<Course> Course { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
