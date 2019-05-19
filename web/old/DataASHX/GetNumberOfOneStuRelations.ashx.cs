using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.DataASHX
{
    /// <summary>
    /// GetNumberOfOneStuRelations 的摘要说明
    /// </summary>
    public class GetNumberOfOneStuRelations : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string stuNo = context.Request.Form["id"];
            context.Response.Write(new JavaScriptSerializer().Serialize(new StudentInfoBLL().GetNumberOfRelationship(stuNo)));
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