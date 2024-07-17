using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Cadena de conexión a la base de datos
        string connectionString = "your_connection_string_here";
        
        // Crear una instancia del controlador
        PersonaController controller = new PersonaController(connectionString);

        // Crear una nueva persona
        Persona nuevaPersona = new Persona { Nombre = "Juan", Edad = 30 };
        controller.CrearPersona(nuevaPersona);

        // Leer todas las personas
        List<Persona> personas = controller.ObtenerPersonas();
        foreach (var persona in personas)
        {
            Console.WriteLine($"Id: {persona.Id}, Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        }

        // Actualizar una persona existente
        Persona personaExistente = personas[0];
        personaExistente.Nombre = "Juan Actualizado";
        personaExistente.Edad = 31;
        controller.ActualizarPersona(personaExistente);

        // Eliminar una persona por Id
        controller.EliminarPersona(personaExistente.Id);
    }
}
