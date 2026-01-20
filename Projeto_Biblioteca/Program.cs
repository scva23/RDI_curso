using Projeto_Biblioteca;

Biblioteca biblioteca = new Biblioteca();
Livro Marina = new Livro(1, "Marina");
Livro OprincipedaNevoa = new Livro(2, "O Príncipe da Névoa");

biblioteca.CadastrarLivro(Marina);
biblioteca.CadastrarLivro(OprincipedaNevoa);

biblioteca.ListarLivros();

