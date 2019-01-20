﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.DATA;
using App1.Models_data_;
using App1;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;


namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlan : TabbedPage
    {
        public AddPlan()
        {
            InitializeComponent();
            P1PG.Items.Add("Male");
            P1PG.Items.Add("Female");
            //--------------------------------------------------------------------------
            P1PP.Items.Add("0.05 kg");
            P1PP.Items.Add("0.10 kg");
            P1PP.Items.Add("0.15 kg");
            P1PP.Items.Add("0.20 kg");

            //--------------------------------------------------------------------------
            P1PcPal.Items.Add("Low activity");
            P1PcPal.Items.Add("Medium activity");
            P1PcPal.Items.Add("Highly active");

            P2PG.Items.Add("Male");
            P2PG.Items.Add("Female");
            //--------------------------------------------------------------------------
            P2PP.Items.Add("0.1 kg");
            P2PP.Items.Add("0.2 kg");
            P2PP.Items.Add("0.3 kg");
            P2PP.Items.Add("0.4 kg");

            ////--------------------------------------------------------------------------
            P2PcPal.Items.Add("Low activity");
            P2PcPal.Items.Add("Medium activity");
            P2PcPal.Items.Add("Highly active");


            DateTime minD = DateTime.Now;
        }

        //--------------------------------------------------------------------------

        private void InfoBtnName_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("1"));
        }

        private void InfoBtnName2_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("1"));
        }

        private void InfoBtnWeight_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("2"));
        }

        private void InfoBtnWeight2_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("2"));
        }

        private void InfoBtnHeight_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("3"));
        }

        private void InfoBtnHeight2_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("3"));
        }

        private void InfoBtnPlan1_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("5"));
        }

        private void InfoBtnPlan2_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("4"));
        }

        private void InfoBtnPal_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("6"));
        }

        private void InfoBtnPal2_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("6"));
        }

        private void InfoBtnGender_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("7"));
        }

        private void InfoBtnGender2_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("7"));
        }

        private void PG1_OSPcPal(object sender, EventArgs e)
        {
            var P1Pal = P1PcPal.Items[P1PcPal.SelectedIndex];

            DisplayAlert(P1Pal, "Selected value", "Ok");

        }

        private void PG1_OSPcG(object sender, EventArgs e)
        {
            var P1Gender = P1PG.Items[P1PG.SelectedIndex];

            DisplayAlert(P1Gender, "Selected value", "Ok");

        }

        private void PG1_OSPcPlan(object sender, EventArgs e)
        {
            var P1Plan = P1PP.Items[P1PP.SelectedIndex];

            DisplayAlert(P1Plan, "Selected value", "Ok");
        }

        //--------------------------------------------------------------------------

        private void PG2_OSPcPal(object sender, EventArgs e)
        {
            var P2Pal = P2PcPal.Items[P2PcPal.SelectedIndex];

            DisplayAlert(P2Pal, "Selected value", "Ok");

        }

        private void PG2_OSPcG(object sender, EventArgs e)
        {
            var P2Gender = P2PG.Items[P2PG.SelectedIndex];

            DisplayAlert(P2Gender, "Selected value", "Ok");

        }

        //private void PG2_OSPcDL(object sender, EventArgs e)
        //{
        //    var P2DLT = P2DL.Items[P2DL.SelectedIndex];

        //    DisplayAlert(P2DLT, "Selected value", "Ok");

        //}

        //private void PG2_OSPcSQT(object sender, EventArgs e)
        //{
        //    var P2SQTT = P2SQT.Items[P2SQT.SelectedIndex];

        //    DisplayAlert(P2SQTT, "Selected value", "Ok");

        //}

        //private void PG2_OSPcBNC(object sender, EventArgs e)
        //{
        //    var P2BNCT = P2BNC.Items[P2BNC.SelectedIndex];

        //    DisplayAlert(P2BNCT, "Selected value", "Ok");

        //}

        private void PG2_OSPcPlan(object sender, EventArgs e)
        {
            var P2Plan = P2PP.Items[P2PP.SelectedIndex];

            DisplayAlert(P2Plan, "Selected value", "Ok");
        }

        //---

        async void PG1_Btn_Save(object sender, System.EventArgs e)
        {
            CP NCPI = (CP)BindingContext;
            if (NCPI.cNam == null)
            {
                await DisplayAlert("Please entere a planname", "Field planname is empty", "Ok");
            }
            else if (NCPI.cW <= 0 || NCPI.cW > 300)
            {
                await DisplayAlert("Please entere your current weight", "See tooltip for more information, entered weight might be invalid", "Ok");
            }
            else if (NCPI.cH <= 0 || NCPI.cH > 260)
            {
                await DisplayAlert("Please entere your current height", "See tooltip for more information, entered height might be invalid", "Ok");
            }
            else if (NCPI.cPal == null)
            {
                await DisplayAlert("Please select your activity", "You have not yet selected ur daily activity amount", "Ok");
            }
            else if (NCPI.cG == null)
            {
                await DisplayAlert("Please select your gender", "You have not yet selected your gender", "Ok");
            }
            else if (NCPI.cPlan == null)
            {
                await DisplayAlert("Please select your plan", "You have not yet selected your plan", "Ok");
            }
            else if (NCPI.cD == null)
            {
                await DisplayAlert("Please select your start date", "You have not yet selected your start date", "Ok");
            }
            else
            {
                await App.Database.SaveCPAsync(NCPI);
                await Navigation.PopAsync();
            }
        }

        async void PG1_Btn_Cancel(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void PG2_Btn_Save(object sender, System.EventArgs e)
        {
            CP NCPI = (CP)BindingContext;
            if (NCPI.cNam == null)
            {
                await DisplayAlert("Please entere a planname", "Field planname is empty", "Ok");
            }
            else if (NCPI.cW <= 0 || NCPI.cW > 300)
            {
                await DisplayAlert("Please entere your current weight", "See tooltip for more information, entered weight might be invalid", "Ok");
            }
            else if (NCPI.cH <= 0 || NCPI.cH > 260)
            {
                await DisplayAlert("Please entere your current height", "See tooltip for more information, entered height might be invalid", "Ok");
            }
            else if (NCPI.cPal == null)
            {
                await DisplayAlert("Please select your activity", "You have not yet selected ur daily activity amount", "Ok");
            }
            else if (NCPI.cG == null)
            {
                await DisplayAlert("Please select your gender", "You have not yet selected your gender", "Ok");
            }
            else if (NCPI.cPlan == null)
            {
                await DisplayAlert("Please select your plan", "You have not yet selected your plan", "Ok");
            }
            else if (NCPI.cD == null)
            {
                await DisplayAlert("Please select your start date", "You have not yet selected your start date", "Ok");
            }
            else if (NCPI.cDL <= 0 || NCPI.cDL >= 500)
            {
                await DisplayAlert("Please entere your maximum deadlift", "", "Ok");
            }
            else
            {
                await App.Database.SaveCPAsync(NCPI);
                await Navigation.PopAsync();
            }

            //string text = P2C.Text;
            //P2C.Text = "Confirmed";
            //var NAPI = (AP)BindingContext;
            //var NCPI = (CP)BindingContext;
            //NCPI = new CP(current plan model) item
            //await App.Database.SaveAPAsync(NAPI);
            //await App.Database.SaveCPAsync(NCPI);
            //await Navigation.PopAsync();
        }

        async void PG2_Btn_Cancel(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }   


    }
}