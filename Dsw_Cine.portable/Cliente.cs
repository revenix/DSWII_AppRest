﻿

namespace Dsw_Cine.portable
{
    public class Cliente
    {

        public string dni { get; set; }
        public string nom_clie { get; set; }
        public string correo { get; set; } 
        public string telefono_f { get; set; }
        public string telefono_c { get; set; } 


    }



    public class peliculas
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

    }



    public class fecha
    {
        public string Fecha { get; set; }

    }

    public class funcion
    {
        public string nom_pelicula { get; set; }
        public int num_sala { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
    }

    public class local
    {
        public int id_local { get; set; }
        public string nombre_local { get; set; }


    }
}

