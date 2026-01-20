
using System;
using System.Collections.Generic;


using System;
using System.Collections.Generic;
using System.Linq; // ← importante para GroupBy/Select

namespace Projeto_Biblioteca
{
    public class Biblioteca
    {
        public List<Livro> Livros { get; } = new List<Livro>();
        public List<Pessoa> Pessoas { get; } = new List<Pessoa>();

        public void CadastrarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        public void CadastrarUsuario(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        public void ListarLivros()
        {
            if (Livros.Count == 0)
            {
                Console.WriteLine("Não há livros cadastrados.");
                return;
            }

            Console.WriteLine("------ Livros ------");
            foreach (var livro in Livros)
            {
                Console.WriteLine($"ID: {livro.Id} - Título: {livro.Titulo} - Status: {livro.Status}" +
                                  (livro.Status == "Emprestado" ? $" (com {livro.Locatario})" : ""));
            }
        }

        public void RemoverDuplicadosPorId()
        {
            // Mantém o primeiro de cada ID
            var unicos = Livros
                .GroupBy(l => l.Id)
                .Select(g => g.First())
                .ToList();

            int removidos = Livros.Count - unicos.Count;
            Livros.Clear();
            Livros.AddRange(unicos);

            Console.WriteLine(removidos > 0
                ? $"🧹 Removidos {removidos} duplicados por ID."
                : "Nenhum duplicado por ID encontrado.");
        }
        
    }
}

