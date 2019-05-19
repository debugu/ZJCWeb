using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Data
{
    partial class StuRelationshipDAL
    {
        /// <summary>
        /// 根据学生身份证号码从监护人列表中删除学生的监护人
        /// </summary>
        /// <param name="CardId"></param>
        /// <returns></returns>
        public int Delete(string CardId)
        {
            Guid id= new StudentInfoDAL().GetByCrdId(CardId).id;
            return SqlHelper.ExecuteNonQuery("delete from T_StuRelationship where StuId=@id",
                new MySqlParameter("id", id));
        }

        public IEnumerable<StuJHInfoModel> GetStuJHInfoModel()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("SELECT s.`Name`,s.UserName,s.IDCardNO as StuCardID,r.XCall,r.XName,r.IDCardNO,r.Tel from T_StuRelationship as r LEFT JOIN T_StudentInfo as s on r.StuId=s.id");
            List<StuJHInfoModel> list = new List<StuJHInfoModel>();
            foreach (DataRow row in dt.Rows)
            {
                StuJHInfoModel model = new StuJHInfoModel();
                model.XCall = (string)GetNull(row["XCall"]);
                model.XName = (string)GetNull(row["XName"]);
                model.IDCardNO = (string)GetNull(row["IDCardNO"]);
                model.StuCardID = (string)GetNull(row["StuCardID"]);
                model.StuClass = (string)GetNull(row["UserName"]);
                model.StuName = (string)GetNull(row["Name"]);
                model.Tel = (string)GetNull(row["Tel"]);
                list.Add(model);
            }
            return list;
        }

        public IEnumerable<StuRelationshipModel> GetRelationsById(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuRelationship where StuId=@StuId",
                new MySqlParameter("StuId", id));
            List<StuRelationshipModel> list = new List<StuRelationshipModel>();
            foreach (DataRow row in dt.Rows)
            {
                StuRelationshipModel model = new StuRelationshipModel();
                model.id = new Guid(row["id"].ToString());
                model.StuId = new Guid(row["StuId"].ToString());
                model.XCall = (string)GetNull(row["XCall"]);
                model.XName = (string)GetNull(row["XName"]);
                model.IDCardNO = (string)GetNull(row["IDCardNO"]);
                model.Tel = (string)GetNull(row["Tel"]);
                model.WorkAddress = (string)GetNull(row["WorkAddress"]);
                list.Add(model);
            }
            return list;
        }
    }
}
