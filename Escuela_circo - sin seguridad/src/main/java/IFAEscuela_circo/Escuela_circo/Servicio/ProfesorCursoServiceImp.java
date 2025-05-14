package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.ProfesorCurso;
import IFAEscuela_circo.Escuela_circo.Repositorios.ProfesorCursoRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProfesorCursoServiceImp implements ProfesorCursoService{

    private static final Logger log = LoggerFactory.getLogger(ProfesorCursoServiceImp.class);
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

    public ProfesorCurso findByCursoYProfesor(Integer cursoId, Integer profesorId) {
        List<ProfesorCurso> profesorCursos = repo.findAll();
        profesorCursos.removeIf(profesorCurso -> !profesorCurso.getCurso().getId().equals(cursoId) || !profesorCurso.getProfesor().getId().equals(profesorId));
        ProfesorCurso profesorCurso = profesorCursos.isEmpty() ? null : profesorCursos.get(0);
        return profesorCurso;
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

    public ProfesorCurso updateCoordinadorByProfesorYCurso(Integer idCurso, Integer idProfesor) {
        List<ProfesorCurso> profesoresCurso = this.findByCursoId(idCurso);
        profesoresCurso.removeIf(profesorCurso -> !profesorCurso.getProfesor().getId().equals(idProfesor));
        ProfesorCurso profesorCurso = profesoresCurso.getFirst();
        if (profesorCurso != null) {
            profesorCurso.setCoordinador((byte) (profesorCurso.getCoordinador() == 0 ? 1 : 0));
            repo.save(profesorCurso);
            return profesorCurso;
        } else {
            return null;
        }
    }

    public ProfesorCurso deleteByProfesorYCurso(Integer idCurso, Integer idProfesor) {
        List<ProfesorCurso> profesoresCurso = this.findByCursoId(idCurso);
        profesoresCurso.removeIf(profesorCurso -> !profesorCurso.getProfesor().getId().equals(idProfesor));
        log.error("profesoresCurso: " + profesoresCurso);
        ProfesorCurso profesorCurso = profesoresCurso.getFirst();
        if (profesorCurso != null) {
            repo.delete(profesorCurso);
            return profesorCurso;
        } else {
            return null;
        }
    }


}
