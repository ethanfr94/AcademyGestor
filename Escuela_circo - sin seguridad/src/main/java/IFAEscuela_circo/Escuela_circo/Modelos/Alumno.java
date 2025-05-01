package IFAEscuela_circo.Escuela_circo.Modelos;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;

import java.time.LocalDate;

@Entity
@Table(name = "alumnos", uniqueConstraints = {
        @UniqueConstraint(name = "dni", columnNames = {"dni"}),
        @UniqueConstraint(name = "email", columnNames = {"email"})
})
public class Alumno {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY) // Generación automática del ID
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "nombre", nullable = false, length = 50)
    private String nombre;

    @Column(name = "apellido1", nullable = false, length = 50)
    private String apellido1;

    @Column(name = "apellido2", nullable = false, length = 50)
    private String apellido2;

    @Column(name = "dni", nullable = false, length = 9)
    private String dni;

    @Column(name = "fecha_nac", nullable = false)
    private LocalDate fechaNac;

    @Column(name = "direccion", nullable = false, length = 100)
    private String direccion;

    @Column(name = "localidad", nullable = false, length = 50)
    private String localidad;

    @Column(name = "email", nullable = false, length = 100)
    private String email;

    @Column(name = "telefono", length = 9)
    private String telefono;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "tutor", nullable = true)
    private Tutor tutor;

    @ColumnDefault("0")
    @Column(name = "proteccion_datos", nullable = false)
    private Byte proteccionDatos;

    @ColumnDefault("0")
    @Column(name = "grupo_whatsapp", nullable = false)
    private Byte grupoWhatsapp;

    @ColumnDefault("0")
    @Column(name = "comunicaciones_comerciales", nullable = false)
    private Byte comunicacionesComerciales;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellido1() {
        return apellido1;
    }

    public void setApellido1(String apellido1) {
        this.apellido1 = apellido1;
    }

    public String getApellido2() {
        return apellido2;
    }

    public void setApellido2(String apellido2) {
        this.apellido2 = apellido2;
    }

    public String getDni() {
        return dni;
    }

    public void setDni(String dni) {
        this.dni = dni;
    }

    public LocalDate getFechaNac() {
        return fechaNac;
    }

    public void setFechaNac(LocalDate fechaNac) {
        this.fechaNac = fechaNac;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getLocalidad() {
        return localidad;
    }

    public void setLocalidad(String localidad) {
        this.localidad = localidad;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public Tutor getTutor() {
        return tutor;
    }

    public void setTutor(Tutor tutor) {
        this.tutor = tutor;
    }

    public Byte getProteccionDatos() {
        return proteccionDatos;
    }

    public void setProteccionDatos(Byte proteccionDatos) {
        this.proteccionDatos = proteccionDatos;
    }

    public Byte getGrupoWhatsapp() {
        return grupoWhatsapp;
    }

    public void setGrupoWhatsapp(Byte grupoWhatsapp) {
        this.grupoWhatsapp = grupoWhatsapp;
    }

    public Byte getComunicacionesComerciales() {
        return comunicacionesComerciales;
    }

    public void setComunicacionesComerciales(Byte comunicacionesComerciales) {
        this.comunicacionesComerciales = comunicacionesComerciales;
    }

}