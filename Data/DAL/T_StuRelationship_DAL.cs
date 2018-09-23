using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class StuRelationshipDAL
    {
        public int AddNew(StuRelationshipModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_StuRelationship(id,StuId,Call,Name,IDCardNO,Tel,WorkAddress) values(@id,@StuId,@Call,@Name,@IDCardNO,@Tel,@WorkAddress )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("Call", PutNull(model.Call)),
                            new SqlParameter("Name", PutNull(model.Name)),
                            new SqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new SqlParameter("Tel", PutNull(model.Tel)),
                            new SqlParameter("WorkAddress", PutNull(model.WorkAddress)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_StuRelationship where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(StuRelationshipModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StuRelationship set StuId=@StuId,Call=@Call,Name=@Name,IDCardNO=@IDCardNO,Tel=@Tel,WorkAddress=@WorkAddress where id=@id",
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("Call", PutNull(model.Call)),
                            new SqlParameter("Name", PutNull(model.Name)),
                            new SqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new SqlParameter("Tel", PutNull(model.Tel)),
                            new SqlParameter("WorkAddress", PutNull(model.WorkAddress)),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public StuRelationshipModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuRelationship where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                StuRelationshipModel model = new StuRelationshipModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.Call= (string)GetNull(row["Call"]);
                model.Name= (string)GetNull(row["Name"]);
                model.IDCardNO= (string)GetNull(row["IDCardNO"]);
                model.Tel= (string)GetNull(row["Tel"]);
                model.WorkAddress= (string)GetNull(row["WorkAddress"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<StuRelationshipModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuRelationship");
            List<StuRelationshipModel> list = new List<StuRelationshipModel>();
            foreach (DataRow row in dt.Rows)
            {
                StuRelationshipModel model = new StuRelationshipModel();
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.Call= (string)GetNull(row["Call"]);
                model.Name= (string)GetNull(row["Name"]);
                model.IDCardNO= (string)GetNull(row["IDCardNO"]);
                model.Tel= (string)GetNull(row["Tel"]);
                model.WorkAddress= (string)GetNull(row["WorkAddress"]);
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
