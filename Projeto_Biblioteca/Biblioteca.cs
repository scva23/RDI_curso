
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca
{
    public class Biblioteca
    {
        public List<Livro> Livros { get; set; } = new List<Livro>();
        public List<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

        // Cadastrar livros
        public void CadastrarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        // Cadastrar usuários
        public void CadastrarUsuario(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        // Listar livros
        public void ListarLivros()
        {
            foreach (var livro in Livros)
            {
                Console.WriteLine($"ID: {livro.Id} - Título: {livro.Titulo} - Status: {livro.Status}");
            }
        }
    }
}
