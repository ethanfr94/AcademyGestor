package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Recibo;

import java.util.List;

public interface ReciboService {
    List<Recibo> findAll();
    Recibo findById(Integer id);
    Recibo guardar(Recibo recibo);
    Recibo modificar(Recibo recibo, Integer id);
    Recibo delete(Integer id);
}
