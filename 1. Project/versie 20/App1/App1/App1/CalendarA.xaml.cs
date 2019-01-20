using System;
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

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarA : TabbedPage
    {
        public CP plan;
        public CalendarA(CP p)
        {
            InitializeComponent();
            plan = p;

            P2PG.Items.Add("Male");
            P2PG.Items.Add("Female");
            //--------------------------------------------------------------------------
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")
            {

                PPAGE.Title = "Weight loss";
                P2PP.Items.Add("0.05 kg");
                P2PP.Items.Add("0.10 kg");
                P2PP.Items.Add("0.15 kg");
                P2PP.Items.Add("0.20 kg");
                //Picker P2PcPal = new Picker { SelectedItem = "{Binding cPal}" x:Name = "P2PcPal" SelectedIndexChanged = "PG2_OSPcPal" Grid.Row = "3" Grid.Column = "2" Grid.ColumnSpan = "3"};
                //Picker P2PcPal = new Picker();
                //P2PcPal.SelectedItem = "{Binding cPal}";
                //P2PcPal.
            }
            else
            {
                PPAGE.Title = "Power training";
                P2PP.Items.Add("0.1 kg");
                P2PP.Items.Add("0.2 kg");
                P2PP.Items.Add("0.3 kg");
                P2PP.Items.Add("0.4 kg");

            }


            //--------------------------------------------------------------------------
            P2PcPal.Items.Add("Low activity");
            P2PcPal.Items.Add("Medium activity");
            P2PcPal.Items.Add("Highly active");

            DateTime acD = plan.cD;
            string acD1 = acD.ToString();
            kbtn1.Text = acD1;
            string acD2 = acD.AddDays(+1).ToString();
            kbtn2.Text = acD2;
            string acD3 = acD.AddDays(+2).ToString();
            kbtn3.Text = acD3;
            string acD4 = acD.AddDays(+3).ToString();
            kbtn4.Text = acD4;
            string acD5 = acD.AddDays(+4).ToString();
            kbtn5.Text = acD5;
            string acD6 = acD.AddDays(+5).ToString();
            kbtn6.Text = acD6;
            string acD7 = acD.AddDays(+6).ToString();
            kbtn7.Text = acD7;
            string acD8 = acD.AddDays(+7).ToString();
            kbtn8.Text = acD8;
            string acD9 = acD.AddDays(+8).ToString();
            kbtn9.Text = acD9;
            string acD10 = acD.AddDays(+9).ToString();
            kbtn10.Text = acD10;

            KL1.Text = "";



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

        private void InfoBtnName_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("1"));
        }

        private void InfoBtnWeight_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("2"));
        }

        private void InfoBtnHeight_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("3"));
        }

        private void InfoBtnPal_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("6"));
        }

        private void InfoBtnGender_OC(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView("7"));
        }

        private void PG2_OSPcPlan(object sender, EventArgs e)
        {
            var P2Plan = P2PP.Items[P2PP.SelectedIndex];

            DisplayAlert(P2Plan, "Selected value", "Ok");
        }

        //--------------------------------------------------------------------------

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
            else
            {
                await App.Database.SaveCPAsync(NCPI);
                await Navigation.PopAsync();
            }

            //CP NCPI = (CP)BindingContext;
            //await App.Database.SaveCPAsync(NCPI);
            //await Navigation.PopAsync();

        }

        async void PG2_Btn_Delete(object sender, System.EventArgs e)
        {
            CP NCPID = (CP)BindingContext;
            //object APID = NCPID;
            //AP APF = (AP)APID;
            //await App.Database.SaveAPAsync(APF);
            //await App.DatabaseA.SaveAPAsync(NCPI);
            await App.Database.DeleteCPAsync(NCPID);
            await Navigation.PopAsync();
        }

        public void Btn1_C(object sender, EventArgs e)
        {
            //if (plan.cPlan == "0.2 kg" || plan.cPlan == "0.3 kg" || plan.cPlan == "0.4 kg" || plan.cPlan == "0.5 kg" || plan.cPlan == "0.6 kg")
            int d = 1;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn2_C(object sender, EventArgs e)
        {
            int d = 2;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn3_C(object sender, EventArgs e)
        {
            int d = 3;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn4_C(object sender, EventArgs e)
        {
            int d = 4;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn5_C(object sender, EventArgs e)
        {
            int d = 5;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn6_C(object sender, EventArgs e)
        {
            int d = 6;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn7_C(object sender, EventArgs e)
        {
            int d = 7;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn8_C(object sender, EventArgs e)
        {
            int d = 8;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn9_C(object sender, EventArgs e)
        {
            int d = 9;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        public void Btn10_C(object sender, EventArgs e)
        {
            int d = 10;
            double KF1 = 0.40;
            double KF2 = 0.25;
            double KF3 = 0.35;

            double PF1 = 0.45;
            double PF2 = 0.30;
            double PF3 = 0.35;

            double FF1 = 0.35;
            double FF2 = 0.20;
            double FF3 = 0.45;
            if (plan.cPlan == "0.05 kg" || plan.cPlan == "0.10 kg" || plan.cPlan == "0.15 kg" || plan.cPlan == "0.20 kg")

            {
                nKcal i1 = new nKcal(plan);
                nProtein i2 = new nProtein(plan);
                nFat i3 = new nFat(plan);

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwk(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string prt1 = PI1.ToString("F");
                string fat1 = FI1.ToString("F");

                string kc2 = KI2.ToString("F");
                string prt2 = PI2.ToString("F");
                string fat2 = FI2.ToString("F");

                string kc3 = KI3.ToString("F");
                string prt3 = PI3.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes and do 3 minutes of crunches";
                //--------------------------------------------------------------------------------------------------------------------//

                string TE = "To eat ";

                KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                KL2.Text = t1;
                KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                KL4.Text = t2;
                KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                KL6.Text = t3;
            }
            else
            {
                ptNKcal i1 = new ptNKcal(plan);
                ptNProtein i2 = new ptNProtein(plan);
                ptNFat i3 = new ptNFat(plan);
                string t1 = "In this period you need to do 3 minutes of squats and 4 minutes of jumping jacks\n\n";
                string t2 = "\n";
                string t3 = "In this period you need to walk for 30 minutes";
                string EU = "Do 8 deadlift sets of 4 reps with your maximum to deadlift weight, And do 12 bench-press sets of 2 reps with your maximum bench-press weight\n";
                string EL = "Do 12 squat sets of 4 reps with your maximum to squat weight, And do 9 pullup sets of 3 reps with your own body weight\n";
                string t4 = "";
                string TE = "To eat ";

                //--------------------------------------------------------------------------------------------------------------------//
                double KCIMAIN = i1.fwkEL(d);
                double KCIMAIN2 = i1.fwkEU(d);
                double KCIMAIN3 = i1.fwkN(d);
                double PRTIMAIN = i2.fwk(d);
                double FATIMAIN = i3.fwk(d);
                //--------------------------------------------------------------------------------------------------------------------//
                double KI1 = KCIMAIN * KF1;
                double KI2 = KCIMAIN * KF2;
                double KI3 = KCIMAIN * KF3;

                double KI1U = KCIMAIN2 * KF1;
                double KI2U = KCIMAIN2 * KF2;
                double KI3U = KCIMAIN2 * KF3;

                double KI1N = KCIMAIN3 * KF1;
                double KI2N = KCIMAIN3 * KF2;
                double KI3N = KCIMAIN3 * KF3;

                double PI1 = PRTIMAIN * PF1;
                double PI2 = PRTIMAIN * PF2;
                double PI3 = PRTIMAIN * PF3;

                double FI1 = FATIMAIN * FF1;
                double FI2 = FATIMAIN * FF2;
                double FI3 = FATIMAIN * FF3;
                //--------------------------------------------------------------------------------------------------------------------//
                string kc1 = KI1.ToString("F");
                string kc2 = KI2.ToString("F");
                string kc3 = KI3.ToString("F");

                string kc1U = KI1U.ToString("F");
                string kc2U = KI2U.ToString("F");
                string kc3U = KI3U.ToString("F");

                string kc1N = KI1N.ToString("F");
                string kc2N = KI2N.ToString("F");
                string kc3N = KI3N.ToString("F");


                string prt1 = PI1.ToString("F");
                string prt2 = PI2.ToString("F");
                string prt3 = PI3.ToString("F");

                string fat1 = FI1.ToString("F");
                string fat2 = FI2.ToString("F");
                string fat3 = FI3.ToString("F");
                //--------------------------------------------------------------------------------------------------------------------//

                if (d == 1)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 2)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 3)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 4)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 5)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 6)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 7)
                {
                    //upper
                    KL1.Text = TE + "Kcal: " + kc1U + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EU;
                    KL3.Text = TE + "Kcal: " + kc2U + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3U + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 8)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 9)
                {
                    //lower
                    KL1.Text = TE + "Kcal: " + kc1 + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = EL;
                    KL3.Text = TE + "Kcal: " + kc2 + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3 + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
                else if (d == 10)
                {
                    //geen training
                    KL1.Text = TE + "Kcal: " + kc1N + "\n" + TE + "protein: " + prt1 + "\n" + TE + "fats: " + fat1;
                    KL2.Text = t4;
                    KL3.Text = TE + "Kcal: " + kc2N + "\n" + TE + "protein: " + prt2 + "\n" + TE + "fats: " + fat2;
                    KL4.Text = t3;
                    KL5.Text = TE + "Kcal: " + kc3N + "\n" + TE + "protein: " + prt3 + "\n" + TE + "fats: " + fat3;
                    KL6.Text = t4;
                }
            }
        }

        //async void PG2_Btn_Cancel(object sender, System.EventArgs e)
        //{
        //    await Navigation.PopAsync();
        //}

        public class nKcal : CalendarA
        {
            public int w;
            public int h;
            public string pal;
            public string g;
            public string p;


            public nKcal(CP initp) : base(initp)
            {
                this.w = initp.cW;
                this.h = initp.cH;
                this.pal = initp.cPal;
                this.g = initp.cG;
                this.p = initp.cPlan;

            }

            public double Bkcal()
            {
                double kcal;
                double MaMul = 2.84;
                double MaMul2 = 0.064;
                double Deler = 4.20;
                double VrMul = 2.08;
                double VrMul2 = 0.0615;
                double MaBaseKJ;
                double VrBaseKJ;

                if (this.g == "Male")
                {
                    if (this.pal == "Low activity")
                    {
                        MaBaseKJ = ((MaMul + MaMul2) * this.w) * 1000;
                        kcal = (MaBaseKJ / Deler);
                        kcal = kcal * 1.4;
                    }
                    else if (this.pal == "Medium activity")
                    {
                        MaBaseKJ = (MaMul + MaMul2 * this.w) * 1000;
                        kcal = (MaBaseKJ / Deler);
                        kcal = kcal * 1.6;
                    }
                    else
                    {
                        MaBaseKJ = (MaMul + MaMul2 * this.w) * 1000;
                        kcal = (MaBaseKJ / Deler);
                        kcal = kcal * 1.8;
                    }
                }

                else
                {
                    if (this.pal == "Low activity")
                    {
                        VrBaseKJ = (VrMul + VrMul2 * this.w) * 1000;
                        kcal = (VrBaseKJ / Deler);
                        kcal = kcal * 1.4;
                    }
                    else if (this.pal == "Medium activity")
                    {
                        VrBaseKJ = (VrMul + VrMul2 * this.w) * 1000;
                        kcal = (VrBaseKJ / Deler);
                        kcal = kcal * 1.6;
                    }
                    else
                    {
                        VrBaseKJ = (VrMul + VrMul2 * this.w) * 1000;
                        kcal = (VrBaseKJ / Deler);
                        kcal = kcal * 1.8;
                    }
                }

                return kcal;
            }

            public double WlKcal()  // final kcalc
            {
                double LKcalc = this.Bkcal();
                double SKcalc;
                double KcalcD;              //kcalc diet (how much less intake) a day
                double WF = 0.035;          //walk factor*gewicht*minuten           30 minuten           
                double SF = 0.096;          //Squat factor*gewicht*minuten          3 minuten                                           
                double CF = 0.53;           //crunches factor*gewicht*minuten       3 minuten         
                double JJF = 0.076;         //Jumping jacks factor*gewicht*minuten  4 minuten 
                double KGF = 7700.00;       //1 KG = KGF kcal
                int period = 10;


                SKcalc = this.w * ((WF * 30) + (SF * 3) + (CF * 3) + (JJF * 4));
                LKcalc = LKcalc + SKcalc;

                if (this.p == "0.05 kg")
                {
                    KcalcD = (KGF * 0.05) / period;

                }
                else if (this.p == "0.10 kg")
                {
                    KcalcD = (KGF * 0.10) / period;
                }
                else if (this.p == "0.15 kg")
                {
                    KcalcD = (KGF * 0.15) / period;
                }
                else
                {
                    KcalcD = (KGF * 0.20) / period;
                }


                LKcalc = LKcalc - KcalcD;
                return LKcalc;

            }

            public double fwk(int D)  // final kcalc
            {
                double wlkalc = this.WlKcal();
                double b1 = Bkcal();
                double bk = Bkcal();
                double fwk = wlkalc;
                double KGF = 7700.00;       //1 KG = KGF kcal
                int period = 10;

                if (this.p == "0.05 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w - ((0.05 / period) * D ))));
                }
                else if (this.p == "0.10 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w - ((0.10 / period) * D))));
                }
                else if (this.p == "0.15 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w - ((0.15 / period) * D))));
                }
                else
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w - ((0.20 / period) * D))));
                }

                return fwk;

            }
        }

        public class nProtein : CalendarA
        {
            public int w;
            public int h;
            public string pal;
            public string g;
            public string p;


            public nProtein(CP initp) : base(initp)
            {
                //this.w = Convert.ToInt32(CW.Text);
                //this.h = Convert.ToInt32(CH.Text);
                //this.w = cW;
                //this.h = cH;
                //this.pal = cPal;
                //this.g = cG;
                //this.p = cPlan;
                this.w = initp.cW;
                this.h = initp.cH;
                this.pal = initp.cPal;
                this.g = initp.cG;
                this.p = initp.cPlan;
            }

            public double WlProtein()
            {
                double WLP;
                double NPFM = 1.60; //needed protein factor 1.60g per 1 kg Male
                double NPFF = 1.50; //needed protein factor 1.50g per 1 kg Female

                if (this.g == "Male")
                {
                    WLP = this.w * NPFM;
                }
                else
                {
                    WLP = this.w * NPFF;
                }

                return WLP;
            }

            public double fwk(int D)  // final protein
            {
                double P = this.WlProtein();
                double fwp = P;
                double b1 = WlProtein();
                double bk = WlProtein();
                int period = 10;

                if (this.p == "0.05 kg")
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w - ((0.05 / period) * D))));
                }
                else if (this.p == "0.10 kg")
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w - ((0.10 / period) * D))));
                }
                else if (this.p == "0.15 kg")
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w - ((0.15 / period) * D))));
                }
                else
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w - ((0.20 / period) * D))));
                }

                return fwp;
            }

        }

        public class nFat : CalendarA
        {
            public int w;
            public int h;
            public string pal;
            public string g;
            public string p;


            public nFat(CP initp) : base(initp)
            {
                //this.w = Convert.ToInt32(CW.Text);
                //this.h = Convert.ToInt32(CH.Text);
                //this.w = cW;
                //this.h = cH;
                //this.pal = cPal;
                //this.g = cG;
                //this.p = cPlan;
                this.w = initp.cW;
                this.h = initp.cH;
                this.pal = initp.cPal;
                this.g = initp.cG;
                this.p = initp.cPlan;
            }

            public double WlFat()
            {
                double WLF;
                double NFFM = 0.69; //needed fat factor 0.69g per 1kg male
                double NFFF = 0.67; //needed fat factor 0.67g per 1kg female
                if (this.g == "Male")
                {
                    WLF = this.w * NFFM;
                }
                else
                {
                    WLF = this.w * NFFF;
                }
                return WLF;
            }

            public double fwk(int D)  // final Fats
            {
                double f = this.WlFat();
                double b1 = this.WlFat();
                double bk = this.WlFat();
                double fwf = f;

                int period = 10;


                if (this.p == "0.05 kg")
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w - ((0.05 / period) * D))));
                }
                else if (this.p == "0.10 kg")
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w - ((0.10 / period) * D))));
                }
                else if (this.p == "0.15 kg")
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w - ((0.15 / period) * D))));
                }
                else
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w - ((0.20 / period) * D))));
                }

                return fwf;
            }

        }


        //--------------------------------------------------------------------------------------------------------------------//
        public class ptNKcal : CalendarA
        {
            public int w;
            public int h;
            public string pal;
            public string g;
            public string p;
            public double DL;
            public double BNC;
            public double SQT;
            public double PU;

            public ptNKcal(CP initp) : base(initp)
            {
                this.w = initp.cW;
                this.h = initp.cH;
                this.pal = initp.cPal;
                this.g = initp.cG;
                this.p = initp.cPlan;
                this.DL = initp.cDL;
                this.BNC = this.DL * 0.8;
                this.PU = this.DL * 0.77;
                this.SQT = this.DL * 0.67;
            }

            public double Bkcal()
            {
                double kcal;
                double MaMul = 2.84;
                double MaMul2 = 0.064;
                double Deler = 4.20;
                double VrMul = 2.08;
                double VrMul2 = 0.0615;
                double MaBaseKJ;
                double VrBaseKJ;

                if (this.g == "Male")
                {
                    if (this.pal == "Low activity")
                    {
                        MaBaseKJ = ((MaMul + MaMul2) * this.w) * 1000;
                        kcal = (MaBaseKJ / Deler);
                        kcal = kcal * 1.4;
                    }
                    else if (this.pal == "Medium activity")
                    {
                        MaBaseKJ = (MaMul + MaMul2 * this.w) * 1000;
                        kcal = (MaBaseKJ / Deler);
                        kcal = kcal * 1.6;
                    }
                    else
                    {
                        MaBaseKJ = (MaMul + MaMul2 * this.w) * 1000;
                        kcal = (MaBaseKJ / Deler);
                        kcal = kcal * 1.8;
                    }
                }

                else
                {
                    if (this.pal == "Low activity")
                    {
                        VrBaseKJ = (VrMul + VrMul2 * this.w) * 1000;
                        kcal = (VrBaseKJ / Deler);
                        kcal = kcal * 1.4;
                    }
                    else if (this.pal == "Medium activity")
                    {
                        VrBaseKJ = (VrMul + VrMul2 * this.w) * 1000;
                        kcal = (VrBaseKJ / Deler);
                        kcal = kcal * 1.6;
                    }
                    else
                    {
                        VrBaseKJ = (VrMul + VrMul2 * this.w) * 1000;
                        kcal = (VrBaseKJ / Deler);
                        kcal = kcal * 1.8;
                    }
                }

                return kcal;
            }

            public double ELowerKcal()  // final kcalc pullup + squat
            {
                double LKcalc = this.Bkcal();
                double SKcalc;
                double KcalcD;              //how much more to take a day

                double SQTF = 0.0471;        //squat factor*gewicht*reps
                double PUF = 0.050;          //pullups factor*gewicht*reps
                double WF = 0.035;          //walk factor*gewicht*minuten           30 minuten           

                double KGF = 1587.57;       //1 KG = KGF kcal
                int period = 10;

                SKcalc = this.w * ((WF * 30) + (SQTF * 48 * this.SQT) + (PUF * 27 * this.PU)); //squat 48 = 4 reps 12 sets, pul ups = 27 3 reps 9 sets
                LKcalc = LKcalc + SKcalc;

                if (this.p == "0.1 kg")
                {
                    KcalcD = (KGF * 0.1) / period;
                }
                else if (this.p == "0.2 kg")
                {
                    KcalcD = (KGF * 0.2) / period;
                }
                else if (this.p == "0.3 kg")
                {
                    KcalcD = (KGF * 0.3) / period;
                }
                else
                {
                    KcalcD = (KGF * 0.4) / period;
                }

                LKcalc = (LKcalc + KcalcD) / period;
                return LKcalc;

            }

            public double EUpperKcal()  // final kcalc pullup + squat
            {
                double LKcalc = this.Bkcal();
                double SKcalc;
                double KcalcD;              //how much more to take a day
                double DLF = 0.051;          //deadlift factor*gewicht*reps
                double BNCF = 0.44;          //bench factor*gewicht*reps
                double WF = 0.035;          //walk factor*gewicht*minuten           30 minuten           

                double KGF = 7700.00;       //1 KG = KGF kcal
                int period = 10;

                SKcalc = this.w * ((WF * 30) + (DLF * 32 * this.DL) + (BNCF * 24 * this.BNC)); //Deadlift 32 = 4 reps 8 sets, Bench= 24 2 reps 12 sets
                LKcalc = LKcalc + SKcalc;


                if (this.p == "0.1 kg")
                {
                    KcalcD = (KGF * 0.1) / period;

                }
                else if (this.p == "0.2 kg")
                {
                    KcalcD = (KGF * 0.2) / period;
                }
                else if (this.p == "0.3 kg")
                {
                    KcalcD = (KGF * 0.3) / period;
                }
                else if (this.p == "0.4 kg")
                {
                    KcalcD = (KGF * 0.4) / period;
                }
                else if (this.p == "0.5 kg")
                {
                    KcalcD = (KGF * 0.5) / period;
                }
                else
                {
                    KcalcD = (KGF * 0.6) / period;
                }

                LKcalc = LKcalc + KcalcD;
                return LKcalc;

            }

            public double NKcal()  // final kcalc pullup + squat
            {
                double LKcalc = this.Bkcal();
                double SKcalc;
                double KcalcD;              //how much more to take a day
     
                double KGF = 7700.77;       //1 KG = KGF kcal
                int period = 10;

                SKcalc = 0;
                LKcalc = LKcalc + SKcalc;

                if (this.p == "0.1 kg")
                {
                    KcalcD = (KGF * 0.1) / period;
                }
                else if (this.p == "0.2 kg")
                {
                    KcalcD = (KGF * 0.2) / period;
                }
                else if (this.p == "0.3 kg")
                {
                    KcalcD = (KGF * 0.3) / period;
                }
                else
                {
                    KcalcD = (KGF * 0.4) / period;
                }

                LKcalc = LKcalc + KcalcD;
                return LKcalc;

            }

            public double fwkEL(int D)  // final kcalc
            {
                double wlkalc = this.ELowerKcal();
                double b1 = Bkcal();
                double bk = Bkcal();
                double fwk = wlkalc;
                int period = 10;

                if (this.p == "0.1 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.05 / period) * D))));
                }
                else if (this.p == "0.2 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.10 / period) * D))));
                }
                else if (this.p == "0.3 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.15 / period) * D))));
                }
                else
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.20 / period) * D))));
                }

                return fwk;

            }

            public double fwkEU(int D)  // final kcalc
            {
                double wlkalc = this.ELowerKcal();
                double b1 = Bkcal();
                double bk = Bkcal();
                double fwk = wlkalc;
                int period = 10;

                if (this.p == "0.1 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.05 / period) * D))));
                }
                else if (this.p == "0.2 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.10 / period) * D))));
                }
                else if (this.p == "0.3 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.15 / period) * D))));
                }
                else
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.20 / period) * D))));
                }

                return fwk;

            }

            public double fwkN(int D)  // final kcalc
            {
                double wlkalc = this.NKcal();
                double b1 = Bkcal();
                double bk = Bkcal();
                double fwk = wlkalc;
                int period = 10;

                if (this.p == "0.1 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.05 / period) * D))));
                }
                else if (this.p == "0.2 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.10 / period) * D))));
                }
                else if (this.p == "0.3 kg")
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.15 / period) * D))));
                }
                else
                {
                    fwk = ((fwk - b1) + (bk / this.w * (this.w + ((0.20 / period) * D))));
                }

                return fwk;

            }

        }

        public class ptNProtein : CalendarA
        {
            public int w;
            public int h;
            public string pal;
            public string g;
            public string p;


            public ptNProtein(CP initp) : base(initp)
            {

                this.w = initp.cW;
                this.h = initp.cH;
                this.pal = initp.cPal;
                this.g = initp.cG;
                this.p = initp.cPlan;
            }

            public double WlProtein()
            {
                double WLP;
                double NPFM = 1.80; //needed protein factor 1.60g per 1 kg Male
                double NPFF = 1.70; //needed protein factor 1.50g per 1 kg Female

                if (this.g == "Male")
                {
                    WLP = this.w * NPFM;
                }
                else
                {
                    WLP = this.w * NPFF;
                }

                return WLP;
            }

            public double fwk(int D)  // final protein
            {
                double P = this.WlProtein();
                double fwp = P;
                double b1 = WlProtein();
                double bk = WlProtein();
                int period = 10;

                if (this.p == "0.1 kg")
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w + ((0.10 / period) * D))));
                }
                else if (this.p == "0.2 kg")
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w + ((0.20 / period) * D))));
                }
                else if (this.p == "0.3 kg")
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w + ((0.30 / period) * D))));
                }
                else
                {
                    fwp = ((fwp - b1) + (bk / this.w * (this.w + ((0.40 / period) * D))));
                }

                return fwp;
            }

        }

        public class ptNFat : CalendarA
        {
            public int w;
            public int h;
            public string pal;
            public string g;
            public string p;


            public ptNFat(CP initp) : base(initp)
            {

                this.w = initp.cW;
                this.h = initp.cH;
                this.pal = initp.cPal;
                this.g = initp.cG;
                this.p = initp.cPlan;
            }

            public double WlFat()
            {
                double WLF;
                double NFFM = 0.741; //needed fat factor 0.69g per 1kg male
                double NFFF = 0.727; //needed fat factor 0.67g per 1kg female
                if (this.g == "Male")
                {
                    WLF = this.w * NFFM;
                }
                else
                {
                    WLF = this.w * NFFF;
                }
                return WLF;
            }

            public double fwk(int D)  // final Fats
            {
                double f = this.WlFat();
                double b1 = this.WlFat();
                double bk = this.WlFat();
                double fwf = f;

                int period = 10;


                if (this.p == "0.1 kg")
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w + ((0.05 / period) * D))));
                }
                else if (this.p == "0.2 kg")
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w + ((0.10 / period) * D))));
                }
                else if (this.p == "0.3 kg")
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w + ((0.15 / period) * D))));
                }
                else
                {
                    fwf = ((fwf - b1) + (bk / this.w * (this.w + ((0.20 / period) * D))));
                }

                return fwf;
            }

        }

    }
}

//a