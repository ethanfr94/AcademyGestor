package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Usuario;
import IFAEscuela_circo.Escuela_circo.Servicio.UsuarioServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class UsuarioController {

    @Autowired
    private UsuarioServiceImp serv;

    @GetMapping("/usuarios")
    public List<Usuario> getUsuarios() {
        return serv.findAll();
    }

    @GetMapping("/usuarios/{id}")
    public Usuario getUsuarioById(@PathVariable int id) {
        return serv.findById(id);
    }

    @PutMapping("/usuarios/modificar/{id}")
    public Usuario updateUsuarioById(@RequestBody Usuario usuario, @PathVariable int id) {
        return serv.modificar(usuario, id);
    }

    @PostMapping("/usuarios/insertar")
    public Usuario addUsuario(@RequestBody Usuario usuario) {
        return serv.guardar(usuario);
    }

    @DeleteMapping("/usuarios/eliminar/{id}")
    public Usuario deleteUsuarioById(@PathVariable int id) {
        return serv.delete(id);
    }




}
