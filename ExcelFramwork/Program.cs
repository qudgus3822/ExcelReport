using OfficeOpenXml;
using OfficeOpenXml.ConditionalFormatting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.Style;
using STIS.Framework.V4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ExcelFramwork
{
	class Program
	{
        static void Main(string[] args)
        {
          
            //읽는 파일 위치
            string Path = "";

            //기본 엑셀 파일 경로 (day, month, year) 
            //Path = @"D:\source\repos\ExcelReport\ExcelFramwork\bin\Debug\exceltest\day.xlsx";
            Path = @"D:\source\repos\ExcelReport\ExcelFramwork\bin\Debug\exceltest\month.xlsx";


            //Path = @"C:\Users\클라우드플렛폼\source\repos\MainBlack\Web\BEMS.Web.MainBlack\Upload\Report\BaseExcel\day.xlsx";
            //Path = @"C:\Users\클라우드플렛폼\source\repos\MainBlack\Web\BEMS.Web.MainBlack\Upload\Report\BaseExcel\month.xlsx";

            //구분 ex) 년 1, 월 2, 일 3
            //int group = 1;
            int group = 2;
            //int group = 3;


            //보고서용 테이블 타입별 관제점 리스트 조회
            DataSet ds = Util.GetReportPtAddressList(group);
            
            var Formula = "";
            var cols = "";

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                int ct = 1;
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                    if (ct != ds.Tables[0].Rows.Count)
                    {
                        var pt_addr = ds.Tables[0].Rows[i]["pt_addr"] + "|";
                        var pt_point = ds.Tables[0].Rows[i]["ReportPoint"] + ",";

                        Formula += pt_addr;

                        if(cols.Contains(ds.Tables[0].Rows[i]["ReportPoint"].ToString()) == false)
                        {
                             cols += pt_point;
                        }
                    }
                    else
                    {
                        var pt_addr = ds.Tables[0].Rows[i]["pt_addr"];
                        var pt_point = ds.Tables[0].Rows[i]["ReportPoint"];

                        Formula += pt_addr;
                        
                        if (cols.Contains(ds.Tables[0].Rows[i]["ReportPoint"].ToString()) == false)      
                        {
                            cols += pt_point;  
                        }
                    }

                    ct = ct + 1;
                }

            }
            else
            {
                return;
            } 

            //타입별 기간 설정하기

            //일
            //var fromDt = DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "00";
            //var toDt = DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "23";

            //월
            var y1 = DateTime.Now.AddDays(-1).ToString("yyyy");
            var m1 = DateTime.Now.AddDays(-1).ToString("MM");

            var lastMonthDay = DateTime.DaysInMonth(int.Parse(y1), int.Parse(m1));
            var fromDt = DateTime.Now.AddDays(-1).ToString("yyyyMM") + "01";
            var toDt = DateTime.Now.AddDays(-1).ToString("yyyyMM") + lastMonthDay;





            TimePeriod timePeriod = new TimePeriod();
            PtData calculation = new PtData();

            timePeriod.FromDT= fromDt;
            timePeriod.ToDT = toDt;
            timePeriod.IntervalMin = "0";
            timePeriod.TimeSelect = group; 
            calculation.Cols = cols;
            calculation.Formulas = Formula;

            //관제점 값 가져오기 
            var result = Util.GetData(calculation, timePeriod);

            using (ExcelPackage excel = new ExcelPackage(Path))
            {
                                //라이센스
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var workSheet = excel.Workbook.Worksheets[0];

                int pt_count = 1;

                if (result != null && result.Tables[0].Rows.Count > 0)
                {
                    workSheet.Cells[2, 2].Value = "성능진단용 분석 보고서";

                      for (var i = 0; i< result.Tables[0].Columns.Count; i++)
                       {
                          if((result.Tables[0].Columns[i].ColumnName) == pt_count.ToString())
                          {
                              workSheet.Cells[3, i + 2].Value = ds.Tables[0].Rows[pt_count - 1]["pt_name"];
                              
                              
                              pt_count++;

                          }
                          else
                          {
                              workSheet.Cells[3, i + 2].Value = result.Tables[0].Columns[i].ColumnName;

                          }

                      }

                      for (var i = 0; i < result.Tables[0].Rows.Count; i++)
                      {
                          for (var j = 0; j < result.Tables[0].Columns.Count; j++)
                          {

                              workSheet.Cells[i + 4, j + 2].Value = result.Tables[0].Rows[i][j];

                          }
                          
                      }
                }
                workSheet.Columns.AutoFit();

                // 저장파일위치 
          //      string p_strPath = @"D:\source\repos\ExcelReport\ExcelFramwork\bin\Debug\exceltest\DAY_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".xlsx";

                string p_strPath = @"D:\source\repos\ExcelReport\ExcelFramwork\bin\Debug\exceltest\Month_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".xlsx";

                //string p_strPath = @"C:\Users\클라우드플렛폼\source\repos\MainBlack\Web\BEMS.Web.MainBlack\Upload\Report\Day\DAY_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".xlsx";
                //string p_strPath = @"C:\Users\클라우드플렛폼\source\repos\MainBlack\Web\BEMS.Web.MainBlack\Upload\Report\Month\Month_" + DateTime.Now.ToString("yyyymmdd") + ".xlsx";

                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // 파일 생성
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // 엑셀 데이터 저장
                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                //엑셀 닫기
                excel.Dispose();

                
                Environment.Exit(0);

                return;

            }

        }
	}
}
