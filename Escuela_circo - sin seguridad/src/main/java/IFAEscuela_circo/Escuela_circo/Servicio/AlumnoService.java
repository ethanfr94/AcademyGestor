package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Alumno;

import java.util.List;

public interface AlumnoService {
    List<Alumno> findAll();
    Alumno findById(Integer id);
    Alumno guardar(Alumno alumno);
    Alumno modificar(Alumno alumno, Integer id);
    Alumno delete(Integer id);

}
