package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Curso;
import IFAEscuela_circo.Escuela_circo.Servicio.CursoServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class CursoController {

    @Autowired
    private CursoServiceImp serv;

    @GetMapping("/cursos")
    public List<Curso> getCursos() {
        return serv.findAll();
    }

    @GetMapping("/cursos/{id}")
    public Curso getCursoById(@PathVariable Integer id) {
        return serv.findById(id);
    }

    @PutMapping("/cursos/modificar/{id}")
    public Curso updateCurso(@RequestBody Curso curso, @PathVariable Integer id) {
        return serv.modificar(curso, id);
    }

    @PostMapping("/cursos/insertar")
    public Curso createCurso(@RequestBody Curso curso) {
        return serv.guardar(curso);
    }

    @DeleteMapping("/cursos/eliminar/{id}")
    public Curso deleteCurso(@PathVariable Integer id) {
        return serv.delete(id);
    }

}
