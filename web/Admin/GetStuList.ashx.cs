using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.Admin
{
    /// <summary>
    /// GetStuList 的摘要说明
    /// </summary>
    public class GetStuList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<StudentInfoModel> ls = new StudentInfoBLL().GetAll().ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(ls));
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