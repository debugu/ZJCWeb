using Data;
using System.Web;

namespace web.DataASHX
{
    /// <summary>
    /// GetTeaInfo 的摘要说明
    /// </summary>
    public class GetTeaInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request.Form["username"];
            context.Response.Write(new TeacherInfoBLL().GetClassIdByTeaName(username));
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