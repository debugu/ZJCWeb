using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public partial class TeacherInfoBLL
    {
        public TeacherInfoModel CheckUserNameAndPassWord(string username,string password)
        {
            TeacherInfoModel m = new TeacherInfoDAL().Get(username);
            if (m.Password == password)
            {
                return m;
            }
            else {
                return null;
            }            
        }
    }
}
