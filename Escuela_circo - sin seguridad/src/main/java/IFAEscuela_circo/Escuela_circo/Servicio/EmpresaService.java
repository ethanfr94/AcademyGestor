package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Empresa;

import java.util.List;

public interface EmpresaService {
    List<Empresa> findAll();
    Empresa findById(Integer id);
    Empresa guardar(Empresa empresa);
    Empresa modificar(Empresa empresa, Integer id);
    Empresa delete(Integer id);
}
