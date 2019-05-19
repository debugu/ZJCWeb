using System;

namespace Data
{
    public partial class ClassBLL
    {
        public ClassModel GetByTeaID(Guid id)
        {
            return new ClassDAL().GetByTeaID(id);
        }
    }
}
