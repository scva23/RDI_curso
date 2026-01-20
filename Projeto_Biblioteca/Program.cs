
using System;
using System.Linq;                 // Para usar FirstOrDefault
using Projeto_Biblioteca;          // Seu namespace


using System;
using System.Linq;
using Projeto_Biblioteca;

Biblioteca biblioteca = new Biblioteca();

// Livros iniciais para testar
biblioteca.CadastrarLivro(new Livro(1, "Marina"));
biblioteca.CadastrarLivro(new Livro(2, "O Príncipe da Névoa"));
biblioteca.CadastrarLivro(new Livro(3, "Dom Casmurro"));

Console.WriteLine("Bem-vindo(a) à Biblioteca Andarna!");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Listar todos os livros");
    Console.WriteLine("2 - Emprestar livro (cadastra usuário se não existir)");
    Console.WriteLine("3 - Sair");
    Console.Write("Opção: ");

    var entrada = Console.ReadLine();

    if (!int.TryParse(entrada, out int opcaoMenu))
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
        continue;
    }

    if (opcaoMenu == 1)
    {
        biblioteca.ListarLivros();
        continue;
    }

    if (opcaoMenu == 2)
    {
        // 1) Pede o nome e cadastra automaticamente se não existir
        Console.Write("Digite o nome de quem irá pegar o livro: ");
        string? nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            continue;
        }

        // Tenta localizar usuário por nome (case-insensitive)
        var usuario = biblioteca.Pessoas
            .FirstOrDefault(p => p.Nome.Equals(nome.Trim(), StringComparison.OrdinalIgnoreCase));

        if (usuario == null)
        {
            usuario = new Pessoa(biblioteca.Pessoas.Count + 1, nome.Trim());
            biblioteca.CadastrarUsuario(usuario);
            Console.WriteLine($"✅ Usuário cadastrado: {usuario.Nome} (ID: {usuario.Id}).");
        }
        else
        {
            Console.WriteLine($"Usuário encontrado: {usuario.Nome} (ID: {usuario.Id}).");
        }

        // 2) Escolhe o livro pelo ID
        biblioteca.ListarLivros();
        Console.Write("Digite o ID do livro para emprestar: ");
        if (!int.TryParse(Console.ReadLine(), out int idLivro))
        {
            Console.WriteLine("ID inválido.");
            continue;
        }

        var livro = biblioteca.Livros.FirstOrDefault(l => l.Id == idLivro);
        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado.");
            continue;
        }

        // 3) Empresta o livro e registra na pessoa
        try
        {
            livro.Emprestar(usuario.Nome);
            usuario.PegarLivro(livro);
            Console.WriteLine($"📚 \"{livro.Titulo}\" emprestado para {usuario.Nome}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        continue;
    }

    if (opcaoMenu == 3)
    {
        Console.WriteLine("Saindo... Até mais!");
        break;
    }

    Console.WriteLine("Opção inválida. Tente novamente.");
}
