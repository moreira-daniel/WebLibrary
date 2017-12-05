using System.Collections.Generic;

namespace WebLibrary._Domain.Base
{
    public class ErrorMain : EntityBase, IErrorMain
    {
        protected ErrorMain()
        {
            Erros = new List<string>();
        }

        public ICollection<string> Erros { get; set; }

        public void AddError(string erro)
        {
            if (!string.IsNullOrEmpty(erro))
            {
                Erros.Add(erro);
            }
        }

        public bool IsValid() => Erros.Count <= 0;
    }
}