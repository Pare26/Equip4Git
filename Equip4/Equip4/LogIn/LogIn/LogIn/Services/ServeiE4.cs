using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using LogIn.Models;

namespace LogIn.Serveis
{
    public static class ServeiE4
    {
        public static async Task<Usuario> ConsultarUsuario(string email, string passwd)
        { 
            var conexion = $"http://192.168.0.10/WebService/GetUsuario.php?email="+email+"&passwd="+passwd;

            using( var cliente = new HttpClient())
            {
                var peticion = await cliente.GetAsync(conexion);

                if (peticion != null)
                {
                    var json = await peticion.Content.ReadAsStringAsync();

                    var datos = (JContainer)JsonConvert.DeserializeObject(json);

                    if (datos["account"] != null)
                    {
                        var usuario = new Usuario();

                        usuario.Email = (string)datos["account"]["email"];
                        usuario.Password = (string)datos["account"]["password"];

                        return usuario;
                    }

                   
                }
            }

            return default(Usuario);
        }

        public static async Task<String> InsertUser(string userName,  string passwd)
        {
            var conexion = $"http://192.168.0.10/WebService2/InsertUser.php";

            using (var cliente = new HttpClient())
            {
                var peticion = await cliente.GetAsync(conexion);

                if (peticion != null)
                {
                    //Usuario user = new Usuario(userName, passwd);

                    //var json = (JContainer)JsonConvert.SerializeObject(user);

                    //if (datos["account"] != null)
                    //{
                    //    var usuario = new Usuario();

                    //    usuario.Nombre = (string)datos["account"]["name"];
                    //    usuario.Passwd = (string)datos["account"]["password"];

                    //    return usuario;
                    //}


                   
                    dynamic dynamicJson = new ExpandoObject();
                    dynamicJson.Username = userName;
                    dynamicJson.passwd = passwd;
                    string json = "";
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
                    var objClint = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(conexion, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                    string responJsonText = await respon.Content.ReadAsStringAsync();





                    return json;
                }
                else
                {
                    //Usuario user = new Usuario();

                    //var json = (JContainer)JsonConvert.SerializeObject(user);
                    string json = "";
                    return json;
                }
            }
        }
    }
}
