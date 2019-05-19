using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.DataASHX
{
    /// <summary>
    /// GetRelationsById 的摘要说明
    /// </summary>
    public class GetRelationsById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Guid id =new Guid(context.Request.Form["id"]);
            context.Response.Write(new JavaScriptSerializer().Serialize(new StuRelationshipBLL().GetRelationsById(id)));
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