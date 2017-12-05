using System;
using System.Collections.Generic;

namespace WebLibrary.ViewModels
{
    public class LivroViewModel
    {
        public string Autor { get; set; }
        public IEnumerable<string> Erros { get; set; }
        public Guid Id { get; set; }
        public bool IsValid { get; set; }
        public string Nome { get; set; }
    }
}