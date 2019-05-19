using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.erfen
{
    /// <summary>
    /// erfenPutGuessResult 的摘要说明
    /// </summary>
    public class erfenPutGuessResult : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            GuessResultModel m = new GuessResultModel();
            m.Lun= Convert.ToInt32(context.Request.Form["Lun"]);
            m.GuessPath= context.Request.Form["guessresult"];
            m.StuName= context.Request.Form["Name"];
            m.GuessNumber = m.GuessPath.Split(',').Length;
            new GuessResultBLL().AddNew(m);
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