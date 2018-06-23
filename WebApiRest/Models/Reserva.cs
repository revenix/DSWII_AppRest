using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRest.Models
{
    public class Reserva
    {
        public string nombre_peli { get; set; }
        public string nombre_local{ get; set; }
        //puede error x tipo de dato.

        public int num_sala { get; set; } 
        public string um_fecha { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
        public string dni { get; set; }
        public string nom_cliente { get; set; } 

    }
}