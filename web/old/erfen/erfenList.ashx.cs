using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.erfen
{
    /// <summary>
    /// erfenList 的摘要说明
    /// </summary>
    public class erfenList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int lun = Convert.ToInt32(context.Request.QueryString["lun"]);
            List<GuessResultModel> ls = new GuessResultBLL().GetAll(lun).ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(ls));
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