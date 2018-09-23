using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class BoarderInfoDAL
    {
        public int AddNew(BoarderInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_BoarderInfo(id,StuId,DormitoryNO,BedNO,ClassId) values(@id,@StuId,@DormitoryNO,@BedNO,@ClassId )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("DormitoryNO", model.DormitoryNO),
                            new SqlParameter("BedNO", model.BedNO),
                            new SqlParameter("ClassId", model.ClassId));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_BoarderInfo where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(BoarderInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_BoarderInfo set StuId=@StuId,DormitoryNO=@DormitoryNO,BedNO=@BedNO,ClassId=@ClassId where id=@id",
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("DormitoryNO", model.DormitoryNO),
                            new SqlParameter("BedNO", model.BedNO),
                            new SqlParameter("ClassId", model.ClassId),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public BoarderInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_BoarderInfo where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                BoarderInfoModel model = new BoarderInfoModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.DormitoryNO= (string)row["DormitoryNO"];
                model.BedNO= (string)row["BedNO"];
                model.ClassId= (Guid)row["ClassId"];
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<BoarderInfoModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_BoarderInfo");
            List<BoarderInfoModel> list = new List<BoarderInfoModel>();
            foreach (DataRow row in dt.Rows)
            {
                BoarderInfoModel model = new BoarderInfoModel();
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.DormitoryNO= (string)row["DormitoryNO"];
                model.BedNO= (string)row["BedNO"];
                model.ClassId= (Guid)row["ClassId"];
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
