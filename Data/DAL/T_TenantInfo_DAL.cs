using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace Data
{
    partial class TenantInfoDAL
    {
        public int AddNew(TenantInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("insert into T_TenantInfo(id,StuId,NowAddress,Area,TogetherStuNum,LandlordName,LandlordTel,Accompanyer1,Accompanyer2,IsInSchool,ClassId) values(@id,@StuId,@NowAddress,@Area,@TogetherStuNum,@LandlordName,@LandlordTel,@Accompanyer1,@Accompanyer2,@IsInSchool,@ClassId )",
                            new SqlParameter("id", model.id),
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("NowAddress", PutNull(model.NowAddress)),
                            new SqlParameter("Area", PutNull(model.Area)),
                            new SqlParameter("TogetherStuNum", PutNull(model.TogetherStuNum)),
                            new SqlParameter("LandlordName", PutNull(model.LandlordName)),
                            new SqlParameter("LandlordTel", PutNull(model.LandlordTel)),
                            new SqlParameter("Accompanyer1", PutNull(model.Accompanyer1)),
                            new SqlParameter("Accompanyer2", PutNull(model.Accompanyer2)),
                            new SqlParameter("IsInSchool", model.IsInSchool),
                            new SqlParameter("ClassId", model.ClassId));
            return Convert.ToInt32(obj);
        }

        public int Delete(Guid id)
        {
            return SqlHelper.ExecuteNonQuery("delete from T_TenantInfo where id=@id",
                new SqlParameter("id",id));
        }

        public int Update(TenantInfoModel model)
        {
            object obj = SqlHelper.ExecuteScalar("update T_TenantInfo set StuId=@StuId,NowAddress=@NowAddress,Area=@Area,TogetherStuNum=@TogetherStuNum,LandlordName=@LandlordName,LandlordTel=@LandlordTel,Accompanyer1=@Accompanyer1,Accompanyer2=@Accompanyer2,IsInSchool=@IsInSchool,ClassId=@ClassId where id=@id",
                            new SqlParameter("StuId", model.StuId),
                            new SqlParameter("NowAddress", PutNull(model.NowAddress)),
                            new SqlParameter("Area", PutNull(model.Area)),
                            new SqlParameter("TogetherStuNum", PutNull(model.TogetherStuNum)),
                            new SqlParameter("LandlordName", PutNull(model.LandlordName)),
                            new SqlParameter("LandlordTel", PutNull(model.LandlordTel)),
                            new SqlParameter("Accompanyer1", PutNull(model.Accompanyer1)),
                            new SqlParameter("Accompanyer2", PutNull(model.Accompanyer2)),
                            new SqlParameter("IsInSchool", model.IsInSchool),
                            new SqlParameter("ClassId", model.ClassId),
                new SqlParameter("id",model.id));
            return Convert.ToInt32(obj);
        }
        public TenantInfoModel Get(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_TenantInfo where id=@id",
                new SqlParameter("id",id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                TenantInfoModel model = new TenantInfoModel();
                DataRow row = dt.Rows[0];
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.NowAddress= (string)GetNull(row["NowAddress"]);
                model.Area= (int?)GetNull(row["Area"]);
                model.TogetherStuNum= (int?)GetNull(row["TogetherStuNum"]);
                model.LandlordName= (string)GetNull(row["LandlordName"]);
                model.LandlordTel= (string)GetNull(row["LandlordTel"]);
                model.Accompanyer1= (Guid?)GetNull(row["Accompanyer1"]);
                model.Accompanyer2= (Guid?)GetNull(row["Accompanyer2"]);
                model.IsInSchool= (bool)row["IsInSchool"];
                model.ClassId= (Guid)row["ClassId"];
                return model;
            }
            else
            {
                throw new Exception("出现多条数据！");
            }
        }

        public IEnumerable<TenantInfoModel> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_TenantInfo");
            List<TenantInfoModel> list = new List<TenantInfoModel>();
            foreach (DataRow row in dt.Rows)
            {
                TenantInfoModel model = new TenantInfoModel();
                model.id= (Guid)row["id"];
                model.StuId= (Guid)row["StuId"];
                model.NowAddress= (string)GetNull(row["NowAddress"]);
                model.Area= (int?)GetNull(row["Area"]);
                model.TogetherStuNum= (int?)GetNull(row["TogetherStuNum"]);
                model.LandlordName= (string)GetNull(row["LandlordName"]);
                model.LandlordTel= (string)GetNull(row["LandlordTel"]);
                model.Accompanyer1= (Guid?)GetNull(row["Accompanyer1"]);
                model.Accompanyer2= (Guid?)GetNull(row["Accompanyer2"]);
                model.IsInSchool= (bool)row["IsInSchool"];
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
