package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Curso;
import IFAEscuela_circo.Escuela_circo.Repositorios.CursoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CursoServiceImp implements CursoService {

    @Autowired
    private CursoRepository repo;

    @Override
    public List<Curso> findAll() {
        return repo.findAll();
    }

    @Override
    public Curso findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Curso guardar(Curso curso) {
        return repo.save(curso);
    }

    @Override
    public Curso modificar(Curso curso, Integer id) {
        Curso cur = repo.findById(id).orElse(null);
        if (cur != null) {
            curso.setId(id);
            return repo.save(cur);
        }
        return null;
    }

    @Override
    public Curso delete(Integer id) {
        Curso cur = repo.findById(id).orElse(null);
        if (cur != null) {
            repo.delete(cur);
            return cur;
        }
        return null;
    }

}
