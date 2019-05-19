using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace web.DataASHX
{
    /// <summary>
    /// SetRelutionsInserted 的摘要说明
    /// </summary>
    public class SetRelutionsInserted : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            new StudentInfoBLL().SetRelationInserted(new Guid(context.Request.Form["id"]));
            context.Response.Write("Hello World");
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