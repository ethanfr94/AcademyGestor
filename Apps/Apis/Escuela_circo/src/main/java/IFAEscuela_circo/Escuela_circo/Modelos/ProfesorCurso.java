package IFAEscuela_circo.Escuela_circo.Modelos;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;

@Entity
@Table(name = "profesor_curso")
public class ProfesorCurso {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "profesor", nullable = false)
    private Curso profesor;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "curso", nullable = false)
    private Profesor curso;

    @ColumnDefault("0")
    @Column(name = "coordinador", nullable = false)
    private Byte coordinador;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Curso getProfesor() {
        return profesor;
    }

    public void setProfesor(Curso profesor) {
        this.profesor = profesor;
    }

    public Profesor getCurso() {
        return curso;
    }

    public void setCurso(Profesor curso) {
        this.curso = curso;
    }

    public Byte getCoordinador() {
        return coordinador;
    }

    public void setCoordinador(Byte coordinador) {
        this.coordinador = coordinador;
    }

}