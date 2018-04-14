using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogIn.Models
{
    public class Usuario
    {
        public int ID_Usuari { get; set; }
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Usuario()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.Nom = string.Empty;
            this.Cognom = string.Empty;
        }
        public Usuario(string email, string password, string nom, string cognom)
        {
            this.Email = email;
            this.Password = password;
            this.Nom = nom;
            this.Cognom = cognom;
        }
    }
}
