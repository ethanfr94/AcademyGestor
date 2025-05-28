package IFAEscuela_circo.Escuela_circo.Controller;

import IFAEscuela_circo.Escuela_circo.Modelos.Tipo;
import IFAEscuela_circo.Escuela_circo.Servicio.TipoService;
import IFAEscuela_circo.Escuela_circo.Servicio.TipoServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class TipoController {

    @Autowired
    private TipoServiceImp serv;

    @GetMapping("/tipos")
    public List<Tipo> getTipos() {
        return serv.findAll();
    }

    @GetMapping("/tipos/{id}")
    public ResponseEntity<Tipo> getTipoById(@PathVariable Integer id) {
        Tipo tipo = serv.findById(id);
        if (tipo != null) {
            return ResponseEntity.ok(tipo);
        } else {
            return ResponseEntity.notFound().build();
        }
    }
}
