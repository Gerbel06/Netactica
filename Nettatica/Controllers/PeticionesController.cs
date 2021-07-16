using Nettatica.Models;
using Nettatica.Models.DataModels;
using Nettatica.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Nettatica.Controllers
{
    public class PeticionesController : ApiController
    {
        private DataModel db = new DataModel();

        //POST: api/CreateVuelo
        [HttpPost]
        [ResponseType(typeof(MError))]
        [Route("api/CreateVuelo/")]
        public IHttpActionResult CreateVuelo(Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MError mError= ValidarVuelo(vuelo);
            if (!mError.Error)
            {
                try
                {
                    db.Vuelo.Add(vuelo);
                    db.SaveChanges();
                    mError.Mensaje = "El Vuelo se creo correctamente";
                }
                catch (DbUpdateException e)
                {

                    mError.Error = true;
                    mError.Mensaje = "Ocurrio un error inesperado";
                }
            }
            return Ok(mError);
        }

        [HttpPost]
        [ResponseType(typeof(MError))]
        [Route("api/CreateReserva/")]
        public IHttpActionResult CreateReserva(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MError mError = new MError();
            if (!mError.Error)
            {
                try
                {
                    db.Reserva.Add(reserva);
                    db.SaveChanges();
                    mError.Mensaje = "El Vuelo se creo correctamente";
                }
                catch (DbUpdateException e)
                {

                    mError.Error = true;
                    mError.Mensaje = "Ocurrio un error inesperado";
                }
            }
            return Ok(mError);
        }

        [HttpGet]
        [ResponseType(typeof(ReservaView))]
        [Route("api/GetReserva/")]
        public HttpResponseMessage GetReserva(int idReserva)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                Reserva reserva = db.Reserva.Where(r => r.IdReserva == idReserva).FirstOrDefault();
                if (reserva == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new MError() { Error = true, Mensaje = "No existe reserva con este id" });
                }
                DataTable table = null;
                using (ClsProcedures procedimiento = new ClsProcedures())
                {
                    table = procedimiento.GetReservaView(1, idReserva.ToString());
                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MError() { Error = true, Mensaje = "Ocurrio un error inesperado" }) ;
            }
        }

        [HttpGet]
        [ResponseType(typeof(ReservaView))]
        [Route("api/FilterReserva/")]
        public HttpResponseMessage FilterReserva(int idcolumn, string value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                DataTable table = null;
                using (ClsProcedures procedimiento = new ClsProcedures())
                {
                    table = procedimiento.GetReservaView(idcolumn, value);
                }
                if(table.Rows.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new MError() { Error = true, Mensaje = "No hay datos de esta busqueda" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MError() { Error = true, Mensaje = "Ocurrio un error inesperado" });
            }
        }



        public MError ValidarVuelo(Vuelo vuelo)
        {
            MError error = new MError();
            DateTime FechaActual = DateTime.Today;

            if (vuelo.FechaLlegada < FechaActual || vuelo.FechaSalida < FechaActual)
            {
                error.Error = true;
                error.Mensaje = "No se asignar fechas del pasado";
                return error;
            }
            if (vuelo.FechaLlegada <= vuelo.FechaSalida)
            {
                error.Error = true;
                error.Mensaje = "La fecha de llegada no puede ser menor o igual que la de salida";
                return error;
            }

            if (vuelo.AeropuertoOrigen == vuelo.AeropuertoDestino)
            {
                error.Error = true;
                error.Mensaje = "El aeropuerto de origen y destino deben ser diferentes";
                return error;
            }

            if (db.Aeropuerto.Count(e => e.IdAeropuerto == vuelo.AeropuertoOrigen) == 0)
            {
                error.Error = true;
                error.Mensaje = "El aeropuerto de origen no existe";
                return error;
            }
            if (db.Aeropuerto.Count(e => e.IdAeropuerto == vuelo.AeropuertoDestino) == 0)
            {
                error.Error = true;
                error.Mensaje = "El aeropuerto de destino no existe";
                return error;
            }

            if (db.Aerolinea.Count(e => e.IdAerolinea == vuelo.IdAerolinea) == 0)
            {
                error.Error = true;
                error.Mensaje = "La aerolinea no existe";
                return error;
            }
            return error;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservaExists(int id)
        {
            return db.Reserva.Count(e => e.IdReserva == id) > 0;
        }
    }
}
