using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace web.Admin
{
    /// <summary>
    /// ExportStuInfo 的摘要说明
    /// </summary>
    public class ExportStuInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string filename = "学生信息.xls";
            string filepath = context.Request.MapPath("..\\download\\") + filename;
            StudentInfoModel[] ls = new StudentInfoBLL().GetAll().ToArray();
            Excel.ExportToExcel(filepath, "学生信息", "学生信息一览", ls);
            //context.Response.Redirect(filepath);
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