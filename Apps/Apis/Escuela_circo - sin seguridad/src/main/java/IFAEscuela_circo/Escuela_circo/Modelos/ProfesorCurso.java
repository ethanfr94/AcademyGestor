package IFAEscuela_circo.Escuela_circo.Modelos;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;

@Entity
@Table(name = "profesor_curso")
public class ProfesorCurso {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY) // Generación automática del ID

    @Column(name = "id", nullable = false)
    private Integer id;

    @ManyToOne(fetch = FetchType.EAGER, optional = false)
    @JoinColumn(name = "profesor", nullable = false)
    private Profesor profesor;

    @ManyToOne(fetch = FetchType.EAGER, optional = false)
    @JoinColumn(name = "curso", nullable = false)
    private Curso curso;

    @ColumnDefault("0")
    @Column(name = "coordinador", nullable = false)
    private Byte coordinador;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Profesor getProfesor() {
        return profesor;
    }

    public void setProfesor(Profesor profesor) {
        this.profesor = profesor;
    }

    public Curso getCurso() {
        return curso;
    }

    public void setCurso(Curso curso) {
        this.curso = curso;
    }

    public Byte getCoordinador() {
        return coordinador;
    }

    public void setCoordinador(Byte coordinador) {
        this.coordinador = coordinador;
    }

}