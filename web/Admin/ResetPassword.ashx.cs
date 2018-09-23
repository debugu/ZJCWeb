using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Admin
{
    /// <summary>
    /// ResetPassword 的摘要说明
    /// </summary>
    public class ResetPassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Guid id = new Guid(context.Request.QueryString["id"]);
            TeacherInfoModel m = new TeacherInfoBLL().Get(id);
            m.Password = "123456";
           context.Response.Write(new TeacherInfoBLL().Update(m));
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