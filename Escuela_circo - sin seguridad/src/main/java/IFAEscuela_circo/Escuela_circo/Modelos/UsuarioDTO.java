package IFAEscuela_circo.Escuela_circo.Modelos;

import java.io.Serializable;
import java.util.Objects;

/**
 * DTO for {@link IFAEscuela_circo.Escuela_circo.Modelos.Usuario}
 */
public class UsuarioDTO implements Serializable {
    private final Integer id;
    private final String user;
    private final String rol;

    public UsuarioDTO(Integer id, String user, String rol) {
        this.id = id;
        this.user = user;
        this.rol = rol;
    }

    public Integer getId() {
        return id;
    }

    public String getUser() {
        return user;
    }

    public String getRol() {
        return rol;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        UsuarioDTO entity = (UsuarioDTO) o;
        return Objects.equals(this.id, entity.id) &&
                Objects.equals(this.user, entity.user) &&
                Objects.equals(this.rol, entity.rol);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, user, rol);
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "(" +
                "id = " + id + ", " +
                "user = " + user + ", " +
                "rol = " + rol + ")";
    }
}