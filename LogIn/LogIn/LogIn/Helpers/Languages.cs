using System;
using System.Collections.Generic;
using System.Text;

namespace LogIn.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string Error
        {
            get { return Resource.Error; }
        }
        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string EmailOrPasswordIncorrect
        {
            get { return Resource.EmailOrPasswordIncorrect; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string Email
        {
            get { return Resource.Email; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string PasswordPlaceHolder
        {
            get { return Resource.PasswordPlaceHolder; }
        }

        public static string ForgotPassword
        {
            get { return Resource.ForgotPassword; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }


        public static string Search
        {
            get { return Resource.Search; }
        }

        public static string Noconnexion
        {
            get { return Resource.Noconnexion; }
        }

        public static string MyProfile
        {
            get { return Resource.MyProfile; }
        }

        public static string LogOut
        {
            get { return Resource.LogOut; }
        }
        public static string VirtualMarker
        {
            get { return Resource.VirtualMarker; }
        }
        public static string Menu
        {
            get { return Resource.Menu; }
        }

        public static string NoConnexion
        {
            get { return Resource.Noconnexion; }
        }

        public static string PassList
        {
            get { return Resource.PassList; }
        }

        public static string Regist
        {
            get { return Resource.Regist; }
        }

        public static string SecondName
        {
            get { return Resource.SecondName; }
        }

        public static string SecondNamePlaceHolder
        {
            get { return Resource.SecondNamePlaceHolder; }
        }

        public static string FirstName
        {
            get { return Resource.FirstName; }
        }

        public static string FirstNamePlaceHolder
        {
            get { return Resource.FirstNamePlaceHolder; }
        }
        ////////////////////////////////////////////////////////////////////

        public static string FirstNameValidation
        {
            get { return Resource.FirstNameValidation; }
        }
        public static string LastNameValidation
        {
            get { return Resource.LastNameValidation; }
        }
        public static string EmailValidation2
        {
            get { return Resource.EmailValidation2; }
        }
        public static string PasswordValidation2
        {
            get { return Resource.PasswordValidation2; }
        }
        public static string ConfirmValidation
        {
            get { return Resource.ConfirmValidation; }
        }
        public static string ConfirmValidation2
        {
            get { return Resource.ConfirmValidation2; }
        }
        public static string ConfirmLabel
        {
            get { return Resource.ConfirmLabel; }
        }
        public static string ConfirmPlaceHolder
        {
            get { return Resource.ConfirmPlaceHolder; }
        }
        public static string UserRegisteredMessage
        {
            get { return Resource.UserRegisteredMessage; }
        }
  
        public static string NumClass
        {
            get { return Resource.NumClass; }
        }
    }
}
