package IFAEscuela_circo.Escuela_circo.Modelos;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;

import java.time.LocalDate;

@Entity
@Table(name = "matriculas")
public class Matricula {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY) // Generación automática del ID
    @Column(name = "id", nullable = false)
    private Integer id;

    @ManyToOne(fetch = FetchType.EAGER, optional = false)
    @JoinColumn(name = "alumno", nullable = false)
    private Alumno alumno;

    @ManyToOne(fetch = FetchType.EAGER, optional = false)
    @JoinColumn(name = "curso", nullable = false)
    private Curso curso;

    @Column(name = "fech_alta", nullable = false)
    private LocalDate fechAlta;

    @Column(name = "fech_baja")
    private LocalDate fechBaja;

    @ColumnDefault("0")
    @Column(name = "autorizacion_fotos", nullable = false)
    private Byte autorizacionFotos;

    @ColumnDefault("0")
    @Column(name = "beca", nullable = false)
    private Byte beca;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Alumno getAlumno() {
        return alumno;
    }

    public void setAlumno(Alumno alumno) {
        this.alumno = alumno;
    }

    public Curso getCurso() {
        return curso;
    }

    public void setCurso(Curso curso) {
        this.curso = curso;
    }

    public LocalDate getFechAlta() {
        return fechAlta;
    }

    public void setFechAlta(LocalDate fechAlta) {
        this.fechAlta = fechAlta;
    }

    public LocalDate getFechBaja() {
        return fechBaja;
    }

    public void setFechBaja(LocalDate fechBaja) {
        this.fechBaja = fechBaja;
    }

    public Byte getAutorizacionFotos() {
        return autorizacionFotos;
    }

    public void setAutorizacionFotos(Byte autorizacionFotos) {
        this.autorizacionFotos = autorizacionFotos;
    }

    public Byte getBeca() {
        return beca;
    }

    public void setBeca(Byte beca) {
        this.beca = beca;
    }

}