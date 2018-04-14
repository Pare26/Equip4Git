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


    }
}
