package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Usuario;
import IFAEscuela_circo.Escuela_circo.Repositorios.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
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
        usuario.setPass(codificarMD5(usuario.getPass()));
        return repo.save(usuario);
    }

    public Usuario loggin(String usuario, String password) {
        List<Usuario> usuarios = repo.findAll();
        String passwordCodificada = codificarMD5(password); // Codificar contraseña ingresada
        for (Usuario user : usuarios) {
            if (user.getUser().equals(usuario) && user.getPass().equals(passwordCodificada)) {
                return user;
            }
        }
        return null;
    }

    @Override
    public Usuario modificar(Usuario usuario, Integer id) {
        Usuario userExistente = repo.findById(id).orElse(null);
        if (userExistente != null) {
            usuario.setId(id);
            // Verificar si la contraseña ha cambiado
            if (!userExistente.getPass().equals(usuario.getPass())) {
                usuario.setPass(codificarMD5(usuario.getPass())); // Codificar solo si ha cambiado
            } else {
                usuario.setPass(userExistente.getPass()); // Mantener la contraseña existente
            }
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

    private String codificarMD5(String input) {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] messageDigest = md.digest(input.getBytes());
            StringBuilder sb = new StringBuilder();
            for (byte b : messageDigest) {
                sb.append(String.format("%02x", b));
            }
            return sb.toString();
        } catch (NoSuchAlgorithmException e) {
            throw new RuntimeException("Error al codificar la contraseña en MD5", e);
        }
    }
}
