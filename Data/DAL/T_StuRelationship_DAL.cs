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
        public int AddNew(StuRelationshipModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_StuRelationship(id,StuId,XCall,XName,IDCardNO,Tel,WorkAddress) values(@id,@StuId,@XCall,@XName,@IDCardNO,@Tel,@WorkAddress)",
                            new MySqlParameter("id", model.id),
                            new MySqlParameter("StuId", model.StuId),
                            new MySqlParameter("XCall", PutNull(model.XCall)),
                            new MySqlParameter("XName", PutNull(model.XName)),
                            new MySqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new MySqlParameter("Tel", PutNull(model.Tel)),
                            new MySqlParameter("WorkAddress", PutNull(model.WorkAddress)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_StuRelationship where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(StuRelationshipModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_StuRelationship set StuId=@StuId,XCall=@XCall,XName=@XName,IDCardNO=@IDCardNO,Tel=@Tel,WorkAddress=@WorkAddress where id=@id",
                            new MySqlParameter("StuId", model.StuId),
                            new MySqlParameter("XCall", PutNull(model.XCall)),
                            new MySqlParameter("XName", PutNull(model.XName)),
                            new MySqlParameter("IDCardNO", PutNull(model.IDCardNO)),
                            new MySqlParameter("Tel", PutNull(model.Tel)),
                            new MySqlParameter("WorkAddress", PutNull(model.WorkAddress)),
                new MySqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public StuRelationshipModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_StuRelationship where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                StuRelationshipModel model = new StuRelationshipModel();
                DataRow row = dt.Rows[0];
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.XCall= (string)GetNull(row["XCall"]);
                model.XName= (string)GetNull(row["XName"]);
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
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.XCall= (string)GetNull(row["XCall"]);
                model.XName= (string)GetNull(row["XName"]);
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
