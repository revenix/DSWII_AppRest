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
                                
                                 nombre_peli = s.nom_pelicula,
                                 nombre_local = s.nom_local,
                                 num_sala = int.Parse(s.num_sala+""),
                                 um_fecha = s.um_fecha.ToString(),
                                 inicio = s.inicio,
                                fin = s.fin,
                                dni = s.dni,
                                nom_cliente = s.nom_cliente 
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
                                correo = s.correo_cliente, 
                                 telefono_f = s.telefono_fijo,
                                telefono_c = s.telefono_celular

                            };

                return Ok(query.FirstOrDefault());
                //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }



        [HttpPost]
        [Route("registroreserva")]
        public IHttpActionResult PostRegistroReseva(int funcion,string dni)
        {
            try
            {
                var query = db.sp_Reservar(funcion,dni);

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("listarfechas")]
        public IHttpActionResult GetFechas()
        {
            try
            {
                var query = from s in db.sp_ListarFechas()

                            select new fecha()
                            {
                                Fecha = s.Value.ToShortDateString()
                            };

                return Ok(query.ToList());


            }
            catch (Exception)
            {
                return null;
            }

        }

        [HttpGet]
        [Route("listarfunciones")]
        public IHttpActionResult GetFunciones(string fecha , string local)
        {
            try
            {
                var query = from s in db.sp_ListaFunciones(DateTime.Parse(fecha), local)

                            select new funcion()
                            {
                               
                                id_funcion = s.id_funcion, 
                                nom_pelicula = s.nom_pelicula,
                                num_sala = int.Parse(s.num_sala+""),
                                fecha = s.um_fecha+"",
                               inicio = s.inicio,
                                fin =s.fin   
                            
                            };

                return Ok(query.ToList());


            }
            catch (Exception)
            {
                return null;
            }

        }


        [HttpGet]
        [Route("listarlocales")]
        public IHttpActionResult GetLocales()
        {
            try
            {
                var query = from s in db.sp_listaLocales()

                            select new local()
                            {
                                id_local = s.id_local,
                                nombre_local = s.nom_local
                            };

                return Ok(query.ToList());


            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
