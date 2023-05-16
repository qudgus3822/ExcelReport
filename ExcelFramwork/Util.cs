using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using STIS.Framework.V4;
using System.Configuration;

namespace ExcelFramwork
{
    public class Util
    {


        public static DataSet GetReportPtAddressList(int type)
        {

            DataSet ds = new DataSet();
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ToString());
            SqlConnection conn = new SqlConnection("Data Source=192.168.123.40;Initial Catalog=OEMSMST;Persist Security Info=false;Integrated Security=false;User ID=sa;Password=pass@word!02;enlist=true;");

            conn.Open();

            SqlCommand cmd;
            SqlDataAdapter da;

            cmd = new SqlCommand("select * from TbReportPointSetting where ReportType=" + type , conn);

            cmd.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public static DataSet GetData(PtData calculation, TimePeriod timePeriod)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection("Data Source=192.168.123.40;Initial Catalog=OEMSMST;Persist Security Info=false;Integrated Security=false;User ID=sa;Password=pass@word!02;enlist=true;");
            conn.Open();

            SqlCommand cmd;
            SqlDataAdapter da;

          //  foreach (var formula in calculation.Formulas)
          //  {
          //      formula.ResultHistory = formula.Value;
          //  }

            var intervalMin = CommonLib.IsNullInt32(timePeriod.IntervalMin);



            var cols = calculation.Cols;
            var formulas = calculation.Formulas;


            // var list = new List<string>();

            //var t = calculation.Cols.Split(new string[]{","}, StringSplitOptions.None);


            //for (int i = 0; i < t.Length; i++)
            //{
            //    list.Add(t[i].Replace("]", $"{calculation.Gubun[i]}]"));
            //}

            //var formulas = Util.Join(list, "|");

            timePeriod.ConvertLogTime();

            cmd = new SqlCommand("PrEC_PointLogRt_Q5", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Group", SqlDbType.Int).Value = timePeriod.Group;

            cmd.Parameters.AddWithValue("@IntervalMin", SqlDbType.Int).Value = intervalMin;
            cmd.Parameters.AddWithValue("@FromDT", SqlDbType.NVarChar).Value = timePeriod.FromDT;
            cmd.Parameters.AddWithValue("@ToDT", SqlDbType.NVarChar).Value = timePeriod.ToDT;
            cmd.Parameters.AddWithValue("@FromDT2", SqlDbType.NVarChar).Value = timePeriod.FromDT2;
            cmd.Parameters.AddWithValue("@ToDT2", SqlDbType.NVarChar).Value = timePeriod.ToDT2;
            cmd.Parameters.AddWithValue("@Cols", SqlDbType.NVarChar).Value = cols;
            cmd.Parameters.AddWithValue("@Formula", SqlDbType.NVarChar).Value = formulas;

            da = new SqlDataAdapter(cmd);

            da.Fill(ds);

       //     if (ds.Tables[0].Columns.Contains("LogTime")) ds.Tables[0].Columns.Remove("LogTime");

            return ds;
        }



        public static string Join(System.Collections.IEnumerable list, string seperator)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                if (item != null && item.ToString() != String.Empty)
                    sb.Append(item + seperator);
            }

            var str = sb.ToString();
            if (str.Length > 1) str = str.Remove(str.Length - seperator.Length, seperator.Length);
            return str;
        }

        /// <summary>
        /// 패턴구간내의 문자열 추출
        /// </summary>
        /// <param name="source"></param>
        /// <param name="patternStart"></param>
        /// <param name="patternEnd"></param>
        /// <returns></returns>++
        public static string SubString(string source, string patternStart, string patternEnd)
        {
            if (source.IndexOf(patternStart) > -1)
            {
                int start = source.IndexOf(patternStart) + patternStart.Length;

                if (source.IndexOf(patternEnd, start) > -1 && patternEnd != "") // or start보다 클때..
                {
                    int end = source.IndexOf(patternEnd, start);

                    return source.Substring(start, end - start);
                }
                else
                {
                    return source.Substring(start);
                }
            }

            return "";
        }

        /// <summary>
        /// 반복되는 구간내에서 nCnt번째 존재하는 문자열 찾기
        /// </summary>
        /// <param name="source"></param>
        /// <param name="patternStart"></param>
        /// <param name="patternEnd"></param>
        /// <param name="nCnt"></param>
        /// <returns></returns>
        public static string SubString(string source, string patternStart, string patternEnd, int nCnt)
        {
            string result = SubString(source, patternStart, patternEnd);

            for (int i = 0; i < nCnt - 1; i++)
            {
                source = source.Replace(patternStart + result + patternEnd, "");
                result = SubString(source, patternStart, patternEnd);
            }
            return result;
        }




    }
}
