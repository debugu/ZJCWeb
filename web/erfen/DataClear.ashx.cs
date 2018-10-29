using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.erfen
{
    /// <summary>
    /// DataClear 的摘要说明
    /// </summary>
    public class DataClear : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            new GuessResultBLL().Delete();
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