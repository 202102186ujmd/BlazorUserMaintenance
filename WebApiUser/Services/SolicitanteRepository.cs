using Microsoft.EntityFrameworkCore;
using User.Shared;
using WebApiUser.Interfaces;
using WebApiUser.Models;

namespace WebApiUser.Services
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        //Inyeccion de dependencias
        #region
        private readonly UserBDContext _db;
        private readonly ILogger _logger;
        public SolicitanteRepository(UserBDContext db, ILogger<SolicitanteRepository> logger)
        {
            this._db = db;
            _logger = logger;
        }
        #endregion

        public void Actualizar(int solicitanteid, Solicitante solicitante)
        {
            try
            {
                //buscamos el solicitante en la base de datos utilizando su identificador
                var solicitanteActual = _db.Solicitante.Find(solicitanteid);
                if (solicitanteActual != null)
                {
                    //actualizamos campos
                    solicitanteActual.IdSolicitante = solicitanteid;
                    solicitanteActual.NombreCompleto = solicitante.NombreCompleto ?? solicitanteActual.NombreCompleto;
                    solicitanteActual.FechaNacimiento = solicitante.FechaNacimiento != default ? solicitante.FechaNacimiento : solicitanteActual.FechaNacimiento;
                    solicitanteActual.EstadoCivil = solicitante.EstadoCivil ?? solicitanteActual.EstadoCivil;
                    solicitanteActual.Dui = solicitante.Dui ?? solicitanteActual.Dui;
                    solicitanteActual.Pasaporte = solicitante.Pasaporte ?? solicitanteActual.Pasaporte;
                    solicitanteActual.FechaExpedicionPasaporte = solicitante.FechaExpedicionPasaporte != default ? solicitante.FechaExpedicionPasaporte : solicitanteActual.FechaExpedicionPasaporte;
                    solicitanteActual.LugardeExpedicion = solicitante.LugardeExpedicion ?? solicitanteActual.LugardeExpedicion;
                    solicitanteActual.Direccion = solicitante.Direccion ?? solicitanteActual.Direccion;
                    solicitanteActual.Email = solicitante.Email ?? solicitanteActual.Email;
                    solicitanteActual.Telefono = solicitante.Telefono ?? solicitanteActual.Telefono;


                    _db.Entry(solicitanteActual).State = EntityState.Modified;
                    _db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No se encontro el solicitante");
                }
            }
            catch (Exception ex)
            { 
                _logger.LogInformation($"Solicitante actualizado: ID {solicitanteid}, Nombre: {solicitante.NombreCompleto}");
                _logger.LogError($"Error en {nameof(Actualizar)}: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void Agregarsolicitante(Solicitante solicitante)
        {
            try
            {
                _db.Solicitante.Add(solicitante);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Agregarsolicitante)}: " + ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public void Eliminarsolicitante(int IdSolicitante)
        {
            try
            {
                var solicitante = _db.Solicitante.Find(IdSolicitante);
                if (solicitante != null)
                {
                    _db.Solicitante.Remove(solicitante);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Eliminarsolicitante)}: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Solicitante ObtenerSolicitante(int IdSolicitante)
        {
            try
            {
                var solicitante = _db.Solicitante.Find(IdSolicitante);
                if (solicitante != null)
                {
                    return solicitante;
                }
                else
                {
                    return new Solicitante();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(ObtenerSolicitante)}: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<Solicitante> ObtenerSolicitantes()
        {
            try
            {
                //Verificar si la tabla esta vacia
                if (_db.Solicitante.Count() == 0)
                {
                    return new List<Solicitante>();
                }
                return _db.Solicitante.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(ObtenerSolicitantes)}: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}
