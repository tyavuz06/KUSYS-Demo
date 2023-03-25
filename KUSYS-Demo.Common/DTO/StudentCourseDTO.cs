using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Common.DTO
{
    public class StudentCourseDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
    }
}
