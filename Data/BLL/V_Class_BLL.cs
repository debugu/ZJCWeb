using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class V_ClassBLL
    {
        public int AddNew(V_ClassModel model)
        {
            return new V_ClassDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new V_ClassDAL().Delete(id);
        }

        public int Update(V_ClassModel model)
        {
            return new V_ClassDAL().Update(model);
        }

        public V_ClassModel Get(Guid id)
        {
            return new V_ClassDAL().Get(id);
        }

        public IEnumerable<V_ClassModel> GetAll()
        {
            return new V_ClassDAL().GetAll();
        }
    }
}
