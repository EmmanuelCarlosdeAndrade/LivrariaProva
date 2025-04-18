using BibliotecaConsoleApp.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace BibliotecaConsoleApp.DAO
{
    public class AutorDAO
    {
        public void Inserir(Autor autor)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "INSERT INTO Autor (Nome, Nacionalidade) VALUES (@Nome, @Nacionalidade)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Autor> Listar()
        {
            List<Autor> autores = new List<Autor>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "SELECT * FROM Autor";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    autores.Add(new Autor
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Nacionalidade = reader["Nacionalidade"].ToString()
                    });
                }
            }

            return autores;
        }

        public void Editar(Autor autor)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "UPDATE Autor SET Nome = @Nome, Nacionalidade = @Nacionalidade WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", autor.Id);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(int id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "DELETE FROM Autor WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
