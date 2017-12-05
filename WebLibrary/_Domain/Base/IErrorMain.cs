using System.Collections.Generic;

namespace WebLibrary._Domain.Base
{
    public interface IErrorMain
    {
        ICollection<string> Erros { get; set; }

        void AddError(string erro);

        bool IsValid();
    }
}