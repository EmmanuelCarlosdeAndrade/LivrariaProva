using BibliotecaConsoleApp.DAO;
using BibliotecaConsoleApp.Model;
using System;
using System.Collections.Generic;

namespace BibliotecaConsoleApp.Service
{
    public class AutorService
    {
        private AutorDAO autorDAO;

        public AutorService()
        {
            autorDAO = new AutorDAO();
        }

        public void CadastrarAutor(string nome, string nacionalidade)
        {
            Autor autor = new Autor
            {
                Nome = nome,
                Nacionalidade = nacionalidade
            };

            autorDAO.Inserir(autor);
            Console.WriteLine("Autor cadastrado com sucesso!\n");
        }

        public List<Autor> ObterTodosAutores()
        {
            return autorDAO.Listar();
        }

        public void EditarAutor(int id, string nome, string nacionalidade)
        {
            Autor autor = new Autor
            {
                Id = id,
                Nome = nome,
                Nacionalidade = nacionalidade
            };

            autorDAO.Editar(autor);
            Console.WriteLine("Autor atualizado com sucesso!\n");
        }

        public void RemoverAutor(int id)
        {
            autorDAO.Remover(id);
            Console.WriteLine("Autor removido com sucesso!\n");
        }
    }
}
