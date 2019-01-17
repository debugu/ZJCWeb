using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public partial class StuRelationshipBLL
    {
        /// <summary>
        /// 根据学生身份证号码从监护人列表中删除学生的监护人
        /// </summary>
        /// <param name="CardId"></param>
        /// <returns></returns>
        public int DeleteByCarId(string CardId)
        {
            return new StuRelationshipDAL().Delete(CardId);
        }

        public IEnumerable<StuJHInfoModel> GetStuJHInfoModel()
        {
            return new StuRelationshipDAL().GetStuJHInfoModel();
        }
    }
}