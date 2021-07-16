using Nettatica.Models;
using Nettatica.Models.DataModels;
using System;
using System.Collections.Generic;
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
       [ResponseType(typeof(MError))]
        [Route("CreateVuelo/")]
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
