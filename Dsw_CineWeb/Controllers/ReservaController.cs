using Dsw_Cine.portable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dsw_CineWeb.Controllers
{
    public class ReservaController : Controller
    {
        Services servicio =new Services();


        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        private async Task<List<locales>> ListadoLocales()
        {
           List<locales> locales = new  List<locales>();
            try
            {  
                locales = await servicio.ListaLocales(); 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return locales;
        }

        private List<string> FechasDisponible()
        {
            List<string> fechas = new List<string>();
            try
            {
                foreach (string x in service.listarFechas())
                {
                    fechas.Add(x);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return fechas;
        }

        private List<Funcion> ListarFunciones(string fecha, int local)
        {
            List<Funcion> funciones = new List<Funcion>();
            FuncionDTO[] listaDTO = service.buscarFuncion(fecha, local, true);
            if (listaDTO != null)
            {
                for (int i = 0; i < listaDTO.Length; i++)
                {
                    funciones.Add(new Funcion
                    {
                        Id = listaDTO[i].id,
                        NombrePelicula = listaDTO[i].nom_pelicula,
                        NombreLocal = listaDTO[i].nom_local,
                        NumSala = listaDTO[i].num_sala,
                        Fecha = listaDTO[i].fecha,
                        HoraInicio = listaDTO[i].inicio,
                        HoraFin = listaDTO[i].fin
                    });
                }
            }
            return funciones;
        }

        public ActionResult BuscarFuncion()
        {
            ViewBag.locales = new SelectList(ListadoLocales(), "Id", "Nombre");
            ViewBag.fechas = FechasDisponible();
            return View();
        }

        [HttpPost]
        public ActionResult BuscarFuncion(string fecha, int? local = null)
        {
            ViewBag.locales = new SelectList(ListadoLocales(), "Id", "Nombre");
            ViewBag.fechas = FechasDisponible();
            ViewBag.fecha = fecha;
            ViewBag.local = local;

            local = local == null ? 0 : local;
            fecha = fecha == null ? "" : fecha;
            ViewBag.funciones = ListarFunciones(fecha, (int)local);
            return View();
        }

        public ActionResult Reservar(Funcion obj)
        {
            Funcion funcion = new Funcion
            {
                Id = obj.Id,
                NombrePelicula = obj.NombrePelicula,
                NombreLocal = obj.NombreLocal,
                Fecha = obj.Fecha,
                NumSala = obj.NumSala,
                HoraInicio = obj.HoraInicio,
                HoraFin = obj.HoraFin
            };
            return View(funcion);
        }

        [HttpPost]
        public ActionResult MostrarReserva(int funcion, string dni)
        {
            TicketDTO dto = service.Reservar(funcion, true, dni);
            Ticket ticket = new Ticket
            {
                NumTicket = dto.ticket,
                Pelicula = dto.pelicula,
                Local = dto.local,
                Sala = dto.sala,
                Fecha = dto.fecha,
                Inicio = dto.inicio,
                Fin = dto.fin,
                Cliente = dto.cliente
            };

            return View(ticket);
        }

        [HttpPost]
        public JsonResult ValidarCliente(string dni)
        {
            Cliente cli = null;
            ClienteDTO dto = service.validarCliente(dni);
            if (dto != null)
            {
                cli = new Cliente { Dni = dto.dni, Nombre = dto.nom_cliente };

            }

            return Json(cli.Nombre);
        }


    }
}