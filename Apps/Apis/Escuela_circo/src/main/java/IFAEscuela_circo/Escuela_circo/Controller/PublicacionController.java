package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Publicacion;
import IFAEscuela_circo.Escuela_circo.Servicio.PublicacionServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class PublicacionController {

    @Autowired
    private PublicacionServiceImp serv;

    @GetMapping("/publicaciones")
    public List<Publicacion> getPublicaciones() {
        return serv.findAll();
    }

    @GetMapping("/publicaciones/{id}")
    public Publicacion getPublicacionById(@PathVariable int id) {
        return serv.findById(id);
    }

    @PostMapping("/publicaciones/insertar")
    public Publicacion addPublicacion(@RequestBody Publicacion publicacion) {
        return serv.guardar(publicacion);
    }

    @DeleteMapping("/publicaciones/eliminar/{id}")
    public Publicacion deletePublicacionById(@PathVariable int id) {
        return serv.delete(id);
    }

}
