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
        public int AddNew(GuessResultModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into GuessResult(StuName,IP,Lun,GuessPath,GuessNumber,Remark) values(@StuName,@IP,@Lun,@GuessPath,@GuessNumber,@Remark )",
                            new SqlParameter("StuName", model.StuName),
                            new SqlParameter("IP", PutNull(model.IP)),
                            new SqlParameter("Lun", model.Lun),
                            new SqlParameter("GuessPath", model.GuessPath),
                            new SqlParameter("GuessNumber", model.GuessNumber),
                            new SqlParameter("Remark", PutNull(model.Remark)));
            return Convert.ToInt32(obj);
        }

        public int Delete(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from GuessResult where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(GuessResultModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update GuessResult set StuName=@StuName,IP=@IP,Lun=@Lun,GuessPath=@GuessPath,GuessNumber=@GuessNumber,Remark=@Remark where id=@id",
                            new SqlParameter("StuName", model.StuName),
                            new SqlParameter("IP", PutNull(model.IP)),
                            new SqlParameter("Lun", model.Lun),
                            new SqlParameter("GuessPath", model.GuessPath),
                            new SqlParameter("GuessNumber", model.GuessNumber),
                            new SqlParameter("Remark", PutNull(model.Remark)),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public GuessResultModel Get(int id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from GuessResult where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                GuessResultModel model = new GuessResultModel();
                DataRow row = dt.Rows[0];
                model.id= (int)row["id"];
                model.StuName= (string)row["StuName"];
                model.IP= (string)GetNull(row["IP"]);
                model.Lun= (int)row["Lun"];
                model.GuessPath= (string)row["GuessPath"];
                model.GuessNumber= (int)row["GuessNumber"];
                model.Remark= (string)GetNull(row["Remark"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<GuessResultModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from GuessResult");
            List<GuessResultModel> list = new List<GuessResultModel>();
            foreach (DataRow row in dt.Rows)
            {
                GuessResultModel model = new GuessResultModel();
                model.id= (int)row["id"];
                model.StuName= (string)row["StuName"];
                model.IP= (string)GetNull(row["IP"]);
                model.Lun= (int)row["Lun"];
                model.GuessPath= (string)row["GuessPath"];
                model.GuessNumber= (int)row["GuessNumber"];
                model.Remark= (string)GetNull(row["Remark"]);
                list.Add(model);
            }
            return list;
        }

        public object GetNull(object value)//取空值处理
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        public object PutNull(object value)//赋空值处理
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        } 

    }
}
