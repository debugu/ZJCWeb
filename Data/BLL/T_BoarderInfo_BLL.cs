using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class BoarderInfoBLL
    {
        public int AddNew(BoarderInfoModel model)
        {
            return new BoarderInfoDAL().AddNew(model);
        }

        public int Delete(Guid id)
        {
            return new BoarderInfoDAL().Delete(id);
        }

        public int Update(BoarderInfoModel model)
        {
            return new BoarderInfoDAL().Update(model);
        }

        public BoarderInfoModel Get(Guid id)
        {
            return new BoarderInfoDAL().Get(id);
        }

        public IEnumerable<BoarderInfoModel> GetAll()
        {
            return new BoarderInfoDAL().GetAll();
        }
    }
}
