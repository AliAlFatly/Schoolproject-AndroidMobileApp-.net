using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupView : Rg.Plugins.Popup.Pages.PopupPage
	{

        string PUT;
		public PopupView (string init)
		{
			InitializeComponent ();

            if (init == "1")
            {
                PUT = "Plan name";
            }
            else if (init == "2")
            {
                PUT = "Entere your current weight in kg, minimum weight is 1 kg and maximum weight is 300 kg";
            }
            else if (init == "3")
            {
                PUT = "Entere your current Height in cm minimum height is 1cm and maximum height is 260 cm";
            }
            else if(init == "4")
            {
                PUT = "What is your Goal? select how much weight you want to loss";
            }
            else if(init == "5")
            {
                PUT = "what is your Goal? select how much weight you want to gain";
            }
            else if (init == "6")
            {
                PUT = "Select your usual daily activity amount";
            }
            else if (init == "7")
            {
                PUT = "Select your biological Gender";
            }



            PopUpLabel.Text = PUT;
        }
	}
}