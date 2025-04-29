package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Matricula;
import IFAEscuela_circo.Escuela_circo.Repositorios.MatriculaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MatriculaServiceImp implements MatriculaService {

    @Autowired
    private MatriculaRepository repo;

    @Override
    public List<Matricula> findAll() {
        return repo.findAll();
    }

    @Override
    public Matricula findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Matricula guardar(Matricula matricula) {
        return repo.save(matricula);
    }

    @Override
    public Matricula modificar(Matricula matricula, Integer id) {
        Matricula mat = repo.findById(id).orElse(null);
        if (mat != null) {
            matricula.setId(id);
            return repo.save(matricula);
        }
        return null;
    }

    @Override
    public Matricula delete(Integer id) {
        Matricula matricula = repo.findById(id).orElse(null);
        if (matricula != null) {
            repo.delete(matricula);
            return matricula;
        } else {
            return null;
        }
    }

}
