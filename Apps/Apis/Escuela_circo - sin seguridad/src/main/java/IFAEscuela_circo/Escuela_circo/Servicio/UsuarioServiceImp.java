package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Usuario;
import IFAEscuela_circo.Escuela_circo.Repositorios.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UsuarioServiceImp implements UsuarioService {

    @Autowired
    private UsuarioRepository repo;

    @Override
    public List<Usuario> findAll() {
        return repo.findAll();
    }

    @Override
    public Usuario findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Usuario guardar(Usuario usuario) {
        return repo.save(usuario);
    }

    public Usuario loggin(String usuario, String password) {
        List<Usuario> usuarios = repo.findAll();
        for (Usuario user : usuarios) {
            if(user.getUser().equals(usuario) && user.getPass().equals(password)) {
                return user;
            }
        }
        return null;
    }

    @Override
    public Usuario modificar(Usuario usuario, Integer id) {
        Usuario user = repo.findById(id).orElse(null);
        if (user != null) {
            usuario.setId(id);
            return repo.save(usuario);
        }
        return null;
    }

    @Override
    public Usuario delete(Integer id) {
        Usuario usuario = repo.findById(id).orElse(null);
        if (usuario != null) {
            repo.delete(usuario);
            return usuario;
        } else {
            return null;
        }
    }
}
