package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.ProfesorCurso;
import IFAEscuela_circo.Escuela_circo.Repositorios.ProfesorCursoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProfesorCursoServiceImp implements ProfesorCursoService{

    @Autowired
    private ProfesorCursoRepository repo;

    @Override
    public List<ProfesorCurso> findAll() {
        return repo.findAll();
    }

    @Override
    public ProfesorCurso findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    public List<ProfesorCurso> findByCursoId(Integer id) {
        List<ProfesorCurso> profesorCursos = repo.findAll();
        profesorCursos.removeIf(profesorCurso -> !profesorCurso.getCurso().getId().equals(id));
        return profesorCursos;
    }

    @Override
    public ProfesorCurso guardar(ProfesorCurso profesorCurso) {
        return repo.save(profesorCurso);
    }

    @Override
    public ProfesorCurso modificar(ProfesorCurso profesorCurso, Integer id) {
        ProfesorCurso prof = repo.findById(id).orElse(null);
        if (prof != null) {
            profesorCurso.setId(id);
            return repo.save(profesorCurso);
        }
        return null;
    }

    @Override
    public ProfesorCurso delete(Integer id) {
        ProfesorCurso profesorCurso = repo.findById(id).orElse(null);
        if (profesorCurso != null) {
            repo.delete(profesorCurso);
            return profesorCurso;
        } else {
            return null;
        }
    }
}
