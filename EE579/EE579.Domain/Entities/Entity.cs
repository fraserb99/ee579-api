using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Domain.Entities
{
    public class Entity
    {

    }

    public class Entity<T> : Entity
    {
        public T Id { get; set; }
    }
}
