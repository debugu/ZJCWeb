using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace web.DataASHX
{
    /// <summary>
    /// AddStuRelationship 的摘要说明
    /// </summary>
    public class AddStuRelationship : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StuRelationshipModel m = new StuRelationshipModel();
            m.id = Guid.NewGuid();
            m.XCall=context.Request.Form["Call"];
            m.IDCardNO = context.Request.Form["IDCardNO"];
            m.XName = context.Request.Form["Name"];
            m.Tel = context.Request.Form["Tel"];
            m.StuId =new Guid(context.Request.Form["id"]);
            new StuRelationshipBLL().AddNew(m);
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