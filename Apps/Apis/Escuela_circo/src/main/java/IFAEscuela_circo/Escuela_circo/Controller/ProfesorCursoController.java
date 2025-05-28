package IFAEscuela_circo.Escuela_circo.Controller;

import IFAEscuela_circo.Escuela_circo.Modelos.ProfesorCurso;
import IFAEscuela_circo.Escuela_circo.Servicio.ProfesorCursoServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;


@RestController
@RequestMapping("/escuela_circo")
public class ProfesorCursoController {

    @Autowired
    private ProfesorCursoServiceImp serv;

    @GetMapping("/profesoresCurso")
    public List<ProfesorCurso> getAllProfesores() {
        return serv.findAll();
    }

    @GetMapping("/profesoresCurso/{id}")
    public ProfesorCurso getProfesorById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @GetMapping("/profesoresCurso/curso/{id}")
    public List<ProfesorCurso> getProfesoresByCursoId(@PathVariable Integer id) {
        return serv.findByCursoId(id);
    }

    @PutMapping("/profesoresCurso/modificar/{id}")
    public ProfesorCurso updateProfesor(@RequestBody ProfesorCurso profesor, @PathVariable Integer id) {
        return serv.modificar(profesor, id);
    }

    @PostMapping("/profesoresCurso/insertar")
    public ProfesorCurso createProfesor(@RequestBody ProfesorCurso profesor) {
        return serv.guardar(profesor);
    }

    @DeleteMapping("/profesoresCurso/eliminar/{id}")
    public ProfesorCurso deleteProfesor(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
