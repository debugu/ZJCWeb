using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class ClassBLL
    {
        public int AddNew(ClassModel model)
        {
            return new ClassDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new ClassDAL().Delete(id);
        }

        public int Update(ClassModel model)
        {
            return new ClassDAL().Update(model);
        }

        public ClassModel Get(Guid id)
        {
            return new ClassDAL().Get(id);
        }

        public IEnumerable<ClassModel> GetAll()
        {
            return new ClassDAL().GetAll();
        }
    }
}
