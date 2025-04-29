package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Alumno;
import IFAEscuela_circo.Escuela_circo.Repositorios.AlumnoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AlumnoServiceImp implements AlumnoService {

    @Autowired
    private AlumnoRepository repo;

    @Override
    public List<Alumno> findAll() {
        return repo.findAll();
    }

    @Override
    public Alumno findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Alumno guardar(Alumno alumno) {
        return repo.save(alumno);
    }

    @Override
    public Alumno modificar(Alumno alumno, Integer id) {
        Alumno alum = repo.findById(id).orElse(null);
        if (alum != null) {
            alumno.setId(id);
            return repo.save(alumno);
        }
        return null;
    }

    @Override
    public Alumno delete(Integer id) {
        Alumno alumno = repo.findById(id).orElse(null);
        if (alumno != null) {
            repo.delete(alumno);
            return alumno;
        } else {
            return null;
        }
    }
}
