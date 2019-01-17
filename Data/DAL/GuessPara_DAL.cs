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
    partial class GuessParaDAL
    {
        public int AddNew(GuessParaModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into GuessPara(GuessValue,Lun,GuessStyle,GuessList) values(@GuessValue,@Lun,@GuessStyle,@GuessList )",
                            new MySqlParameter("GuessValue", model.GuessValue),
                            new MySqlParameter("Lun", model.Lun),
                            new MySqlParameter("GuessStyle", model.GuessStyle),
                            new MySqlParameter("GuessList", PutNull(model.GuessList)));
            return Convert.ToInt32(obj);
        }

        public int Delete(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from GuessPara where id=@id",
                new MySqlParameter("id",id));
        }

        public int Update(GuessParaModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update GuessPara set GuessValue=@GuessValue,Lun=@Lun,GuessStyle=@GuessStyle,GuessList=@GuessList where id=@id",
                            new MySqlParameter("GuessValue", model.GuessValue),
                            new MySqlParameter("Lun", model.Lun),
                            new MySqlParameter("GuessStyle", model.GuessStyle),
                            new MySqlParameter("GuessList", PutNull(model.GuessList)),
                new MySqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public GuessParaModel Get(int id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from GuessPara where id=@id",
                new MySqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                GuessParaModel model = new GuessParaModel();
                DataRow row = dt.Rows[0];
                model.id= (int)row["id"];
                model.GuessValue= (int)row["GuessValue"];
                model.Lun= (int)row["Lun"];
                model.GuessStyle= (int)row["GuessStyle"];
                model.GuessList= (string)GetNull(row["GuessList"]);
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<GuessParaModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from GuessPara");
            List<GuessParaModel> list = new List<GuessParaModel>();
            foreach (DataRow row in dt.Rows)
            {
                GuessParaModel model = new GuessParaModel();
                model.id= (int)row["id"];
                model.GuessValue= (int)row["GuessValue"];
                model.Lun= (int)row["Lun"];
                model.GuessStyle= (int)row["GuessStyle"];
                model.GuessList= (string)GetNull(row["GuessList"]);
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
