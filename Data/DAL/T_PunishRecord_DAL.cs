using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class PunishRecordDAL
    {
        public int AddNew(PunishRecordModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_PunishRecord(id,StuId,PunishClassId,PunishTime,Reason,IsCancel,CancelTime,CancelClassId) values(@id,@StuId,@PunishClassId,@PunishTime,@Reason,@IsCancel,@CancelTime,@CancelClassId )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("PunishClassId", model.PunishClassId),
                            new SqlParameter("PunishTime", model.PunishTime),
                            new SqlParameter("Reason", PutNull(model.Reason)),
                            new SqlParameter("IsCancel", model.IsCancel),
                            new SqlParameter("CancelTime", PutNull(model.CancelTime)),
                            new SqlParameter("CancelClassId", PutNull(model.CancelClassId)));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_PunishRecord where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(PunishRecordModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_PunishRecord set StuId=@StuId,PunishClassId=@PunishClassId,PunishTime=@PunishTime,Reason=@Reason,IsCancel=@IsCancel,CancelTime=@CancelTime,CancelClassId=@CancelClassId where id=@id",
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("PunishClassId", model.PunishClassId),
                            new SqlParameter("PunishTime", model.PunishTime),
                            new SqlParameter("Reason", PutNull(model.Reason)),
                            new SqlParameter("IsCancel", model.IsCancel),
                            new SqlParameter("CancelTime", PutNull(model.CancelTime)),
                            new SqlParameter("CancelClassId", PutNull(model.CancelClassId)),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public PunishRecordModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_PunishRecord where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                PunishRecordModel model = new PunishRecordModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
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
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
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
