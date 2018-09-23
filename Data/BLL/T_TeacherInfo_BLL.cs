using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class TeacherInfoBLL
    {
        public int AddNew(TeacherInfoModel model)
        {
            return new TeacherInfoDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new TeacherInfoDAL().Delete(id);
        }

        public int Update(TeacherInfoModel model)
        {
            return new TeacherInfoDAL().Update(model);
        }

        public TeacherInfoModel Get(Guid id)
        {
            return new TeacherInfoDAL().Get(id);
        }

        public IEnumerable<TeacherInfoModel> GetAll()
        {
            return new TeacherInfoDAL().GetAll();
        }
    }
}
