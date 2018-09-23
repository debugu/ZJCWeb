using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class StuRelationshipBLL
    {
        public int AddNew(StuRelationshipModel model)
        {
            return new StuRelationshipDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new StuRelationshipDAL().Delete(id);
        }

        public int Update(StuRelationshipModel model)
        {
            return new StuRelationshipDAL().Update(model);
        }

        public StuRelationshipModel Get(Guid id)
        {
            return new StuRelationshipDAL().Get(id);
        }

        public IEnumerable<StuRelationshipModel> GetAll()
        {
            return new StuRelationshipDAL().GetAll();
        }
    }
}
