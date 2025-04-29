package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Profesor;

import java.util.List;

public interface ProfesorService {
    List<Profesor> findAll();
    Profesor findById(Integer id);
    Profesor guardar(Profesor profesor);
    Profesor modificar(Profesor profesor, Integer id);
    Profesor delete(Integer id);

}
