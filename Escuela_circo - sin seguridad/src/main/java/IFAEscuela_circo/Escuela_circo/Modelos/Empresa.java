package IFAEscuela_circo.Escuela_circo.Modelos;

import jakarta.persistence.*;

@Entity
@Table(name = "empresa", uniqueConstraints = {
        @UniqueConstraint(name = "cif", columnNames = {"cif"}),
        @UniqueConstraint(name = "email", columnNames = {"email"})
})
public class Empresa {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "nombre", nullable = false, length = 50)
    private String nombre;

    @Column(name = "razon_fiscal", nullable = false, length = 50)
    private String razonFiscal;

    @Column(name = "cif", nullable = false, length = 9)
    private String cif;

    @Column(name = "email", nullable = false, length = 100)
    private String email;

    @Column(name = "telefono", nullable = false, length = 9)
    private String telefono;

    @Column(name = "direccion", nullable = false, length = 100)
    private String direccion;

    @Column(name = "localidad", nullable = false, length = 50)
    private String localidad;

    @Column(name = "provincia", nullable = false, length = 50)
    private String provincia;

    @Column(name = "cp", nullable = false, length = 5)
    private String cp;

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

    public String getRazonFiscal() {
        return razonFiscal;
    }

    public void setRazonFiscal(String razonFiscal) {
        this.razonFiscal = razonFiscal;
    }

    public String getCif() {
        return cif;
    }

    public void setCif(String cif) {
        this.cif = cif;
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

    public String getProvincia() {
        return provincia;
    }

    public void setProvincia(String provincia) {
        this.provincia = provincia;
    }

    public String getCp() {
        return cp;
    }

    public void setCp(String cp) {
        this.cp = cp;
    }

}