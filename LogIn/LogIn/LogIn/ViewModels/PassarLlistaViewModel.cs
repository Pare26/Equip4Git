﻿using GalaSoft.MvvmLight.Command;
using LogIn.Models;
using LogIn.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogIn.ViewModels
{
    public class PassarLlistaViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<UsuarioItemViewModel> usuarios;
        private bool isRefreshing;
        private string filter;
        private string today = DateTime.Now.ToShortDateString();
        private List<Usuario> usuarioList;
        private string format = "mm:ss";
        private DateTime dosMin = new DateTime(2018, 04, 11, 00, 02, 00);
        private DateTime countdown = new DateTime();
        private Timer timer = new Timer();
        private static Timer aTimer;
        #endregion

        #region Properties
        public ObservableCollection<UsuarioItemViewModel> Usuarios
        {
            get { return this.usuarios; }
            set { SetValue(ref this.usuarios, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }

        public string Today
        {
            get { return this.today; }
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
        public PassarLlistaViewModel()
        {
            this.apiService = new ApiService();
            this.LoadUsuarios();

            SetTimer();
        }

        public void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            countdown = dosMin.AddSeconds(-1);
        }
        #endregion

        #region Methods
        private async void LoadUsuarios()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                //si no hi ha connexio torna a la pagina principal
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Usuario>("http://192.168.0.10",
                "/WebService",
                "/GetUsuarios.php");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            this.usuarioList = (List<Usuario>)response.Result;
            this.Usuarios = new ObservableCollection<UsuarioItemViewModel>(
            this.ToUsuarioItemViewModel());
            this.IsRefreshing = false;
        }
        #endregion

        #region Methods
        private IEnumerable<UsuarioItemViewModel> ToUsuarioItemViewModel()
        {
            return this.usuarioList.Select(l => new UsuarioItemViewModel
            {
                Email = l.Email,
                Password = l.Password,
                Nom = l.Nom,
                Cognom = l.Cognom,
            });
        }
        #endregion

        #region Commads
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadUsuarios);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Usuarios = new ObservableCollection<UsuarioItemViewModel>(
                    this.ToUsuarioItemViewModel());
            }
            else
            {
                this.Usuarios = new ObservableCollection<UsuarioItemViewModel>(
                  this.ToUsuarioItemViewModel().Where(
                        l => l.Nom.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}
