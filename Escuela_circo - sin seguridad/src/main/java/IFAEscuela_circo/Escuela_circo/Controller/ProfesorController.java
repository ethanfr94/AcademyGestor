package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Profesor;
import IFAEscuela_circo.Escuela_circo.Servicio.ProfesorServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class ProfesorController {

    @Autowired
    private ProfesorServiceImp serv;

    @GetMapping("/profesores")
    public List<Profesor> getAllProfesores() {
        return serv.findAll();
    }

    @GetMapping("/profesores/{id}")
    public Profesor getProfesorById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @PutMapping("/profesores/modificar/{id}")
    public Profesor updateProfesor(@RequestBody Profesor profesor, @PathVariable Integer id) {
        return serv.modificar(profesor, id);
    }

    @PostMapping("/profesores/insertar")
    public Profesor createProfesor(@RequestBody Profesor profesor) {
        return serv.guardar(profesor);
    }

    @DeleteMapping("/profesores/eliminar/{id}")
    public Profesor deleteProfesor(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
