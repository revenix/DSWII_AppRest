using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    [RoutePrefix("Api")]
    public class ReservaController : ApiController
    {

        dsw_cineEntities db = new dsw_cineEntities();

        [HttpGet]
        [Route("consultareserva")]
        public IHttpActionResult GetReserva(int id)
        {
            try
            {
                var query = from s in db.sp_consultarReserva(id)

                            select new Reserva()
                            {
                                 nombre_peli = s.nom_cliente,
                                 nombre_local = s.nom_local,
                                 num_sala = int.Parse(s.num_sala+""),
                                 um_fecha = s.um_fecha.ToString(),
                                 inicio = s.inicio,
                                fin = s.fin,
                                dni = s.dni,
                                nom_cliente = s.nom_cliente,
                                ape_cliente = s.ape_cliente  
                            };

                return Ok(query.FirstOrDefault());
                //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }


        [HttpGet]
        [Route("consultacliente")]
        public IHttpActionResult GetCliente(int dni)
        {
            try
            {
                var query = from s in db.sp_buscarCliente(dni)

                            select new Cliente()
                            {
                                 
                                dni = s.dni,
                                nom_clie = s.nom_cliente,
                                ape_clie = s.ape_cliente,
                                correo = s.correo_cliente,
                                clave = s.clave_cliente,
                                telefono = s.telefono,
                                dir_cliente = s.dir_cliente

                            };

                return Ok(query.FirstOrDefault());
                //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
