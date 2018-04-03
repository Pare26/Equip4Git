using System;
using System.Collections.Generic;
using System.Text;

namespace LogIn.ViewModels
{
    class MainViewModel
    {
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
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
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
