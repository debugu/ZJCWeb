using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class GuessParaBLL
    {
        public int AddNew(GuessParaModel model)
        {
            return new GuessParaDAL().AddNew(model);
        }

        public int Delete(int id)
        {
            return new GuessParaDAL().Delete(id);
        }

        public int Update(GuessParaModel model)
        {
            return new GuessParaDAL().Update(model);
        }

        public GuessParaModel Get(int id)
        {
            return new GuessParaDAL().Get(id);
        }

        public IEnumerable<GuessParaModel> GetAll()
        {
            return new GuessParaDAL().GetAll();
        }
    }
}
