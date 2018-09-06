using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvaTec.WebApi
{
    
    public class LoginModel
    {
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string alias { get; set; }
        public string numControl { get; set; }
        public string sexo { get; set; }
        public string rutaFoto { get; set; }
        public string correo { get; set; }
        public string desGeneral { get; set; }
        public string codPais { get; set; }
        public string numTelefono { get; set; }
        public object numExtension { get; set; }
    }
}
