using System.Data.Entity;

using WebLibrary._Domain;

namespace WebLibrary._Data.Context
{
    public interface IMainContext
    {
        IDbSet<Livro> Livros { get; set; }

        int SaveChanges();
    }
}