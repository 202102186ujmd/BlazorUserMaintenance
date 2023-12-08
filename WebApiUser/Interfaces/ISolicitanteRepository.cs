using User.Shared;

namespace WebApiUser.Interfaces
{
    public interface ISolicitanteRepository
    {
        void Agregarsolicitante(Solicitante solicitante);
        void Actualizar(int solicitanteid, Solicitante solicitante);
        void Eliminarsolicitante(int IdSolicitante);
        Solicitante ObtenerSolicitante(int IdSolicitante);
        List<Solicitante> ObtenerSolicitantes();
    }
}
