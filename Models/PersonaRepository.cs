using System;
using System.Collections.Generic;
using System.Data.SqlClient;

// Clase que maneja las operaciones CRUD para la entidad Persona
public class PersonaRepository
{
    // Cadena de conexión a la base de datos
    private string connectionString;

    // Constructor que recibe la cadena de conexión
    public PersonaRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Método para crear una nueva persona en la base de datos
    public void Crear(Persona persona)
    {
        // Usando la conexión a SQL Server
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Consulta SQL para insertar una nueva persona
            string query = "INSERT INTO Personas (Nombre, Edad) VALUES (@Nombre, @Edad)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", persona.Nombre);
            command.Parameters.AddWithValue("@Edad", persona.Edad);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Método para leer todas las personas de la base de datos
    public List<Persona> Leer()
    {
        List<Persona> personas = new List<Persona>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Consulta SQL para seleccionar todas las personas
            string query = "SELECT Id, Nombre, Edad FROM Personas";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Persona persona = new Persona
                {
                    Id = (int)reader["Id"],
                    Nombre = (string)reader["Nombre"],
                    Edad = (int)reader["Edad"]
                };
                personas.Add(persona);
            }
        }

        return personas;
    }

    // Método para actualizar una persona existente en la base de datos
    public void Actualizar(Persona persona)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Consulta SQL para actualizar una persona
            string query = "UPDATE Personas SET Nombre = @Nombre, Edad = @Edad WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", persona.Id);
            command.Parameters.AddWithValue("@Nombre", persona.Nombre);
            command.Parameters.AddWithValue("@Edad", persona.Edad);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Método para eliminar una persona de la base de datos
    public void Eliminar(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Consulta SQL para eliminar una persona por Id
            string query = "DELETE FROM Personas WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
