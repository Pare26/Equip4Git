using LogIn.Models;

namespace LogIn.ViewModels
{
    class UsuarioViewModel
    {
        #region Properties
        public Usuario Usuario
        {
            get;
            set;
        }
        #endregion
        #region Constructors
        public UsuarioViewModel(Usuario usuario)
        {
            this.Usuario = usuario;
        } 
        #endregion
    }
}
