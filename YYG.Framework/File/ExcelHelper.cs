using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
   public class ExcelHelper
    {
        public static byte[] GenExcelWithData<T>(List<T> lstData)
        {
            Type tp = typeof(T);
            var arrPro = tp.GetProperties();

            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            //创建表头
            IRow headRow = sheet.CreateRow(0);
            for (int i = 0; i < arrPro.Count(); i++)
            {
                var p = arrPro[i];
                string headName = p.Name;
                var attr = p.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();
                if (attr != null)
                {
                    headName = ((DisplayNameAttribute)attr).DisplayName;
                }
                headRow.CreateCell(i).SetCellValue(headName);
            }

            //填充数据
            for (int i = 0; i < lstData.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < arrPro.Count(); j++)
                {
                    var p = arrPro[j];
                    object cellVal = p.GetValue(lstData[i]);
                    string strCellVal = cellVal != null ? cellVal.ToString() : null;
                    dataRow.CreateCell(j).SetCellValue(strCellVal);
                }
            }

            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);

            byte[] fileByte = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(fileByte, 0, fileByte.Length);

            return fileByte;
        }
    }
}
