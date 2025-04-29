package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Tipo;
import IFAEscuela_circo.Escuela_circo.Repositorios.TipoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TipoServiceImp implements TipoService{

    @Autowired
    private TipoRepository repo;

    @Override
    public List<Tipo> findAll() {
        return repo.findAll();
    }

    @Override
    public Tipo findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Tipo guardar(Tipo tipo) {
        return repo.save(tipo);
    }

    @Override
    public Tipo modificar(Tipo tipo, Integer id) {
        Tipo tip = repo.findById(id).orElse(null);
        if (tip != null) {
            tipo.setId(id);
            return repo.save(tipo);
        }
        return null;
    }

    @Override
    public Tipo delete(Integer id) {
        Tipo tipo = repo.findById(id).orElse(null);
        if (tipo != null) {
            repo.delete(tipo);
            return tipo;
        } else {
            return null;
        }
    }
}
