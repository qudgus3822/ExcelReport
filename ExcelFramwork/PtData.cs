using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFramwork
{
    public class PtData
    {

        public PtData()
        {
            this.AllPointAddress = new List<string>();
            this.Formulas = "";
            this.Gubun = new List<string>();
            this.Cols = "";

        }
        public List<string> Gubun { get; set; }

        //public string Cols
        //{
        //    get
        //    {
        //        var str = String.Empty;

        //        foreach (var address in AllPointAddress)
        //        {
        //            str += "[" + address + "],";
        //        }

        //        if (str.Length > 2) str = str.Remove(str.Length - 1); // , 콤마제거
        //        return str;
        //    }
        //}

        public string Formulas { get; set; }

        public List<string> AllPointAddress
        {
            get; set;
        }

        public string Cols
        {
            get; set;
        }
    }

    public class Formula
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public string ResultHistory { get; set; }
    }
}

