
public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Status { get; set; }
    public string Locatario { get; set; }

    public Livro(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
        Status = "Disponível";  // com acento
        Locatario = string.Empty;
    }

    public void Emprestar(string nomeLocatario)
    {
        if (Status == "Disponível")
        {
            Status = "Emprestado";
            Locatario = nomeLocatario;
        }
        else
        {
            throw new Exception("Livro já está emprestado.");
        }
    }

    public void Devolver()
    {
        Status = "Disponível";  // com acento
        Locatario = "";
    }
}
