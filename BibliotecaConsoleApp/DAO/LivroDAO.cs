using BibliotecaConsoleApp.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace BibliotecaConsoleApp.DAO
{
    public class LivroDAO
    {
        public void Inserir(Livro livro)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "INSERT INTO Livro (Titulo, Genero, AnoPublicacao, AutorId) VALUES (@Titulo, @Genero, @Ano, @AutorId)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
                cmd.Parameters.AddWithValue("@Genero", livro.Genero);
                cmd.Parameters.AddWithValue("@Ano", livro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@AutorId", livro.AutorId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Livro> Listar()
        {
            List<Livro> livros = new List<Livro>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"
                    SELECT l.*, a.Nome AS NomeAutor, a.Nacionalidade AS NacionalidadeAutor
                    FROM Livro l
                    JOIN Autor a ON l.AutorId = a.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    livros.Add(new Livro
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Titulo = reader["Titulo"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        AnoPublicacao = Convert.ToInt32(reader["AnoPublicacao"]),
                        AutorId = Convert.ToInt32(reader["AutorId"]),
                        NomeAutor = reader["NomeAutor"].ToString(),
                        NacionalidadeAutor = reader["NacionalidadeAutor"].ToString()
                    });
                }
            }

            return livros;
        }

        public void Editar(Livro livro)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "UPDATE Livro SET Titulo = @Titulo, Genero = @Genero, AnoPublicacao = @Ano, AutorId = @AutorId WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", livro.Id);
                cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
                cmd.Parameters.AddWithValue("@Genero", livro.Genero);
                cmd.Parameters.AddWithValue("@Ano", livro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@AutorId", livro.AutorId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(int id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = "DELETE FROM Livro WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
