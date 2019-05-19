using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.DataASHX
{
    /// <summary>
    /// GetStuInfo 的摘要说明
    /// </summary>
    public class GetStuInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id= context.Request.Form["id"];
            //string stuname = new StudentInfoBLL().GetNameByStuId(id);
            StudentInfoModel m = new StudentInfoBLL().GetByStuCardId(id);
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(m));
            //context.Response.Write(stuname);
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