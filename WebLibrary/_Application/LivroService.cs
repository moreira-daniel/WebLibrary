using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebLibrary._Data.Context;
using WebLibrary._Domain;

namespace WebLibrary._Application
{
    public class LivroService : ILivroService
    {
        public LivroService()
        {
        }

        public void Delete(Guid id)
        {
            using (var context = new MainContext())
            {
                var livroToDelete = context.Livros.FirstOrDefault(x => x.Id == id);

                context.Entry(livroToDelete).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public List<Livro> GetAll()
        {
            using (var context = new MainContext())
            {
                return context.Set<Livro>().OrderBy(x => x.Nome).ToList();
            }
        }

        public Livro GetById(Guid id)
        {
            using (var context = new MainContext())
            {
                return context.Livros.FirstOrDefault(x => x.Id == id);
            }
        }

        public Livro Save(string autor, string nome)
        {
            var livro = new Livro(Guid.NewGuid(), autor, nome);

            if (!livro.IsValid())
            {
                return livro;
            }

            using (var context = new MainContext())
            {
                context.Livros.Add(livro);
                context.SaveChanges();
            }

            return livro;
        }

        public void Update(Livro livro)
        {
            using (var context = new MainContext())
            {
                context.Livros.Attach(livro);
                var entry = context.Entry(livro);

                entry.Property(e => e.Autor).IsModified = true;
                entry.Property(e => e.Nome).IsModified = true;

                context.SaveChanges();
            }
        }

        public bool VerifyIfExists(string autor, string nome)
        {
            bool exists;
            using (var context = new MainContext())
            {
                exists = context.Livros.Any(x => x.Autor == autor && x.Nome == nome);
            }

            return exists;
        }
    }
}