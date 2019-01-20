using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models_data_
{
    public class CP
    {
        [PrimaryKey, AutoIncrement]
        public int cNum { get; set; }

        public string cNam { get; set; }
        //name
        public int cW { get; set; }
        //weight
        public int cH { get; set; }
        //height
        public string cPal { get; set; }
        //activity/pal
        public string cG { get; set; }
        //gender
        public string cPlan { get; set; }
        //plan
        public DateTime cD { get; set; } 
        //deadlift
        public double cDL { get; set; }
        ////squat
        //public int cSQT { get; set; }
        ////bench
        //public int cBNC { get; set; }

    }
}
