using System;
using System.Collections.Generic;
using WebLibrary._Domain;

namespace WebLibrary._Application
{
    public interface ILivroService
    {
        void Delete(Guid id);

        List<Livro> GetAll();

        Livro GetById(Guid id);

        Livro Save(string autor, string nome);

        void Update(Livro livro);

        bool VerifyIfExists(string autor, string nome);
    }
}