using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models_data_
{
    public class YT
    {

        [PrimaryKey, AutoIncrement]
        public int YTNum { get; set; }

        public string YTLink{ get; set; }

        public string YTTitle { get; set; }
    }
}
