using Microsoft.AspNetCore.Mvc;
using User.Shared;
using WebApiUser.Interfaces;
using WebApiUser.Services;

namespace WebApiUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitanteController : Controller
    {
        //injeccion de dependencias
        #region
        private readonly ISolicitanteRepository _solicitantesRepository;
        private readonly ILogger _logger;
        public SolicitanteController(ISolicitanteRepository solicitantesRepository, ILogger<SolicitanteController> logger)
        {
            _solicitantesRepository = solicitantesRepository;
            _logger = logger;
        }
        #endregion



        //Implementacion de los metodos

        [HttpPost("NuevoSolicitante")]
        public ActionResult Agregarsolicitante(Solicitante solicitante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Datos del solicitante invalidos");
                }
                _solicitantesRepository.Agregarsolicitante(solicitante);
                return Ok("Solicitante agregado Existosamente");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Agregarsolicitante)}: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("Actualizar/{solicitanteId}")]
        public ActionResult Actualizar(int solicitanteId, [FromBody] Solicitante solicitante)
        {
            try
            {
                // Validar si el solicitante existe antes de intentar actualizarlo
                var solicitanteExistente = _solicitantesRepository.ObtenerSolicitante(solicitanteId);
                if (solicitanteExistente == null)
                {
                    return NotFound($"No se encontró un solicitante con el ID {solicitanteId}");
                }

                // Actualizar el solicitante
                _solicitantesRepository.Actualizar(solicitanteId, solicitante);
                return Ok("Solicitante actualizado Existosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en Actualizar: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpDelete("EliminarSolicitante/{IdSolicitante}")]
        public ActionResult Eliminar(int IdSolicitante)
        {
            try
            {
                //validar si el campo esta vacio
                if (IdSolicitante == 0)
                {
                    return BadRequest("El id del solicitante es requerido");
                }
                //buscar el solicitante
                var solicitante = _solicitantesRepository.ObtenerSolicitante(IdSolicitante);
                //validar si el solicitante existe
                if (solicitante == null)
                {
                    return NotFound($"El solicitante con el id {IdSolicitante} no existe");
                }
                _solicitantesRepository.Eliminarsolicitante(IdSolicitante);
                return Ok("Solicitante eliminado Existosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Eliminar)}: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("ObtenerSolicitante/{IdSolicitante}")]
        public ActionResult SolicitanteID(int IdSolicitante)
        {
            try
            {
                //validar si el campo esta vacio
                if (IdSolicitante == 0)
                {
                    return BadRequest("El id del solicitante es requerido");
                }
                //buscar el solicitante
                var solicitante = _solicitantesRepository.ObtenerSolicitante(IdSolicitante);
                //validar si el solicitante existe
                if (solicitante == null)
                {
                    return NotFound($"El solicitante con el id {IdSolicitante} no existe");
                }
                return Ok(solicitante);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(SolicitanteID)}: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("ObtenerTodos")]
        public ActionResult ObtenerTodos()
        {
            try
            {
                //Validar si existen solicitantes
                var solicitantes = _solicitantesRepository.ObtenerSolicitantes();
                if (solicitantes == null)
                {
                    return NotFound($"No existen solicitantes");
                }
                return Ok(solicitantes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(ObtenerTodos)}: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

