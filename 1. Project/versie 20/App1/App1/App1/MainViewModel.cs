﻿using System;
using System.Collections.Generic;
using System.Text;
//using Plugin.Share;
using System.Collections.ObjectModel;
using App1.DATA;
using App1.Models_data_;
using App1;


namespace App1
{
    class MainViewModel
    {
        public ObservableCollection<YT> YoutubeI { get; set; }
        public MainViewModel()
        {
            YoutubeI = new ObservableCollection<YT>
            {
                new YT
                {   YTLink = "d8t6hGWoZNw",
                    YTTitle = "Pullup example"
                },
                 new YT
                {
                    YTLink = "hFameePgVH8",
                    YTTitle = "Deadlift example"
                },
                 new YT
                {
                    YTLink = "KsetEPNBEeg",
                    YTTitle = "Bench press example"
                },
                new YT
                {
                    YTLink = "_M2Etme-tfE&t=1s",
                    YTTitle = "Crunches example"
                },
            };
        }
    }
}
