package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Solicitud;
import IFAEscuela_circo.Escuela_circo.Repositorios.SolicitudRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SolicitudServiceImp implements SolicitudService {

    @Autowired
    private SolicitudRepository repo;

    @Override
    public List<Solicitud> findAll() {
        return repo.findAll();
    }

    @Override
    public Solicitud findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Solicitud guardar(Solicitud solicitud) {
        return repo.save(solicitud);
    }

    @Override
    public Solicitud modificar(Solicitud solicitud, Integer id) {
        Solicitud soli = repo.findById(id).orElse(null);
        if (soli != null) {
            solicitud.setId(id);
            return repo.save(solicitud);
        }
        return null;
    }

    @Override
    public Solicitud delete(Integer id) {
        Solicitud solicitud = repo.findById(id).orElse(null);
        if (solicitud != null) {
            repo.delete(solicitud);
            return solicitud;
        } else {
            return null;
        }
    }
}
