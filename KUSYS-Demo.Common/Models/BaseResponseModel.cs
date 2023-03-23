using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Common.Models
{
    public class BaseResponseModel
    {
        public BaseResponseModel() {}

        public int Code { get; set; }
        public string Message { get; set; }


        public void SetCode(SystemConstans.CODES code)
        {
            this.Code = (int)code;
            this.Message = SystemConstans.ERROR_MESSAGE.FirstOrDefault(t => t.Key == (int)code).Value;
        }
    }
}
