namespace BibliotecaConsoleApp.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }

        public string NomeAutor { get; set; } // opcional: útil para exibir junto ao nome do autor
        public string NacionalidadeAutor { get; set; } // opcional também
    }
}
