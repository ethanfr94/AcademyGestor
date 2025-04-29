package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Tutor;
import IFAEscuela_circo.Escuela_circo.Servicio.TutorServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class TutorController {

    @Autowired
    private TutorServiceImp serv;

    @GetMapping("/tutores")
    public List<Tutor> getAllTutores() {
        return serv.findAll();
    }

    @GetMapping("/tutores/{id}")
    public Tutor getTutorById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @PutMapping("/tutores/modificar/{id}")
    public Tutor updateTutor(@RequestBody Tutor tutor, @PathVariable Integer id) {
        return serv.modificar(tutor, id);
    }

    @PostMapping("/tutores/insertar")
    public Tutor addTutor(@RequestBody Tutor tutor) {
        return serv.guardar(tutor);
    }

    @DeleteMapping("/tutores/eliminar/{id}")
    public Tutor deleteTutor(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
