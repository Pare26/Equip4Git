namespace LogIn.ViewModels
{
    using LogIn.Helpers;
    using System;
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public PassarLlistaViewModel PassarLlista
        {
            get;
            set;
        }

        public UsuarioViewModel Usuario
        {
            get;
            set;
        }

        public RegisterViewModel Register
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_kumite",
                PageName = "KumitePage",
                Title = "Kumite",
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,
            });
        }
        #endregion
        //permet fer una trucada de la MainViewModel des de cualsevol classe
        //sense tindre que instanciar una altre MainViewModel
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
