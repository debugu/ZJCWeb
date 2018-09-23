using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class ExternInfoBLL
    {
        public int AddNew(ExternInfoModel model)
        {
            return new ExternInfoDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new ExternInfoDAL().Delete(id);
        }

        public int Update(ExternInfoModel model)
        {
            return new ExternInfoDAL().Update(model);
        }

        public ExternInfoModel Get(Guid id)
        {
            return new ExternInfoDAL().Get(id);
        }

        public IEnumerable<ExternInfoModel> GetAll()
        {
            return new ExternInfoDAL().GetAll();
        }
    }
}
