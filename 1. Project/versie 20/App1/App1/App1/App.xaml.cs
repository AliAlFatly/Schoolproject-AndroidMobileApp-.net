using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1.Models_data_;
using SQLite;
using App1.DATA;

using Xamarin.Forms;

namespace App1
{

	public partial class App : Application
	{
        static CPDatabase database;
        //static APDatabase databaseA;

        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Main());
		}
        //t
        public static CPDatabase Database
        {
            get
            {
                if ( database == null)
                {
                    database = new CPDatabase(DependencyService.Get<DSQLite>().GetLocalFilePath("CP.db3"));
                }
                return database;
            }        

        }


        //public static APDatabase DatabaseA
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            databaseA = new APDatabase(DependencyService.Get<DSQLite>().GetLocalFilePath("AP.db3"));
        //        }
        //        return databaseA;
        //    }

        //}

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}




	}
}
