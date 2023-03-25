using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Entities
{
    public class Student: IEntity
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }

        [MaxLength(11), MinLength(11)]
        public string IdentityNo { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
