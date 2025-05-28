package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Publicacion;
import IFAEscuela_circo.Escuela_circo.Repositorios.PublicacionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PublicacionServiceImp implements PublicacionService {

    @Autowired
    private PublicacionRepository repo;

    @Override
    public List<Publicacion> findAll() {
        return repo.findAll();
    }

    @Override
    public Publicacion findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Publicacion guardar(Publicacion publicacion) {
        return repo.save(publicacion);
    }

    @Override
    public Publicacion modificar(Publicacion publicacion, Integer id) {
        Publicacion publi = repo.findById(id).orElse(null);
        if (publi != null) {
            publicacion.setId(id);
            return repo.save(publicacion);
        }
        return null;
    }

    @Override
    public Publicacion delete(Integer id) {
        Publicacion publicacion = repo.findById(id).orElse(null);
        if (publicacion != null) {
            repo.delete(publicacion);
            return publicacion;
        } else {
            return null;
        }
    }
}
