package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Solicitud;
import IFAEscuela_circo.Escuela_circo.Servicio.SolicitudServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class SolicitudController {

    @Autowired
    private SolicitudServiceImp serv;

    @GetMapping("/solicitudes")
    public List<Solicitud> getAllSolicitudes() {
        return serv.findAll();
    }

    @GetMapping("/solicitudes/{id}")
    public Solicitud getSolicitudById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @PostMapping("/solicitudes/insertar")
    public Solicitud createSolicitud(@RequestBody Solicitud solicitud) {
        return serv.guardar(solicitud);
    }

    @DeleteMapping("/solicitudes/eliminar/{id}")
    public Solicitud deleteSolicitud(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
