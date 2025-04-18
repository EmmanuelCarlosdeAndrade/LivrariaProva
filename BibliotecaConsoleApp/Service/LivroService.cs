using BibliotecaConsoleApp.DAO;
using BibliotecaConsoleApp.Model;
using System;
using System.Collections.Generic;

namespace BibliotecaConsoleApp.Service
{
    public class LivroService
    {
        private LivroDAO livroDAO;

        public LivroService()
        {
            livroDAO = new LivroDAO();
        }

        public void CadastrarLivro(string titulo, string genero, int anoPublicacao, int autorId)
        {
            Livro livro = new Livro
            {
                Titulo = titulo,
                Genero = genero,
                AnoPublicacao = anoPublicacao,
                AutorId = autorId
            };

            livroDAO.Inserir(livro);
            Console.WriteLine("Livro cadastrado com sucesso!\n");
        }

        public List<Livro> ObterTodosLivros()
        {
            return livroDAO.Listar();
        }

        public void EditarLivro(int id, string titulo, string genero, int anoPublicacao, int autorId)
        {
            Livro livro = new Livro
            {
                Id = id,
                Titulo = titulo,
                Genero = genero,
                AnoPublicacao = anoPublicacao,
                AutorId = autorId
            };

            livroDAO.Editar(livro);
            Console.WriteLine("Livro atualizado com sucesso!\n");
        }

        public void RemoverLivro(int id)
        {
            livroDAO.Remover(id);
            Console.WriteLine("Livro removido com sucesso!\n");
        }
    }
}
