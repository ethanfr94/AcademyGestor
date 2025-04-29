package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Usuario;

import java.util.List;

public interface UsuarioService {
    List<Usuario> findAll();
    Usuario findById(Integer id);
    Usuario guardar(Usuario usuario);
    Usuario modificar(Usuario usuario, Integer id);
    Usuario delete(Integer id);
}
