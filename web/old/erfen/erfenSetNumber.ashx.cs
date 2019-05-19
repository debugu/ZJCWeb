using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.erfen
{
    /// <summary>
    /// erfenSetNumber 的摘要说明
    /// </summary>
    public class erfenSetNumber : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            GuessParaModel m = new GuessParaModel();
            m.Lun = Convert.ToInt32(context.Request.Form["Lun"]);
            m.GuessValue = Convert.ToInt32(context.Request.Form["Number"]);
            m.GuessStyle = Convert.ToInt32(context.Request.Form["GuessStyle"]);
            m.GuessList = context.Request.Form["GuessList"];
            GuessParaBLL bll = new GuessParaBLL();
            bll.Delete();
            bll.AddNew(m);
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