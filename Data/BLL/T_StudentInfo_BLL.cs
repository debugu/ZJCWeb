using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class StudentInfoBLL
    {
        public int AddNew(StudentInfoModel model)
        {
            return new StudentInfoDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new StudentInfoDAL().Delete(id);
        }

        public int Update(StudentInfoModel model)
        {
            return new StudentInfoDAL().Update(model);
        }

        public StudentInfoModel Get(Guid id)
        {
            return new StudentInfoDAL().Get(id);
        }

        public IEnumerable<StudentInfoModel> GetAll()
        {
            return new StudentInfoDAL().GetAll();
        }
    }
}
