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
        public string PostRegistroCliente(string dni, string  nom , string ape, string correo,string clave , string telf , string dir)
        { 
            try
            {
                var query = db.sp_registrarCliente(dni,nom,ape,correo,clave,telf,dir);

                return query.ToString();
            }
            catch (Exception ex)
            {
                return BadRequest().ToString();
            }
        }


          [HttpPut]
          [Route("actualizacliente")]
        public IHttpActionResult putActualizaCliente(string dni, string nom, string ape, string correo, string clave, string telf, string dir)
          {
              try
              {
                  var query = db.sp_actualizarCliente(dni, nom, ape, correo, clave, telf, dir);
                  return Ok("Actualizado Correctamente");
              }
              catch (Exception ex)
              {
                  return BadRequest();
              }
          }


           


    }
}
