using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace web.Teacher
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TeacherInfoModel result = new TeacherInfoBLL().CheckUserNameAndPassWord(context.Request.Form["UserName"], context.Request.Form["Password"]);
            if (result != null)
            {
                context.Session["UserName"] = result;
                context.Response.Write(result.Mark+":"+result.id);
            }
            else {
                context.Response.Write("error");
            }
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