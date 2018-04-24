using GalaSoft.MvvmLight.Command;
using LogIn.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogIn.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
            
        }

        private void Navigate()
        {
            if (this.PageName.Equals("LoginPage"))
            {
                Application.Current.MainPage = new LoginPage();
            }
        }
        #endregion
    }
}
