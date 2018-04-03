namespace LogIn.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using LogIn.Models;
    using LogIn.Services;
    using LogIn.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Helpers;
    class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        Usuario usuario = new Usuario(); 
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }


        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        //controlar si els botons estan activats o no
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "admin";
            this.Password = "admin";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        private async void Login()
        {
            
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }
            if (String.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            usuario = await apiService.ConsultarUsuario(Email, Password);

            if (!this.Email.Equals(usuario.Email) || !this.Password.Equals(usuario.Password))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            //cambiar pagina
            MainViewModel.GetInstance().PassarLlista = new PassarLlistaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new GeneralTabbedPage());
        }
        #endregion

    }
}
