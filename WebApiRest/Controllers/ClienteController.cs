using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiRest.Controllers
{

    [RoutePrefix("Api")]

    public class ClienteController : ApiController
    {


        dsw_cineEntities db = new dsw_cineEntities();

        [HttpPost]
        [Route("registrocliente")]
        public IHttpActionResult PostRegistroCliente(string dni, string  nom, string correo, string telf_f , string telf_c)
        { 
            try
            {
                var query = db.sp_registrarCliente(dni,nom,correo,telf_f, telf_c);

                return Ok("Registrado Correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


          [HttpPut]
          [Route("actualizacliente")]
        public IHttpActionResult putActualizaCliente(string dni, string nom, string correo, string telf_f, string telf_c)
          {
              try
              {
                  var query = db.sp_actualizarCliente(dni, nom, correo, telf_f, telf_c);
                  return Ok("Actualizado Correctamente");
              }
              catch (Exception ex)
              {
                  return BadRequest();
              }
          }



        [HttpGet]
        [Route("listadopeliculas")]
        public IHttpActionResult GetPeliculas()
        {
            try
            {
                var query = from s in db.sp_listarPeliculas()
                            
                            select new Peliculas()
                            {
                                Id = s.id_pelicula,
                                Nombre   = s.nom_pelicula
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
