using PruebaApiREST.Models;
public interface ISolicitudRepository <T>
{
    Task <IEnumerable<Solicitud>> GetSolicitudes();
    Task <Solicitud> GetSolicitudxId(int id);
    Task <Solicitud> AddSolicitud(Solicitud solicitud);
    Task <Solicitud> UpdateSolicitud(Solicitud solicitud);
    void DeleteSolicitud(int id);
}