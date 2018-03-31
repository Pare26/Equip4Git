using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogIn.Models;
using LogIn.Serveis;

namespace LogIn.paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

            this.BindingContext = new Usuario();
		}

        public async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            string email = txtUsuari.Text;
            string passwd = txtPasswd.Text;
            var usuario = await ServeiE4.ConsultarUsuario(email, passwd);

            if(usuario != null)
            {
                this.BindingContext = usuario;
            }

            if (!String.IsNullOrEmpty(txtUsuari.Text) || !String.IsNullOrEmpty(txtPasswd.Text))
            {
                var usuarioInsert = await ServeiE4.InsertUser(email, passwd);
                
                if(usuarioInsert == null)
                {
                    btnBuscar.Text = "error";
                }
            }
        }
	}
}