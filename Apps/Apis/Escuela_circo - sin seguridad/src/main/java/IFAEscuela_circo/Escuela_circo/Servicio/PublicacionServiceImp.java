package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Publicacion;
import IFAEscuela_circo.Escuela_circo.Repositorios.PublicacionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.multipart.support.StandardServletMultipartResolver;

import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.List;

@Service
public class PublicacionServiceImp implements PublicacionService {

    @Autowired
    private PublicacionRepository repo;
    @Autowired
    private StandardServletMultipartResolver multipartResolver;

    @Override
    public List<Publicacion> findAll() {
        return repo.findAll();
    }

    @Override
    public Publicacion findById(Integer id) {
        return repo.findById(id).orElse(null);
    }

    @Override
    public Publicacion guardar(Publicacion publicacion) {
        return repo.save(publicacion);
    }

    @Override
    public Publicacion modificar(Publicacion publicacion, Integer id) {
        Publicacion publi = repo.findById(id).orElse(null);
        if (publi != null) {
            publicacion.setId(id);
            publicacion.setTimestamp(publi.getTimestamp());
            publicacion.setTipo(publi.getTipo());
            publicacion.setUrl(publi.getUrl());
            publicacion.setProfesor(publi.getProfesor());
            return repo.save(publicacion);
        }
        return null;
    }

    @Override
    public Publicacion delete(Integer id) {
        Publicacion publicacion = repo.findById(id).orElse(null);
        if (publicacion != null) {
            repo.delete(publicacion);
            return publicacion;
        } else {
            return null;
        }
    }

    public boolean uploadFile(String urlDestino, String nombre, MultipartFile file) throws IOException {
        boolean ok = false;
        Path ruta = Paths.get(urlDestino);

        if(!Files.exists(ruta)) {
            try {
                Files.createDirectories(ruta);
            } catch (IOException e) {
                throw new IOException("Error al crear el directorio: " + e.getMessage());
            }
        }

        try(InputStream input = file.getInputStream()){
            Path rutaFichero = ruta.resolve(nombre);
            Files.copy(input, rutaFichero, StandardCopyOption.REPLACE_EXISTING);
            ok = true;
        } catch (IOException e) {
            throw new IOException("Error al guardar el fichero: " + nombre + " ERROR: "+e.getMessage());
        }
        return ok;
    }
}
