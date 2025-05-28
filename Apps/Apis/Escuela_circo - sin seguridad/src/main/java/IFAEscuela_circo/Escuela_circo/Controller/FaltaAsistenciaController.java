package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.FaltasAsistencia;
import IFAEscuela_circo.Escuela_circo.Servicio.FaltaAsistenciaServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class FaltaAsistenciaController {

    @Autowired
    private FaltaAsistenciaServiceImp serv;

    @GetMapping("/faltas_asistencia")
    public List<FaltasAsistencia> getFaltasAsistencia() {
        return serv.findAll();
    }

    @PostMapping("/faltas_asistencia/insertar")
    public FaltasAsistencia createFaltasAsistencia(@RequestBody FaltasAsistencia faltasAsistencia) {
        return serv.guardar(faltasAsistencia);
    }

    @GetMapping("/faltas_asistencia/{id}")//id del alumno
    public List<FaltasAsistencia> getFaltasAsistenciaByAlumnoId(@PathVariable Integer id) {
        return serv.findByAlumnoId(id);
    }

    @DeleteMapping("/faltas_asistencia/eliminar/{id}")
    public FaltasAsistencia deleteFaltasAsistencia(@PathVariable Integer id) {
        return serv.delete(id);
    }
}
