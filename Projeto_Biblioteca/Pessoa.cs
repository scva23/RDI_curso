
public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Livro> Livros { get; set; }

    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Livros = new List<Livro>();
    }

    public void PegarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void DevolverLivro(Livro livro)
    {
        Livros.Remove(livro);
    }
}
