using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Entities
{
    public class Course: IEntity
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
