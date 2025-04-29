package IFAEscuela_circo.Escuela_circo.Servicio;

import IFAEscuela_circo.Escuela_circo.Modelos.Profesor;
import IFAEscuela_circo.Escuela_circo.Repositorios.ProfesorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProfesorServiceImp implements ProfesorService {

     @Autowired
     private ProfesorRepository repo;

     @Override
     public List<Profesor> findAll() {
         return repo.findAll();
     }

     @Override
     public Profesor findById(Integer id) {
         return repo.findById(id).orElse(null);
     }

     @Override
     public Profesor guardar(Profesor profesor) {
         return repo.save(profesor);
     }

     @Override
     public Profesor modificar(Profesor profesor, Integer id) {
         Profesor prof = repo.findById(id).orElse(null);
         if (prof != null) {
             profesor.setId(id);
             return repo.save(profesor);
         }
         return null;
     }

     @Override
     public Profesor delete(Integer id) {
         Profesor profesor = repo.findById(id).orElse(null);
         if (profesor != null) {
             repo.delete(profesor);
             return profesor;
         } else {
             return null;
         }
     }
}
