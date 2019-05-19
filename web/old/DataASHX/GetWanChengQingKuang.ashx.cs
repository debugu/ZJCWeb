using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.DataASHX
{
    /// <summary>
    /// GetWanChengQingKuang 的摘要说明
    /// </summary>
    public class GetWanChengQingKuang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string className = context.Request.Form["className"];
            List<WanChengQingkuangModel> m = new StudentInfoBLL().GetWanChengQingKuang(new ClassBLL().Get(new Guid(className)).ClassName).ToList();
            var memberList = from n in m
                             orderby n.JhNum descending,n.WanCheng descending
                             select n;
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(memberList));
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