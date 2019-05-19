using Common;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Admin
{
    /// <summary>
    /// ExportJHInfo 的摘要说明
    /// </summary>
    public class ExportJHInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string filename = "监护人信息.xls";
            string filepath = context.Request.MapPath("..\\download\\") + filename;
            StuJHInfoModel[] ls = new StuRelationshipBLL().GetStuJHInfoModel().ToArray();
            Excel.ExportToExcel(filepath, "监护人信息", "监护人信息一览", ls);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}