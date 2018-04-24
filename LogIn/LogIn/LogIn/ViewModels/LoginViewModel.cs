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
    using System.Timers;
    using System.Threading;

    public class LoginViewModel : BaseViewModel
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

        private string format = "mm:ss";
        private DateTime dosMin = new DateTime(2018, 04, 11, 00, 02, 00);
        private DateTime countdown = new DateTime();
        //private Timer timer = new Timer();
        //private static Timer aTimer;
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


        public string Temps
        {
            get { return this.dosMin.ToString(format); }
        }

        public string Countdown
        {
            get { return this.countdown.ToString(format); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "admin@admin";
            this.Password = "admin";

            //SetTimer();
            
        }

        public void SetTimer()
        {
            // Create a timer with a two second interval.
            //aTimer = new Timer();
            //// Hook up the Elapsed event for the timer. 
            //aTimer.Interval = 2000;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
            //aTimer.Start();
            //aTimer.Elapsed += this.OnTimedEvent;
            do
            {
                countdown = dosMin.AddSeconds(-1);
                Thread.Sleep(1000);
            } while (true);
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            countdown = dosMin.AddSeconds(-1);
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
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connexion = await this.apiService.CheckConnection();

            if (!connexion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   connexion.Message,
                   Languages.Accept);
                return;
            }

            usuario = await apiService.ConsultarUsuario(Email, Password);

            if (!this.Email.Equals(usuario.Email) || !this.Password.Equals(usuario.Password))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailOrPasswordIncorrect,
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            //cambiar pagina
            MainViewModel.GetInstance().PassarLlista = new PassarLlistaViewModel();

            Application.Current.MainPage = new MasterPage();
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion
    }
}
