using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFramwork
{
	class Program
	{
		static void Main(string[] args)
		{
            //FileInfo newFile = null;
            /*if (!File.Exists(path + "\\testsheet2.xlsx"))
            newFile = new FileInfo(path + "\\testsheet2.xlsx");
            else
                return newFile;*/
            Console.WriteLine("시작");
            var Articles = new[]
            {
                new {
                    Id = "101", Name = "C++"
                },
                new {
                    Id = "102", Name = "Python"
                },
                new {
                    Id = "103", Name = "Java Script"
                },
                new {
                    Id = "104", Name = "GO"
                },
                new {
                    Id = "105", Name = "Java"
                },
                new {
                    Id = "106", Name = "C#"
                }
            };
            //읽는 파일 위치
            string Path = @"D:\source\repos\ExcelFramwork\ExcelFramwork\bin\Debug\exceltest\abcd.xlsx";


            DataTable dataTable = new DataTable();
            using (ExcelPackage excel = new ExcelPackage(Path))
            {
                

                //라이센스
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // name of the sheet
                var workSheet = excel.Workbook.Worksheets[0];

                int rowCont = workSheet.Dimension.Rows;
                int colCount = workSheet.Dimension.Columns;

                for (int col = 1; col <= colCount; col++)
				{
                    dataTable.Columns.Add("Col"+col.ToString());
                    //dataTable.Columns.Add(workSheet.Cells[1, col].Value.ToString());

                }
                Queue<ExcelClass> Quecol = new Queue<ExcelClass>();
                //Queue<int> Querow = new Queue<int>();
                for (int row =1; row <= rowCont; row++)
				{
                    DataRow dataRow = dataTable.NewRow();
                    for(int column = 1; column <= colCount; column++)
					{
                        if(workSheet.Cells[row, column].Value != null && workSheet.Cells[row, column].Value.ToString().Substring(0,1) == "C")
						{
                            var ExcelClass = new ExcelClass();
                            ExcelClass.Col = column;
                            ExcelClass.Row = row;
                            Quecol.Enqueue(ExcelClass);
                            //Querow.Enqueue(row);

                        }

                        dataRow[column - 1] = workSheet.Cells[row, column].Value;

					}
                    dataTable.Rows.Add(dataRow);
				}
                string k2 = "Col3";
                string f2 = "C*";
                DataRow[] rs2 = dataTable.Select("[" + k2 + "] LIKE '" + f2 + "'");
                // setting the properties
                // of the work sheet 
                workSheet.DefaultRowHeight = 12;

                // Setting the properties
                // of the first row
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                // 헤더 정보
                workSheet.Cells[1, 1].Value = "S.No";
                workSheet.Cells[1, 2].Value = "Id";
                workSheet.Cells[1, 3].Value = "Name";

                //시작 포인트
                int recordIndex = 2;

                foreach (var article in Articles)
                {
                    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                    workSheet.Cells[recordIndex, 2].Value = article.Id;
                    workSheet.Cells[recordIndex, 3].Value = article.Name;
                    recordIndex++;
                }

                // 자동 셀크기 조정
                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
                DateTime thisDate2 = new DateTime();
                thisDate2 = DateTime.Now;
                // 저장파일위치 
                string p_strPath = @"D:\source\repos\ExcelFramwork\ExcelFramwork\bin\Debug\exceltest\"+thisDate2.ToString("yyyyMMddmmss")+".xlsx";

                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // 파일 생성
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // 엑셀 데이터 저장
                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                //엑셀 닫기
                excel.Dispose();
            }
            Console.WriteLine("성공! 아무 버튼 누르세요");
            Console.ReadKey();
        }
	}
}
