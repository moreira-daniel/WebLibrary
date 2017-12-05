using System;
using WebLibrary._Domain.Base;

namespace WebLibrary._Domain
{
    public class Livro : Entity
    {
        public Livro(Guid id, string autor, string nome)
        {
            SetId(id);
            SetAutor(autor);
            SetNome(nome);
        }

        protected Livro()
        {
        }

        public string Autor { get; private set; }
        public string Nome { get; private set; }

        public void SetAutor(string autor)
        {
            if (string.IsNullOrEmpty(autor))
            {
                Erros.Add("O Autor é obrigatório");
                return;
            }

            Autor = autor;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                Erros.Add("O Nome é obrigatório");
                return;
            }

            Nome = nome;
        }
    }
}