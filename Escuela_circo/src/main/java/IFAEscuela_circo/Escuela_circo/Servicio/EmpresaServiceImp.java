package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Empresa;
import IFAEscuela_circo.Escuela_circo.Repositorios.EmpresaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class EmpresaServiceImp implements EmpresaService {

    @Autowired
    private EmpresaRepository repo;

    @Override
    public List<Empresa> findAll() {
        return repo.findAll();
    }

    @Override
    public Empresa findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Empresa guardar(Empresa empresa) {
        return repo.save(empresa);
    }

    @Override
    public Empresa modificar(Empresa empresa, Integer id) {
        Empresa emp = repo.findById(id).orElse(null);
        if (emp != null) {
            empresa.setId(id);
            return repo.save(empresa);
        }
        return null;
    }

    @Override
    public Empresa delete(Integer id) {
        Empresa empresa = repo.findById(id).orElse(null);
        if (empresa != null) {
            repo.delete(empresa);
            return empresa;
        } else {
            return null;
        }
    }

}
