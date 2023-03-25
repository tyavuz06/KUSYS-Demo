using KUSYS_Demo.Data.Entities;
using KUSYS_Demo.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repository.Core
{
    public class StudentCourseDal : RepositoryBase<StudentCourse, KUSYSContext>, IStudentCourseDal
    {
    }
}
