package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Matricula;

import java.util.List;

public interface MatriculaService {
    List<Matricula> findAll();
    Matricula findById(Integer id);
    Matricula guardar(Matricula matricula);
    Matricula modificar(Matricula matricula, Integer id);
    Matricula delete(Integer id);
}
