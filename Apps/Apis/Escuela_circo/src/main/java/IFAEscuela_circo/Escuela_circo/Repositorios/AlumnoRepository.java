package IFAEscuela_circo.Escuela_circo.Repositorios;

import IFAEscuela_circo.Escuela_circo.Modelos.Alumno;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AlumnoRepository extends JpaRepository<Alumno, Integer> {
}
