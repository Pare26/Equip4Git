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
        [JsonProperty(PropertyName = "passwd")]
        public string Passwd { get; set; }

        public Usuario()
        {
            this.Email = string.Empty;
            this.Passwd = string.Empty;
        }
        public Usuario(string nombre, string passwd)
        {
            this.Email = nombre;
            this.Passwd = passwd;
        }
    }
}
