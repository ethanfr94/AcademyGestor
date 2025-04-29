package IFAEscuela_circo.Escuela_circo.Controller;

import IFAEscuela_circo.Escuela_circo.Modelos.Empresa;
import IFAEscuela_circo.Escuela_circo.Servicio.EmpresaServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/escuela_circo")
public class EmpresaController {

    @Autowired
    private EmpresaServiceImp serv;

    @GetMapping("/empresa")
    public Empresa getEmpresa() {
        return serv.findAll().getFirst();
    }
}
