using System;

namespace WebLibrary._Domain.Base
{
    public interface IEntity
    {
        Guid Id { get; }

        void SetId(Guid id);
    }
}