using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public partial class StudentInfoBLL
    {
        public string GetNameByStuId(string id)
        {
            StudentInfoModel m = new StudentInfoDAL().GetByCrdId(id);
            if (m == null)
            {
                return null;
            }
            else {
                return m.Name;
            }
        }

        public StudentInfoModel GetByStuCardId(string id)
        {
            return new StudentInfoDAL().GetByCrdId(id);
        }

        public string GetIdByStuId(string id)
        {
            StudentInfoModel m = new StudentInfoDAL().GetByCrdId(id);
            if (m == null)
            {
                return null;
            }
            else
            {
                return m.id.ToString();
            }
        }
    }
}
