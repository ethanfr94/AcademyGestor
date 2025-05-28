package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Alumno;
import IFAEscuela_circo.Escuela_circo.Modelos.Curso;

import java.util.List;

public interface CursoService {
    List<Curso> findAll();
    Curso findById(Integer id);
    Curso guardar(Curso c);
    Curso modificar(Curso c, Integer id);
    Curso delete(Integer id);
}
