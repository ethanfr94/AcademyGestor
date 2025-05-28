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

    @GetMapping("/profesoresCurso/curso/profesor/{idCurso}/{idProfesor}")
    public ProfesorCurso getProfesoresByCursoYProfesor(@PathVariable Integer idCurso, @PathVariable Integer idProfesor) {
        return serv.findByCursoYProfesor(idCurso, idProfesor);
    }

    @PutMapping("/profesoresCurso/modificar/{id}")
    public ProfesorCurso updateProfesor(@RequestBody ProfesorCurso profesor, @PathVariable Integer id) {
        return serv.modificar(profesor, id);
    }

    @PutMapping("/profesoresCurso/modificar/coordinador/{id}")
    public ProfesorCurso updateCoordinadorByProfesorYCurso(@PathVariable ProfesorCurso id) {
        return serv.updateCoordinadorByProfesorYCurso(id.getCurso().getId(), id.getProfesor().getId());
    }

    @PostMapping("/profesoresCurso/insertar")
    public ProfesorCurso createProfesor(@RequestBody ProfesorCurso profesor) {
        return serv.guardar(profesor);
    }

    @DeleteMapping("/profesoresCurso/eliminar/{id}")
    public ProfesorCurso deleteProfesor(@PathVariable Integer id) {
        return serv.delete(id);
    }

    @DeleteMapping("/profesoresCurso/eliminar/curso/profesor/{idCurso}/{idProfesor}")
    public ProfesorCurso deleteProfesorCursoByCursoAndProfesor(@PathVariable Integer idCurso, @PathVariable Integer idProfesor) {
        return serv.deleteByProfesorYCurso(idCurso, idProfesor);
    }
}
