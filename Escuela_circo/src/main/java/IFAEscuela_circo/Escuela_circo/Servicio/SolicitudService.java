package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Solicitud;

import java.util.List;

public interface SolicitudService {
    List<Solicitud> findAll();
    Solicitud findById(Integer id);
    Solicitud guardar(Solicitud solicitud);
    Solicitud modificar(Solicitud solicitud, Integer id);
    Solicitud delete(Integer id);
}
