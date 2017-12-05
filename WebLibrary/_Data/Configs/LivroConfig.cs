using System.Data.Entity.ModelConfiguration;

using WebLibrary._Domain;

namespace WebLibrary._Data.Config
{
    public class LivroConfig : EntityTypeConfiguration<Livro>
    {
        public LivroConfig()
        {
            ToTable("Livros");

            HasKey(u => u.Id);

            Property(c => c.Autor).IsRequired().HasMaxLength(256);
            Property(c => c.Nome).IsRequired().HasMaxLength(256);
        }
    }
}