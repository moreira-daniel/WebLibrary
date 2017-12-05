using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary._Domain.Base
{
    public class Entity : ErrorMain, IEntity
    {
        protected Entity()
        {
            Erros = new List<string>();
        }

        [Key]
        public virtual Guid Id { get; private set; }

        public void SetId(Guid id) => Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }
}