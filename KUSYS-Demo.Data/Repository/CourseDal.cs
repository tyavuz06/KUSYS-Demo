using KUSYS_Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repository
{
    public class CourseDal: RepositoryBase<Course, KUSYSContext>, ICourseDal
    {
    }
}
