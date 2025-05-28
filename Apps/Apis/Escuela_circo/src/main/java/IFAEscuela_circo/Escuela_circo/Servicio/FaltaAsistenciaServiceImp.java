package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.FaltasAsistencia;
import IFAEscuela_circo.Escuela_circo.Repositorios.FaltasAsistenciaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class FaltaAsistenciaServiceImp implements FaltaAsistenciaService {

    @Autowired
    private FaltasAsistenciaRepository repo;

    @Override
    public List<FaltasAsistencia> findAll() {
        return repo.findAll();
    }

    @Override
    public FaltasAsistencia findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    public List<FaltasAsistencia> findByAlumnoId(Integer id) {
        List<FaltasAsistencia> faltas = repo.findAll();
        faltas.forEach(falta -> {
            if (falta.getAlumno().getId() != id) {
                faltas.remove(falta);
            }
        });
        return faltas;
    }

    @Override
    public FaltasAsistencia guardar(FaltasAsistencia faltasAsistencia) {
        return repo.save(faltasAsistencia);
    }

    @Override
    public FaltasAsistencia modificar(FaltasAsistencia faltasAsistencia, Integer id) {
        FaltasAsistencia falAsis = repo.findById(id).orElse(null);
        if (falAsis != null) {
            faltasAsistencia.setId(id);
            return repo.save(falAsis);
        }
        return null;
    }

    @Override
    public FaltasAsistencia delete(Integer id) {
        FaltasAsistencia falAsis = repo.findById(id).orElse(null);
        if (falAsis != null) {
            repo.delete(falAsis);
            return falAsis;
        }
        return null;
    }
}
