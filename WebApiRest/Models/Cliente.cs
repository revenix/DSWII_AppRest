﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRest.Models
{
    public class Cliente
    {

        public string dni { get; set; }
        public string nom_clie { get; set; }
        public string correo { get; set; } 
        public string telefono_f { get; set; }
        public string telefono_c { get; set; } 


    }
}