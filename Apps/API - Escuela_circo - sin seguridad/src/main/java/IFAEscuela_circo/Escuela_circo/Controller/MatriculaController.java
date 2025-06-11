package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Matricula;
import IFAEscuela_circo.Escuela_circo.Servicio.MatriculaServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class MatriculaController {

    @Autowired
    private MatriculaServiceImp serv;

    @GetMapping("/matriculas")
    public List<Matricula> getMatriculas() {
        return serv.findAll();
    }

    @GetMapping("/matriculas/{id}")
    public Matricula getMatriculaById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @PutMapping("/matriculas/modificar/{id}")
    public Matricula updateMatricula(@RequestBody Matricula matricula, @PathVariable Integer id) {
        return serv.modificar(matricula, id);
    }

    @PutMapping("/matriculas/baja")
    public Matricula bajaMatricula(@RequestBody Matricula matricula) {
        return serv.baja(matricula);
    }

    @PostMapping("/matriculas/insertar")
    public Matricula addMatricula(@RequestBody Matricula matricula) {
        matricula.setFechAlta(LocalDate.now());
        matricula.setFechBaja(null);
        return serv.guardar(matricula);
    }

    @DeleteMapping("/matriculas/eliminar/{id}")
    public Matricula deleteMatricula(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
