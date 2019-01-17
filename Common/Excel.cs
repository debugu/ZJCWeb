using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Linq;

namespace Common
{
    public class Excel
    {
        public static bool ExportToExcel(string filepath,string sheetname, string tablename, object[] m, params string[] colname)
        {
            //SaveFileDialog sdfExport = new SaveFileDialog();
            //sdfExport.Filter = "Excel文件|*.xls";
            //if (sdfExport.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            //{
            //    return false;
            //}
            string filename = filepath;
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(sheetname);
            object mo = new object();
            try
            {
                mo = m[0];
            }
            catch
            {
                throw new Exception("数据为空，请检查数据！");
            }
            Type tp = mo.GetType();
            IRow rowheader = sheet.CreateRow(0);
            rowheader.Height = 25 * 20;
            ICell cell5 = rowheader.CreateCell(0);
            cell5.SetCellValue(tablename);
            ICellStyle style5 = workbook.CreateCellStyle();
            style5.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            IFont font5 = workbook.CreateFont();// 定义字体
            font5.FontHeight = 20 * 20;
            font5.FontName = "华文新魏";
            style5.SetFont(font5);
            cell5.CellStyle = style5;
            NPOI.SS.Util.CellRangeAddress cellRangeAddress = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, tp.GetProperties().Count() - colname.Count() - 1);// ' 指定单元格合并的起止位置
            sheet.AddMergedRegion(cellRangeAddress);
            rowheader = sheet.CreateRow(1);
            int i = 0;//列号
            foreach (System.Reflection.PropertyInfo p in tp.GetProperties())
            {
                //object value = new object();
                //value = p.GetValue(mo, null);
                bool nothave = true;
                foreach (string s in colname)
                {
                    if (p.Name == s)
                    {
                        nothave = false;
                        break;
                    }
                }
                if (nothave)
                {
                    rowheader.CreateCell(i, CellType.STRING).SetCellValue(p.Name);
                    i = i + 1;
                }
            }
            for (i = 0; i < m.Length; i++)
            {
                object o = new object();
                o = m[i];
                tp = o.GetType();
                IRow row = sheet.CreateRow(i + 2);
                int j = 0;
                foreach (System.Reflection.PropertyInfo p in tp.GetProperties())
                {
                    object value = new object();
                    value = p.GetValue(o, null);
                    if (value != null)
                    {
                        bool nothave = true;
                        foreach (string s in colname)
                        {
                            if (p.Name == s)
                            {
                                nothave = false;
                                j--;
                                break;
                            }
                        }
                        if (nothave)
                        {
                            switch (value.GetType().ToString())
                            {
                                case "System.String":
                                    row.CreateCell(j, CellType.STRING).SetCellValue(value.ToString());
                                    break;
                                case "System.Decimal":
                                    row.CreateCell(j, CellType.NUMERIC).SetCellValue(Convert.ToDouble(value));
                                    break;
                                case "System.Guid":
                                    row.CreateCell(j, CellType.STRING).SetCellValue(value.ToString());
                                    break;
                                case "System.Int32":
                                    row.CreateCell(j, CellType.NUMERIC).SetCellValue(Convert.ToInt32(value));
                                    break;
                                case "System.Int64":
                                    row.CreateCell(j, CellType.NUMERIC).SetCellValue(Convert.ToInt32(value));
                                    break;
                                case "System.Int16":
                                    row.CreateCell(j, CellType.NUMERIC).SetCellValue(Convert.ToInt32(value));
                                    break;
                                case "System.Boolean":
                                    row.CreateCell(j, CellType.STRING).SetCellValue(Convert.ToBoolean(value));
                                    break;
                                case "System.DateTime":
                                    DateTime d;
                                    d = Convert.ToDateTime(value);
                                    ICellStyle styledate = workbook.CreateCellStyle();
                                    IDataFormat Format = workbook.CreateDataFormat();
                                    styledate.DataFormat = Format.GetFormat("yyyy\"年\"m\"月\"d\"日\"");
                                    ICell cellInDate = row.CreateCell(j, CellType.NUMERIC);
                                    cellInDate.CellStyle = styledate;
                                    cellInDate.SetCellValue(d);
                                    break;
                                default:
                                    row.CreateCell(j, CellType.STRING).SetCellValue(value.ToString());
                                    break;
                            }

                        }
                    }
                    j = j + 1;
                }
            }
            try
            {
                using (Stream stream = File.OpenWrite(filename))
                {
                    workbook.Write(stream);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
