using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class TenantInfoBLL
    {
        public int AddNew(TenantInfoModel model)
        {
            return new TenantInfoDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new TenantInfoDAL().Delete(id);
        }

        public int Update(TenantInfoModel model)
        {
            return new TenantInfoDAL().Update(model);
        }

        public TenantInfoModel Get(Guid id)
        {
            return new TenantInfoDAL().Get(id);
        }

        public IEnumerable<TenantInfoModel> GetAll()
        {
            return new TenantInfoDAL().GetAll();
        }
    }
}
