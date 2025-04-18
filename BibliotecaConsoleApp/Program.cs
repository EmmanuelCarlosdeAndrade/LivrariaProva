using BibliotecaConsoleApp.Service;
using BibliotecaConsoleApp.Model;
using System;

namespace BibliotecaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AutorService autorService = new AutorService();
            LivroService livroService = new LivroService(); // Adicionando o serviço de livros

            int opcao;
            do
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1 - Inserir Autor");
                Console.WriteLine("2 - Listar Autores");
                Console.WriteLine("3 - Editar Autor");
                Console.WriteLine("4 - Remover Autor");
                Console.WriteLine("5 - Inserir Livro");
                Console.WriteLine("6 - Listar Livros");
                Console.WriteLine("7 - Editar Livro");
                Console.WriteLine("8 - Remover Livro");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                    continue;
                }

                Console.Clear();

                switch (opcao)
                {
                    // CRUD para Autores
                    case 1:
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Nacionalidade: ");
                        string nacionalidade = Console.ReadLine();
                        autorService.CadastrarAutor(nome, nacionalidade);
                        break;

                    case 2:
                        var autores = autorService.ObterTodosAutores();
                        Console.WriteLine("=== Lista de Autores ===");
                        foreach (var autor in autores)
                        {
                            Console.WriteLine($"ID: {autor.Id} | Nome: {autor.Nome} | Nacionalidade: {autor.Nacionalidade}");
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Write("ID do autor a editar: ");
                        int idEditar = int.Parse(Console.ReadLine());
                        Console.Write("Novo Nome: ");
                        string novoNome = Console.ReadLine();
                        Console.Write("Nova Nacionalidade: ");
                        string novaNacionalidade = Console.ReadLine();
                        autorService.EditarAutor(idEditar, novoNome, novaNacionalidade);
                        break;

                    case 4:
                        Console.Write("ID do autor a remover: ");
                        int idRemover = int.Parse(Console.ReadLine());
                        autorService.RemoverAutor(idRemover);
                        break;

                    // CRUD para Livros
                    case 5:
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Gênero: ");
                        string genero = Console.ReadLine();
                        Console.Write("Ano de Publicação: ");
                        int ano = int.Parse(Console.ReadLine());
                        Console.Write("ID do Autor: ");
                        int autorId = int.Parse(Console.ReadLine());
                        livroService.CadastrarLivro(titulo, genero, ano, autorId);
                        break;

                    case 6:
                        var livros = livroService.ObterTodosLivros();
                        Console.WriteLine("=== Lista de Livros ===");
                        foreach (var livro in livros)
                        {
                            Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Gênero: {livro.Genero} | Ano: {livro.AnoPublicacao} | Autor: {livro.NomeAutor} ({livro.NacionalidadeAutor})");
                        }
                        Console.WriteLine();
                        break;

                    case 7:
                        Console.Write("ID do livro a editar: ");
                        int idLivroEditar = int.Parse(Console.ReadLine());
                        Console.Write("Novo Título: ");
                        string novoTitulo = Console.ReadLine();
                        Console.Write("Novo Gênero: ");
                        string novoGenero = Console.ReadLine();
                        Console.Write("Novo Ano: ");
                        int novoAno = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID do Autor: ");
                        int novoAutorId = int.Parse(Console.ReadLine());
                        livroService.EditarLivro(idLivroEditar, novoTitulo, novoGenero, novoAno, novoAutorId);
                        break;

                    case 8:
                        Console.Write("ID do livro a remover: ");
                        int idLivroRemover = int.Parse(Console.ReadLine());
                        livroService.RemoverLivro(idLivroRemover);
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.\n");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
