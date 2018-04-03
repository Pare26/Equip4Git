using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogIn.Models
{
    public class Usuario
    {
        //recollir el json amb el nom original pero despres es posa
        //un alies per entendre millor
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public Usuario()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        public Usuario(string nombre, string passwd)
        {
            this.Email = nombre;
            this.Password = passwd;
        }
    }
}
