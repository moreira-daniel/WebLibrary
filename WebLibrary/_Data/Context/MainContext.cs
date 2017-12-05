using System.Data.Entity;
using WebLibrary._Data.Config;
using WebLibrary._Domain;

namespace WebLibrary._Data.Context
{
    public class MainContext : DbContext, IMainContext
    {
        public MainContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LivroConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}