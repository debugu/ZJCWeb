using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public partial class GuessParaBLL
    {
        public int Delete()
        {
            return new GuessParaDAL().Delete();
        }
    }
}
