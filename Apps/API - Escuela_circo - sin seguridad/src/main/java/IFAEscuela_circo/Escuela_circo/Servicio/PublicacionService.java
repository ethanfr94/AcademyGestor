package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Publicacion;

import java.util.List;

public interface PublicacionService {
    List<Publicacion> findAll();
    Publicacion findById(Integer id);
    Publicacion guardar(Publicacion publicacion);
    Publicacion modificar(Publicacion publicacion, Integer id);
    Publicacion delete(Integer id);
}
