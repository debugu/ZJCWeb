using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.DataASHX
{
    /// <summary>
    /// UpdateStuRelutian 的摘要说明
    /// </summary>
    public class UpdateStuRelutian : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StuRelationshipModel m = new StuRelationshipModel();
            m.id =new Guid(context.Request.Form["id"]);
            m.StuId = new StuRelationshipBLL().Get(m.id).StuId;
            m.XCall = context.Request.Form["Call"];
            m.IDCardNO = context.Request.Form["IDCardNO"];
            m.XName = context.Request.Form["Name"];
            m.Tel = context.Request.Form["Tel"];
            new StuRelationshipBLL().Update(m);
            context.Response.Write(m.StuId);
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