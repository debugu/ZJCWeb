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
    partial class BoarderInfoDAL
    {
        public int AddNew(BoarderInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_BoarderInfo(id,StuId,DormitoryNO,BedNO,ClassId) values(@id,@StuId,@DormitoryNO,@BedNO,@ClassId )",
                            new MySqlParameter("id", model.id),
                            new MySqlParameter("StuId", model.StuId),
                            new MySqlParameter("DormitoryNO", model.DormitoryNO),
                            new MySqlParameter("BedNO", model.BedNO),
                            new MySqlParameter("ClassId", model.ClassId));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_BoarderInfo where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(BoarderInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_BoarderInfo set StuId=@StuId,DormitoryNO=@DormitoryNO,BedNO=@BedNO,ClassId=@ClassId where id=@id",
                            new MySqlParameter("StuId", model.StuId),
                            new MySqlParameter("DormitoryNO", model.DormitoryNO),
                            new MySqlParameter("BedNO", model.BedNO),
                            new MySqlParameter("ClassId", model.ClassId),
                new MySqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public BoarderInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_BoarderInfo where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                BoarderInfoModel model = new BoarderInfoModel();
                DataRow row = dt.Rows[0];
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.DormitoryNO= (string)row["DormitoryNO"];
                model.BedNO= (string)row["BedNO"];
                model.ClassId= new Guid(row["ClassId"].ToString());
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
                model.id= new Guid(row["id"].ToString());
                model.StuId= new Guid(row["StuId"].ToString());
                model.DormitoryNO= (string)row["DormitoryNO"];
                model.BedNO= (string)row["BedNO"];
                model.ClassId= new Guid(row["ClassId"].ToString());
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
