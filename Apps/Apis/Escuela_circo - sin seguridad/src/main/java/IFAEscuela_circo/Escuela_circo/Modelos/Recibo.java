package IFAEscuela_circo.Escuela_circo.Modelos;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;

import java.math.BigDecimal;
import java.time.LocalDate;

@Entity
@Table(name = "recibos")
public class Recibo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY) // Generación automática del ID

    @Column(name = "id", nullable = false)
    private Integer id;

    @ManyToOne(fetch = FetchType.EAGER, optional = false)
    @JoinColumn(name = "matricula", nullable = false)
    private Matricula matricula;

    @Column(name = "detalle", nullable = false, length = 100)
    private String detalle;

    @Column(name = "fecha", nullable = false)
    private LocalDate fecha;

    @Column(name = "importe", nullable = false, precision = 10)
    private BigDecimal importe;

    @ColumnDefault("0")
    @Column(name = "descuento", nullable = false)
    private Byte descuento;

    @ColumnDefault("0")
    @Column(name = "pagado", nullable = false)
    private Byte pagado;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Matricula getMatricula() {
        return matricula;
    }

    public void setMatricula(Matricula matricula) {
        this.matricula = matricula;
    }

    public String getDetalle() {
        return detalle;
    }

    public void setDetalle(String detalle) {
        this.detalle = detalle;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setFecha(LocalDate fecha) {
        this.fecha = fecha;
    }

    public BigDecimal getImporte() {
        return importe;
    }

    public void setImporte(BigDecimal importe) {
        this.importe = importe;
    }

    public Byte getDescuento() {
        return descuento;
    }

    public void setDescuento(Byte descuento) {
        this.descuento = descuento;
    }

    public Byte getPagado() {
        return pagado;
    }

    public void setPagado(Byte pagado) {
        this.pagado = pagado;
    }

}