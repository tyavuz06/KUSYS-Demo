using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Common.DTO
{
    public class StudentDTO
    {
        public StudentDTO() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int MyProperty { get; set; }
    }
}
