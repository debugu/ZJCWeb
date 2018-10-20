using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public partial class GuessResultBLL
    {
        public IEnumerable<GuessResultModel> GetAll(int lun)
        {
            return new GuessResultDAL().GetAll(lun);
        }
    }
}
