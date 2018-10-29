using Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace web.Admin
{
    /// <summary>
    /// ImportTeacherInfo 的摘要说明
    /// </summary>
    public class ImportTeacherInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile fileget = context.Request.Files[0];//获取上传的文件.
            string fullDir;
            if (fileget.ContentLength > 0)
            {
                //对上传的文件类型进行校验。
                string fileName = Path.GetFileName(fileget.FileName);//获取上传文件的名称包含扩展名。
                string fileExt = Path.GetExtension(fileName);//获取用户上传的文件扩展名。
                if (fileExt == ".xls")
                {
                    //1.对上传文件进行重命名？
                    string newfileName = Guid.NewGuid().ToString();
                    //2:将上传的文件放在不同的目录下面?
                    string dir = "../upload/";
                    //创建文件夹
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }

                    fullDir = dir + newfileName + fileExt;//文件存放的完整路径。
                    fileget.SaveAs(context.Request.MapPath(fullDir));
                    fullDir = context.Request.MapPath(fullDir);

                    //  file.SaveAs(context.Request.MapPath("/ImageUpload/"+fileName));//完成文件的保存。
                    //context.Response.Write("<html><body><img src='" + fullDir + "'/></body></html>");
                }
                else
                {
                    context.Response.Write("只能上传Excel文件");
                    return;
                }
            }
            else
            {
                context.Response.Write("请选择上传文件");
                return;
            }
            //TeacherInfoBLL obll = new TeacherInfoBLL();
            List<TeacherInfoModel> smodel = new List<TeacherInfoModel>();
            using (FileStream file = new FileStream(fullDir, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(file);
                HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(0);
                HSSFRow headerRow = (HSSFRow)sheet.GetRow(1);
                //一行最后一个方格的编号 即总的列数
                int cellCount = headerRow.LastCellNum;
                //最后一列的标号  即总的行数
                int rowCount = sheet.LastRowNum;
                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum + 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    TeacherInfoModel s = new TeacherInfoModel();
                    s.id = Guid.NewGuid();
                    s.UserName = row.GetCell(row.FirstCellNum).ToString();
                    s.Name = row.GetCell(row.FirstCellNum + 1).ToString();
                    s.TelYd = GetValue(row.GetCell(row.FirstCellNum + 2));
                    s.TelDx = GetValue(row.GetCell(row.FirstCellNum + 3));
                    s.TelLt = GetValue(row.GetCell(row.FirstCellNum + 4));
                    s.TelGh = GetValue(row.GetCell(row.FirstCellNum + 5));
                    s.EMail = GetValue(row.GetCell(row.FirstCellNum + 6));
                    s.IDCardNO = row.GetCell(row.FirstCellNum + 7).ToString();
                    s.Password = "123456";
                    s.Mark = "teacher";
                    new TeacherInfoBLL().AddNew(s);
                    smodel.Add(s);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(smodel));
        }

        string GetValue(ICell value)
        {
            if (value == null) return null;
            return value.ToString();
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