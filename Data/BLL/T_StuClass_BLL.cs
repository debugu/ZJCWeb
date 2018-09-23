using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class StuClassBLL
    {
        public int AddNew(StuClassModel model)
        {
            return new StuClassDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new StuClassDAL().Delete(id);
        }

        public int Update(StuClassModel model)
        {
            return new StuClassDAL().Update(model);
        }

        public StuClassModel Get(Guid id)
        {
            return new StuClassDAL().Get(id);
        }

        public IEnumerable<StuClassModel> GetAll()
        {
            return new StuClassDAL().GetAll();
        }
    }
}
