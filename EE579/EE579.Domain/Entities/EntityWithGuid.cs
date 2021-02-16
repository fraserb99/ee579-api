using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Domain.Entities
{
    public class EntityWithGuid : Entity<Guid>
    {
        public Guid Id { get; set; }
    }
}
