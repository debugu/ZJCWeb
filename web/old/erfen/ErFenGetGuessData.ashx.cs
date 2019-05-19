using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace web.erfen
{
    /// <summary>
    /// ErFenGetGuessData 的摘要说明
    /// </summary>
    public class ErFenGetGuessData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<GuessParaModel> ls = (new GuessParaBLL().GetAll()).ToList();
            context.Response.Write(ls[0].GuessValue+":"+ls[0].Lun+":" + ls[0].GuessStyle + ":" + ls[0].GuessList);
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