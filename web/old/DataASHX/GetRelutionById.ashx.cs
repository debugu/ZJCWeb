using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.DataASHX
{
    /// <summary>
    /// GetRelutionById 的摘要说明
    /// </summary>
    public class GetRelutionById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Guid id = new Guid(context.Request.Form["id"]);
            StuRelationshipModel m= new StuRelationshipBLL().Get(id);
            context.Response.Write(new JavaScriptSerializer().Serialize(m));
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