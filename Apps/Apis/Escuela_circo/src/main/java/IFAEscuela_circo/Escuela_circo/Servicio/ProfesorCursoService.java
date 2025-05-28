package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.ProfesorCurso;

import java.util.List;

public interface ProfesorCursoService {
    List<ProfesorCurso> findAll();
    ProfesorCurso findById(Integer id);
    ProfesorCurso guardar(ProfesorCurso profesorCurso);
    ProfesorCurso modificar(ProfesorCurso profesorCurso, Integer id);
    ProfesorCurso delete(Integer id);
}
