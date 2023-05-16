using STIS.Framework.V4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFramwork
{
    [Serializable]
    public class TimePeriod
    {



        /// <summary>
        /// 시간조건
        ///  - 0=실시간전용, 1=년(월별), 2=월(일별), 3=일(시간별), 4=일기간(일별), 5=절기(월별), 6=다년
        ///  - 7=년(비교) 8=월(비교) 9=일(비교)
        ///  - 10=분
        /// </summary>
        public int TimeSelect { get; set; }

        /// <summary>
        /// 시작일자
        /// </summary>
        public string FromDT { get; set; }
        /// <summary>
        /// 종료일자
        /// </summary>
        public string ToDT { get; set; }
        /// <summary>
        /// 비교검색시 시작일자 (TimeSelect=6=다년,7=년,8=월,9=일)
        /// </summary>
        public string FromDT2 { get; set; }
        /// <summary>
        /// 비교검색시 종료일자
        /// </summary>
        public string ToDT2 { get; set; }

        /// <summary>
        /// 이력데이터 시간구간 지정값
        /// </summary>
        public string IntervalMin { get; set; }

        /// <summary>
        /// 무인수 생성자
        /// </summary>
        public TimePeriod()
        {
            this.TimeSelect = 2;
            this.FromDT = string.Empty;
            this.ToDT = string.Empty;
            this.FromDT2 = string.Empty;
            this.ToDT2 = string.Empty;

            this.IntervalMin = string.Empty;
        }

        /// <summary>
        /// 복사생성자
        /// </summary>
        /// <param name="tp"></param>
        public TimePeriod(TimePeriod tp)
        {
            this.TimeSelect = tp.TimeSelect;
            this.FromDT = tp.FromDT;
            this.ToDT = tp.ToDT;
            this.FromDT2 = tp.FromDT2;
            this.ToDT2 = tp.ToDT2;

            this.IntervalMin = tp.IntervalMin;

            int m = 0;
            if (int.TryParse(tp.IntervalMin, out m))
            {
                if (m <= 3)
                {
                    this.IntervalMin = "";
                }
            }
        }

        /// <summary>
        /// 차트의 X축상에 출력할 시간문자열
        /// </summary>
        private string TimeSelectStr
        {
            get
            {
                if (SystemSettings.IsEnglish)
                {
                    switch (TimeSelect)
                    {

                        case 0:
                        case 1: return "Month"; // "년";
                        case 2: return "Day"; //"월";
                        case 3: return "Hour"; //"일";
                        case 4: return "Day"; //"일(기간)";
                        case 5: return "Month"; //"주기";

                        case 6: return "Year"; //"다년";

                        case 7: return "Month"; //"년 (비교)";  // Dual
                        case 8: return "Day"; //"월 (비교)";
                        case 9: return "Hour"; //"일 (비교)";

                        case 10: return "Minute"; //"분";

                        case 12: return "Hour"; //"일";  

                        case 101: return "Year"; // 이력 년도 추가분
                        case 102: return "Month"; // 이력 년도
                        case 103: return "Day"; // 이력 년도
                        case 104: return "Hour"; // 이력 년도
                        case 105: return "Minute"; // 이력 년도

                        default: return "Term";
                    }
                }
                else
                {
                    switch (TimeSelect)
                    {
                        case 0:
                        case 1: return "월"; // "년";
                        case 2: return "일"; //"월";
                        case 3: return "시간"; //"일";
                        case 4: return "일"; //"일(기간)";
                        case 5: return "월"; //"주기";

                        case 6: return "년"; //"다년";

                        case 7: return "월"; //"년 (비교)";  // Dual
                        case 8: return "일"; //"월 (비교)";
                        case 9: return "시"; //"일 (비교)";

                        case 10: return "분"; //"분";

                        case 12: return "시간"; //"일";

                        case 101: return "년"; // 이력 년도 추가분
                        case 102: return "월"; // 이력 년도
                        case 103: return "일"; // 이력 년도
                        case 104: return "시"; // 이력 년도
                        case 105: return "분"; // 이력 년도

                        default: return "기간";
                    }
                }
            }
        }


        /// <summary>
        /// 설  명 : DB에서 읽어온 일자를, 현재조건에 따라 출력유형에 맞춰 변환한다.
        /// - "2010-01-01" 날자값을 선택된 YMD형태로 변환
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <param name="timeStampStr">시간문자열</param>
        /// <returns></returns>
        public string GetTimerStr(string timeStampStr)
        {
            return TimePeriod.GetTimerStr(this.TimeSelect, timeStampStr);
        }


        /// <summary>
        /// 설  명 : DB에서 읽어온 일자를, 현재조건에 따라 출력유형에 맞춰 변환한다.
        /// - "2010-01-01" 날자값을 선택된 YMD형태로 변환
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <param name="timeSelect">시간유형</param>
        /// <param name="timeStampStr">시간문자열</param>
        /// <returns></returns>
        public static string GetTimerStr(int timeSelect, string timeStampStr)
        {
            switch (timeSelect)
            {
                case 0: return timeStampStr;
                case 1: return timeStampStr.Substring(5, 2);    // 년    ->월단위
                case 2: return timeStampStr.Substring(8, 2);    // 월    ->일단위
                case 3: return timeStampStr.Substring(11, 2);   // 일    -> 시단위
                case 4: return timeStampStr.Substring(0, 10);   // 일(기간) -> 일단위    <- 년도를 걸칠 수 있음..
                case 5: return timeStampStr.Substring(5, 2) + (SystemSettings.IsEnglish ? "Month" : "월"); // 주기 -> 월단위

                case 6: return timeStampStr.Substring(0, 4);    // 다년   -> 년단위

                case 7: return timeStampStr.Substring(5, 2);    // 년(비교) -> 월단위
                case 8: return timeStampStr.Substring(8, 2);   // 월(비교) -> 일단위
                case 9: return timeStampStr.Substring(11, 2);   // 일(비교) -> 시단위

                case 10: return timeStampStr.Substring(0, 16);  // 분(비교) -> 분단위   <- 년도를 걸칠 수 있음..

                case 12: return timeStampStr.Substring(11, 2);   // 일    -> 시단위

                case 101: return timeStampStr.Substring(0, 4); // 년    ->년단위
                case 102: return timeStampStr.Substring(0, 7); // 월    ->년-월 단위
                case 103: return timeStampStr.Substring(0, 10); // 일    ->년-월-일 단위
                case 104: return timeStampStr.Substring(0, 13); // 시    ->년-월-일 시 단위
                case 105: return timeStampStr.Substring(0, 16); // 분    ->년-월-일 시:분 단위

                //default: return timeStampStr.Substring(5, 2) + (SystemSettings.IsEnglish ? "Month" : "월"); // ???
                default: return timeStampStr;
            }
        }

        /// <summary>
        /// 설  명 : 캐시키로 활용
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(ToDT2))
            {
                return String.Format("{0}:{1}~{2},{3}~{4}{5}", this.TimeSelectStr, FromDT, ToDT, FromDT2, ToDT2, IntervalMin);
            }
            else if (!String.IsNullOrEmpty(FromDT2))
            {
                return String.Format("{0}:{1}~{2},{3}{4}", this.TimeSelectStr, FromDT, ToDT, FromDT2, IntervalMin);
            }
            else if (!String.IsNullOrEmpty(ToDT))
            {
                return String.Format("{0}:{1}~{2}{3}", this.TimeSelectStr, FromDT, ToDT, IntervalMin);
            }
            else
            {
                return String.Format("{0}:{1}{2}", this.TimeSelectStr, FromDT, IntervalMin);
            }
        }

        /// <summary>
        /// 설  명 : Json형식의 문자열을 TimePeriod인스턴스로 파싱
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <param name="timePeriodJson">json 형태의 기간조건</param>
        /// <returns></returns>
        public static TimePeriod GetTimePeriodParseJson(string timePeriodJson)
        {
            if (string.IsNullOrEmpty(timePeriodJson)) return null;

            // "TimeSelect=" + timeSelect + "&FromDT=" + fromDT + "&ToDT=" + toDT + "&FromDT2=" + fromDT2 + "&ToDT2=" + toDT2;

            // '{"TimeSelect":' + timeSelect + ',"FromDT":"' + fromDT + '","ToDT":"' + toDT + '","FromDT2":"' + fromDT2 + '","ToDT2":"' + toDT2 + '"}';
            // '{"pid":"<%=WPID %>","calculationName":"<%=CalculationName %>","timePeriod":' + timePeriodJson + '}';
            var strTime = timePeriodJson;

            try
            {
                var tp = new TimePeriod();
                tp.TimeSelect = CommonLib.IsNullInt32(Util.SubString(strTime, "\"TimeSelect\":", ","));
                tp.FromDT = Util.SubString(strTime, "\"FromDT\":\"", "\"");
                tp.ToDT = Util.SubString(strTime, "\"ToDT\":\"", "\"");
                tp.FromDT2 = Util.SubString(strTime, "\"FromDT2\":\"", "\"");
                tp.ToDT2 = Util.SubString(strTime, "\"ToDT2\":\"", "\"");
                tp.IntervalMin = Util.SubString(strTime, "\"IntervalMin\":\"", "\"");
                return tp;
            }
            catch (Exception)
            {
                //Log.WriteLog(ex);
            }

            return null;
        }

        /// <summary>
        /// 설  명 : DB조회시 입력될 일자문자열 포맷을 정리하는 함수
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        public void ConvertLogTime()
        {
            var fromDT = ParseExactDateTime(FromDT);
            FromDT = fromDT.ToString("yyyyMMddHHmmss");
            ToDT = ParseExactDateTime(TimeSelect, fromDT, ToDT).ToString("yyyyMMddHHmmss");

            if (!(TimeSelect <= 4 || TimeSelect == 0 || TimeSelect == 6 || TimeSelect == 10 || TimeSelect == 12))
            {
                if (!String.IsNullOrEmpty(FromDT2) && !String.IsNullOrEmpty(ToDT2))
                {
                    var fromDT2 = ParseExactDateTime(FromDT2);
                    FromDT2 = fromDT2.ToString("yyyyMMddHHmmss");
                    ToDT2 = ParseExactDateTime(TimeSelect, fromDT2, ToDT2).ToString("yyyyMMddHHmmss");
                }
            }

            //var fromDT = timePeriod.FromDT.Replace("-", "").Replace(" ", "").Replace(":", "");
            //var toDT = timePeriod.ToDT.Replace("-", "").Replace(" ", "").Replace(":", "");
            //var fromDT2 = timePeriod.FromDT2.Replace("-", "").Replace(" ", "").Replace(":", "");
            //var toDT2 = timePeriod.ToDT2.Replace("-", "").Replace(" ", "").Replace(":", "");

            // Group에 따라 LogTime의 길이를 맞춘다.
            // 2013
            // 201301
            // 20130129
            // 2013012917
            FromDT = SubString(FromDT, DateSize);
            ToDT = SubString(ToDT, DateSize);

            if (!(TimeSelect <= 4 || TimeSelect == 0 || TimeSelect == 6 || TimeSelect == 10 || TimeSelect == 12))
            {
                FromDT2 = SubString(FromDT2, DateSize);
                ToDT2 = SubString(ToDT2, DateSize);
            }
        }

        /// <summary>
        /// 시간조건에 따른 시간문자열 길이
        /// </summary>
        public int DateSize
        {
            get
            {
                var dateSize = 4;
                if (Group == 1) dateSize = 4;
                else if (Group == 2 || Group == 6) dateSize = 6;
                else if (Group == 3) dateSize = 8;
                else if (Group == 4) dateSize = 10;
                else if (Group == 5) dateSize = 12;
                return dateSize;
            }
        }

        /// <summary>
        /// 시간조건에 따른 조회단위
        ///  - 0=연간(년단위), 1=년(월단위), 2=월(일단위), 3=일(시단위), 4=일기간(일단위), 5=절기(월단위), 6-다년(년단위), 7=년비교, 8=월비교, 9=일비교, 10=분
        /// </summary>
        public int Group
        {
            get
            {
                var group = 0;
                if (this.TimeSelect == 0) group = 1; // 년단위
                else if (this.TimeSelect == 1 || this.TimeSelect == 102) group = 2; // 월단위
                else if (this.TimeSelect == 2 || this.TimeSelect == 4 || this.TimeSelect == 103) group = 3;  // 일단위
                else if (this.TimeSelect == 3 || this.TimeSelect == 104 || this.TimeSelect == 12) group = 4; // 시단위
                else if (this.TimeSelect == 6 || this.TimeSelect == 101) group = 1; // 년단위   다년 (비교) 
                else if (this.TimeSelect == 7) group = 2; // 월단위   년 (비교) 
                else if (this.TimeSelect == 8 || this.TimeSelect == 4) group = 3;  // 일단위  월 (비교)
                else if (this.TimeSelect == 9) group = 4; // 시단위   일 (비교)
                else if (this.TimeSelect == 10 || this.TimeSelect == 105) group = 5;  // 분단위 (기본샘플링)
                else if (this.TimeSelect == 5) group = 6;  // 절기(월단위)
                return group;
            }
        }

        /// <summary>
        /// 설  명 : 문자열을 자르는 함수
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="size">크기</param>
        /// <returns>문자열</returns>
        private string SubString(string str, int size)
        {
            if (str.Length > size) return str.Substring(0, size);
            return str;
        }

        // <summary>
        /// 설  명 : 날짜 설정
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <param name="str">날짜형식문자열</param>
        /// <returns>날짜</returns>
        public static DateTime ParseExactDateTime(string str)
        {
            // str = str.Replace("NaN", "");

            DateTime d = DateTime.MinValue;
            if (DateTime.TryParse(str, out d))
            {
                return d;
            }

            var s = str.Replace("-", "").Replace(":", "").Replace(" ", "").Trim();

            if (DateTime.TryParseExact(s, "yyyyMMddHHmmss".Substring(0, s.Length), System.Globalization.CultureInfo.CurrentUICulture, System.Globalization.DateTimeStyles.None, out d))
            {
                return d;
            }

            var msgformat = SystemSettings.IsEnglish ? "'{0}' Can't parse datetime type." : "'{0}'문자열을 날짜형식으로 파싱할 수 없습니다.";
            throw new Exception(String.Format(msgformat, str));

        }

        /// <summary>
        /// 설  명 : 날짜 설정
        /// 작성자 : 윤나영
        /// 작성일 : 2012년 08월 10일
        /// </summary>
        /// <param name="timeSelect">시간조건</param>
        /// <param name="fromDT">시작날짜</param>
        /// <param name="toDT">종료날짜</param>
        /// <returns>날짜</returns>
        public static DateTime ParseExactDateTime(int timeSelect, DateTime fromDT, string toDT)
        {
            if (String.IsNullOrEmpty(toDT))
            {
                if (timeSelect == 1 || timeSelect == 7 || timeSelect == 0 || timeSelect == 6) return fromDT.AddYears(1);
                if (timeSelect == 2 || timeSelect == 8) return fromDT.AddMonths(1);
                if (timeSelect == 3 || timeSelect == 4 || timeSelect == 9 || timeSelect == 12) return fromDT.AddDays(1);
                if (timeSelect == 5)
                {
                    // -- 절기 (하절기 7~8월, 동절기 1~2월 & 11~12월, 간절기 3~6월 & 9~10월)   월단위
                    if (fromDT.Month == 7) return fromDT.AddMonths(2);
                    if (fromDT.Month == 1) return fromDT.AddMonths(2);
                    if (fromDT.Month == 3) return fromDT.AddMonths(4);
                    if (fromDT.Month == 9) return fromDT.AddMonths(2);
                }
            }

            return ParseExactDateTime(toDT);
        }
    }

    public class SystemSettings
    {
        // 기본 DB 접속 및 명령 타임아웃
        public static int ConnectTimeout = 60 * 6; // 3분 // or CommandTimeOut

        // 기본 캐시 유지시간 - 장시간
        public static int CacheTimeOutSec = 60 * 60;

        // 다국어 설정
        public static bool IsEnglish = false;
    }
}
