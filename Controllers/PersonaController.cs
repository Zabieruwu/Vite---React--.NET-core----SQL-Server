using System;
using System.Collections.Generic;

// Clase que actúa como controlador para la entidad Persona
public class PersonaController
{
    private PersonaRepository repo;

    // Constructor que recibe una instancia del repositorio
    public PersonaController(string connectionString)
    {
        repo = new PersonaRepository(connectionString);
    }

    // Método para crear una nueva persona
    public void CrearPersona(Persona persona)
    {
        repo.Crear(persona);
    }

    // Método para obtener todas las personas
    public List<Persona> ObtenerPersonas()
    {
        return repo.Leer();
    }

    // Método para actualizar una persona existente
    public void ActualizarPersona(Persona persona)
    {
        repo.Actualizar(persona);
    }

    // Método para eliminar una persona por Id
    public void EliminarPersona(int id)
    {
        repo.Eliminar(id);
    }
}
