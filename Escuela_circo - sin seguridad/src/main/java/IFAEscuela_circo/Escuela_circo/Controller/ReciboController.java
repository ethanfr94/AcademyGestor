package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Recibo;
import IFAEscuela_circo.Escuela_circo.Servicio.ReciboServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class ReciboController {

    @Autowired
    private ReciboServiceImp serv;

    @GetMapping("/recibos")
    public List<Recibo> getRecibos() {
        return serv.findAll();
    }

    @GetMapping("/recibos/{id}")
    public Recibo getReciboById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @PutMapping("/recibos/modificar/{id}")
    public Recibo updateRecibo(@RequestBody Recibo recibo, @PathVariable Integer id) {
        return serv.modificar(recibo, id);
    }
    @PutMapping("/recibos/cobrar")
    public Recibo cobrarRecibo(@RequestBody Recibo recibo) {
        return serv.cobrar(recibo);
    }

    @PostMapping("/recibos/insertar")
    public Recibo addRecibo(@RequestBody Recibo recibo) {
        return serv.guardar(recibo);
    }

    @DeleteMapping("/recibos/eliminar/{id}")
    public Recibo deleteRecibo(@PathVariable Integer id) {
        return serv.delete(id);
    }

}
