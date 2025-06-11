package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Alumno;
import IFAEscuela_circo.Escuela_circo.Servicio.AlumnoServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class AlumnoController {

    @Autowired
    private AlumnoServiceImp serv;

    @GetMapping("/alumnos")
    public List<Alumno> getAllAlumnos() {
        return serv.findAll();
    }

    @GetMapping("/alumnos/{id}")
    public Alumno getAlumnoById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @GetMapping("/alumnos/dni/{dni}")
    public Alumno getAlumnoByDni(@PathVariable String dni) {
        return serv.findByDni(dni);
    }

    @PutMapping("/alumnos/modificar/{id}")
    public Alumno updateAlumno(@RequestBody Alumno alumno, @PathVariable Integer id) {
        return serv.modificar(alumno, id);
    }

    @PostMapping("/alumnos/insertar")
    public Alumno createAlumno(@RequestBody Alumno alumno) {
        return serv.guardar(alumno);
    }

    @DeleteMapping("/alumnos/eliminar/{id}")
    public Alumno deleteAlumno(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
