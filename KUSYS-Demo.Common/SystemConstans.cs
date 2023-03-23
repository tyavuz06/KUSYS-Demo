using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Common
{
    public class SystemConstans
    {
        public enum CODES
        {
            SUCCESS = 1,
            SYSTEMERROR = 2,
            NOTFOUND = 3
        }

        public static Dictionary<int, string> ERROR_MESSAGE = new Dictionary<int, string>
        {
            {1,"İşlem başarılı" },
            {2,"Sistem Hatası" },
            {3,"Kullanıcı Bulunamadı" }
        };
    }
}
