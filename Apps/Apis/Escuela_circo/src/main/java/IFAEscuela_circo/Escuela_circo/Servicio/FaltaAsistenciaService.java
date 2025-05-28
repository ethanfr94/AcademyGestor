package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.FaltasAsistencia;

import java.util.List;

public interface FaltaAsistenciaService {
    List<FaltasAsistencia> findAll();
    FaltasAsistencia findById(Integer id);
    FaltasAsistencia guardar(FaltasAsistencia faltasAsistencia);
    FaltasAsistencia modificar(FaltasAsistencia faltasAsistencia, Integer id);
    FaltasAsistencia delete(Integer id);
}
