using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class GuessResultDAL
    {
        public IEnumerable<GuessResultModel> GetAll(int lun)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from GuessResult where Lun=@Lun order by GuessNumber",
                new SqlParameter("Lun", lun));
            List<GuessResultModel> list = new List<GuessResultModel>();
            foreach (DataRow row in dt.Rows)
            {
                GuessResultModel model = new GuessResultModel();
                model.id = (int)row["id"];
                model.StuName = (string)row["StuName"];
                model.IP = (string)GetNull(row["IP"]);
                model.Lun = (int)row["Lun"];
                model.GuessPath = (string)row["GuessPath"];
                model.GuessNumber = (int)row["GuessNumber"];
                model.Remark = (string)GetNull(row["Remark"]);
                list.Add(model);
            }
            return list;
        }
    }
}
