using GalaSoft.MvvmLight.Command;
using LogIn.Models;
using LogIn.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogIn.ViewModels
{
    public class UsuarioItemViewModel : Usuario
    {
        #region Commands
        public ICommand SelectUsuarioCommand
        {
            get
            {
                return new RelayCommand(SelectUsuario);
            }
        }

        private async void SelectUsuario()
        {
            MainViewModel.GetInstance().Usuario = new UsuarioViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioPage());
        }
        #endregion
    }
}
