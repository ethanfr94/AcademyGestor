package IFAEscuela_circo.Escuela_circo.Repositorios;

import IFAEscuela_circo.Escuela_circo.Modelos.Usuario;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UsuarioRepository extends JpaRepository<Usuario, Integer> {
}
