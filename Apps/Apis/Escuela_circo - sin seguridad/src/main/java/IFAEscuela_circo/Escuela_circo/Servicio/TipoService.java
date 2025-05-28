package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Tipo;

import java.util.List;

public interface TipoService {
    List<Tipo> findAll();
    Tipo findById(Integer id);
    Tipo guardar(Tipo tipo);
    Tipo modificar(Tipo tipo, Integer id);
    Tipo delete(Integer id);
}
