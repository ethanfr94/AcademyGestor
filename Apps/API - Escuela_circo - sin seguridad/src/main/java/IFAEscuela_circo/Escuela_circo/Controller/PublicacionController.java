package IFAEscuela_circo.Escuela_circo.Controller;


import IFAEscuela_circo.Escuela_circo.Modelos.Publicacion;
import IFAEscuela_circo.Escuela_circo.Servicio.PublicacionServiceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.util.StringUtils;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.time.Instant;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Objects;

@RestController
@RequestMapping("/escuela_circo")
public class PublicacionController {

    @Autowired
    private PublicacionServiceImp serv;

    @GetMapping("/publicaciones")
    public List<Publicacion> getPublicaciones() {
        return serv.findAll();
    }

    @GetMapping("/publicaciones/{id}")
    public Publicacion getPublicacionById(@PathVariable int id) {
        return serv.findById(id);
    }

    @PutMapping("/publicaciones/modificar/{id}")
    public Publicacion updatePublicacionById(@RequestBody Publicacion publicacion, @PathVariable int id) {
        return serv.modificar(publicacion, id);
    }

    @PostMapping("/publicaciones/insertar")
    public Publicacion addPublicacion(@RequestBody Publicacion publicacion, @RequestParam("fichero") MultipartFile multipartFile) {

        if (publicacion.getTipo().equalsIgnoreCase("texto") && multipartFile != null) {
            return serv.guardar(publicacion);
        }

        // Limpia el nombre del archivo
        String nombreArchivo = StringUtils.cleanPath(Objects.requireNonNull(multipartFile.getOriginalFilename()));


        // Directorio donde se almacenará el archivo
        String uploadDir = "imagenes/" + publicacion.getTimestamp() + "_" + publicacion.getTitulo().replaceAll(" ", "_");

        // Crear el directorio si no existe
        File directory = new File(uploadDir);
        if (!directory.exists()) {
            directory.mkdirs();
        }

        // Obtener la extensión del archivo
        String extension = nombreArchivo.split(".")[1];

        // Validar si el archivo es una imagen o un PDF
        boolean esImagen = extension.equals("jpg") || extension.equals("jpeg") || extension.equals("png");

        if (!multipartFile.isEmpty()) {
            if (esImagen) {
                try {
                    if (serv.uploadFile(uploadDir, nombreArchivo, multipartFile)) {
                        // Guardar la URL de la imagen en la base de datos
                        publicacion.setUrl(uploadDir + "/" + nombreArchivo);
                        publicacion.setTimestamp(LocalDateTime.now());
                        return serv.guardar(publicacion);
                    } else {
                        return null;
                    }
                } catch (IOException e) {

                }
            }
        }
        return null;
    }

    @DeleteMapping("/publicaciones/eliminar/{id}")
    public Publicacion deletePublicacionById(@PathVariable int id) {
        return serv.delete(id);
    }

}
