using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public partial class StuRelationshipBLL
    {
        /// <summary>
        /// ����ѧ�����֤����Ӽ໤���б���ɾ��ѧ���ļ໤��
        /// </summary>
        /// <param name="CardId"></param>
        /// <returns></returns>
        public int DeleteByCarId(string CardId)
        {
            return new StuRelationshipDAL().Delete(CardId);
        }

        public IEnumerable<StuJHInfoModel> GetStuJHInfoModel()
        {
            return new StuRelationshipDAL().GetStuJHInfoModel();
        }
    }
}