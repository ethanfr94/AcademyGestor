package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Tutor;
import IFAEscuela_circo.Escuela_circo.Repositorios.TutorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TutorServiceImp implements TutorService {

    @Autowired
    private TutorRepository repo;

    @Override
    public List<Tutor> findAll() {
        return repo.findAll();
    }

    @Override
    public Tutor findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Tutor guardar(Tutor tutor) {
        return repo.save(tutor);
    }

    public Tutor findByDni(String dni) {
        List<Tutor> tutores = repo.findAll();
        for (Tutor tutor : tutores) {
            if (tutor.getDni().equals(dni)) {
                return tutor;
            }
        }
        return null;
    }

    @Override
    public Tutor modificar(Tutor tutor, Integer id) {
        Tutor tut = repo.findById(id).orElse(null);
        if (tut != null) {
            tutor.setId(id);
            return repo.save(tutor);
        }
        return null;
    }

    @Override
    public Tutor delete(Integer id) {
        Tutor tutor = repo.findById(id).orElse(null);
        if (tutor != null) {
            repo.delete(tutor);
            return tutor;
        } else {
            return null;
        }
    }
}
