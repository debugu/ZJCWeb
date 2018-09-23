using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class PunishRecordBLL
    {
        public int AddNew(PunishRecordModel model)
        {
            return new PunishRecordDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new PunishRecordDAL().Delete(id);
        }

        public int Update(PunishRecordModel model)
        {
            return new PunishRecordDAL().Update(model);
        }

        public PunishRecordModel Get(Guid id)
        {
            return new PunishRecordDAL().Get(id);
        }

        public IEnumerable<PunishRecordModel> GetAll()
        {
            return new PunishRecordDAL().GetAll();
        }
    }
}
