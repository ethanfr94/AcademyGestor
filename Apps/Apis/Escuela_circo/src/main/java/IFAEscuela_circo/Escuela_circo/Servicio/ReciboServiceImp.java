package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Recibo;
import IFAEscuela_circo.Escuela_circo.Repositorios.ReciboRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ReciboServiceImp implements ReciboService {

    @Autowired
    private ReciboRepository repo;

    @Override
    public List<Recibo> findAll() {
        return repo.findAll();
    }

    @Override
    public Recibo findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Recibo guardar(Recibo recibo) {
        return repo.save(recibo);
    }

    @Override
    public Recibo modificar(Recibo recibo, Integer id) {
        Recibo rec = repo.findById(id).orElse(null);
        if (rec != null) {
            recibo.setId(id);
            return repo.save(recibo);
        }
        return null;
    }

    @Override
    public Recibo delete(Integer id) {
        Recibo recibo = repo.findById(id).orElse(null);
        if (recibo != null) {
            repo.delete(recibo);
            return recibo;
        } else {
            return null;
        }
    }
}
