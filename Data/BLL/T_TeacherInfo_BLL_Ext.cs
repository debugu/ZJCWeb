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
        public TeacherInfoModel CheckUserNameAndPassWord(string username, string password)
        {
            TeacherInfoModel m = new TeacherInfoDAL().Get(username);
            if (m.Password == password)
            {
                return m;
            }
            else
            {
                return null;
            }
        }
        public TeacherInfoModel Get(string UserName)
        {
            return new TeacherInfoDAL().Get(UserName);
        }

        public string GetClassIdByTeaName(string UserName)
        {
            return new ClassBLL().GetByTeaID(new TeacherInfoDAL().Get(UserName).id).id.ToString();
        }
    }
}
