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
    partial class PunishRecordDAL
    {
        public int AddNew(PunishRecordModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_PunishRecord(id,StuId,PunishClassId,PunishTime,Reason,IsCancel,CancelTime,CancelClassId) values(@id,@StuId,@PunishClassId,@PunishTime,@Reason,@IsCancel,@CancelTime,@CancelClassId )",
                            new MySqlParameter("id", model.id),
                            new MySqlParameter("StuId", model.StuId),
                            new MySqlParameter("PunishClassId", model.PunishClassId),
                            new MySqlParameter("PunishTime", model.PunishTime),
                            new MySqlParameter("Reason", PutNull(model.Reason)),
                            new MySqlParameter("IsCancel", model.IsCancel),
                            new MySqlParameter("CancelTime", PutNull(model.CancelTime)),
                            new MySqlParameter("CancelClassId", PutNull(model.CancelClassId)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_PunishRecord where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(PunishRecordModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_PunishRecord set StuId=@StuId,PunishClassId=@PunishClassId,PunishTime=@PunishTime,Reason=@Reason,IsCancel=@IsCancel,CancelTime=@CancelTime,CancelClassId=@CancelClassId where id=@id",
                            new MySqlParameter("StuId", model.StuId),
                            new MySqlParameter("PunishClassId", model.PunishClassId),
                            new MySqlParameter("PunishTime", model.PunishTime),
                            new MySqlParameter("Reason", PutNull(model.Reason)),
                            new MySqlParameter("IsCancel", model.IsCancel),
                            new MySqlParameter("CancelTime", PutNull(model.CancelTime)),
                            new MySqlParameter("CancelClassId", PutNull(model.CancelClassId)),
                new MySqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public PunishRecordModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_PunishRecord where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                PunishRecordModel model = new PunishRecordModel();
                DataRow row = dt.Rows[0];
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.PunishClassId= (Guid)row["PunishClassId"];
                model.PunishTime= (DateTime)row["PunishTime"];
                model.Reason= (string)GetNull(row["Reason"]);
                model.IsCancel= (bool)row["IsCancel"];
                model.CancelTime= (DateTime?)GetNull(row["CancelTime"]);
                model.CancelClassId= (Guid?)GetNull(row["CancelClassId"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<PunishRecordModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_PunishRecord");
            List<PunishRecordModel> list = new List<PunishRecordModel>();
            foreach (DataRow row in dt.Rows)
            {
                PunishRecordModel model = new PunishRecordModel();
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.PunishClassId= (Guid)row["PunishClassId"];
                model.PunishTime= (DateTime)row["PunishTime"];
                model.Reason= (string)GetNull(row["Reason"]);
                model.IsCancel= (bool)row["IsCancel"];
                model.CancelTime= (DateTime?)GetNull(row["CancelTime"]);
                model.CancelClassId= (Guid?)GetNull(row["CancelClassId"]);
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
