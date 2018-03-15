using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Equip4
{
	public partial class App : Application
	{
        #region Constructors
        public App ()
		{
			InitializeComponent();

			this.MainPage = new NavigationPage( new LoginPage());
		}
        #endregion

        #region Methods
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
        #endregion
    }
}
