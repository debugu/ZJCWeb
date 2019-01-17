using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.DataASHX
{
    /// <summary>
    /// DelStuRelationshipByStuCardID 的摘要说明
    /// </summary>
    public class DelStuRelationshipByStuCardID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request.Form["id"];
            context.Response.Write(new StuRelationshipBLL().DeleteByCarId(id));
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