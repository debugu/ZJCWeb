using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class GuessResultBLL
    {
        public int AddNew(GuessResultModel model)
        {
            return new GuessResultDAL().AddNew(model);
        }

        public int Delete(int id)
        {
            return new GuessResultDAL().Delete(id);
        }

        public int Update(GuessResultModel model)
        {
            return new GuessResultDAL().Update(model);
        }

        public GuessResultModel Get(int id)
        {
            return new GuessResultDAL().Get(id);
        }

        public IEnumerable<GuessResultModel> GetAll()
        {
            return new GuessResultDAL().GetAll();
        }
    }
}
