package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Tutor;

import java.util.List;

public interface TutorService {
    List<Tutor> findAll();
    Tutor findById(Integer id);
    Tutor guardar(Tutor tutor);
    Tutor modificar(Tutor tutor, Integer id);
    Tutor delete(Integer id);
}
