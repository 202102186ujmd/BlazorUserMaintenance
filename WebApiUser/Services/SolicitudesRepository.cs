﻿using Microsoft.EntityFrameworkCore;
using User.Shared;
using WebApiUser.Interfaces;
using WebApiUser.Models;

namespace WebApiUser.Services
{
    public class SolicitudesRepository : ISolicitudesRepository
    {
        //Inyeccion de dependencias
        #region
        private readonly UserBDContext _db;
        private readonly ILogger _logger;
        public SolicitudesRepository(UserBDContext db, ILogger<SolicitudesRepository> logger)
        {
            this._db = db;
            _logger = logger;
        }
        #endregion

        public void AgregarSolicitud(Solicitud solicitud)
        {
            try
            {
                //validamos que el solicitante exista
                var solicitante = _db.Solicitante.Find(solicitud.IdSolicitante);
                if (solicitante != null)
                {
                    //agregamos la solicitud
                    _db.Solicitud.Add(solicitud);
                }
                else
                {
                    throw new Exception("No se encontro el solicitante");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(AgregarSolicitud)}: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarSolicitud(int solicitudid, Solicitud solicitud)
        {
            try
            {
                // Buscar la solicitud en la base de datos utilizando su identificador
                var solicitudActual = _db.Solicitud.Find(solicitudid);

                // Verificar si se encontró la solicitud con el identificador dado
                if (solicitudActual != null)
                {
                    // Actualizar campos
                    solicitudActual.IdSolicitud = solicitudid;
                    solicitudActual.IdSolicitante = solicitud.IdSolicitante > 0 ? solicitud.IdSolicitante : solicitudActual.IdSolicitante;
                    solicitudActual.FechadeCreacion = solicitud.FechadeCreacion != default ? solicitud.FechadeCreacion : solicitudActual.FechadeCreacion;
                    solicitudActual.IdEstado = solicitud.IdEstado > 0 ? solicitud.IdEstado : solicitudActual.IdEstado;

                    // Marcar el objeto como modificado para que Entity Framework realice las actualizaciones en la base de datos
                    _db.Entry(solicitudActual).State = EntityState.Modified;

                    // Guardar los cambios en la base de datos
                    _db.SaveChanges();
                }
                else
                {
                    // Si no se encuentra la solicitud, lanzar una excepción
                    throw new Exception("No se encontró la solicitud a actualizar.");
                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                _logger.LogError(ex, "Error inesperado al actualizar la solicitud.");
                throw new Exception("Error inesperado al actualizar la solicitud.", ex);
            }
        }

        public void EliminarSolicitud(int IdSolicitud)
        {
            var solicitudelminar = _db.Solicitud.Find(IdSolicitud);
            if (solicitudelminar != null)
            {
                _db.Solicitud.Remove(solicitudelminar);
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error en {nameof(EliminarSolicitud)}: " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("No se encontro la solicitud a eliminar");
            }

        }

        public Solicitud ObtenerSolicitud(int IdSolicitud)
        {
            var solicitudUnica = _db.Solicitud.Find(IdSolicitud);
            if (solicitudUnica != null)
            {
                return solicitudUnica;
            }
            else
            {
                throw new Exception("No se encontro la solicitud");
            }
        }

        public List<Solicitud> ObtenerSolicitudes()
        {
            try
            {
                return _db.Solicitud.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(ObtenerSolicitudes)}: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
