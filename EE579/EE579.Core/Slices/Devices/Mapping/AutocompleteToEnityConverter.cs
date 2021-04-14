using AutoMapper;
using EE579.Domain;
using EE579.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE579.Core.Slices.Devices.Mapping
{
    public class AutocompleteToEntityConverter<TId, TEntity> : ITypeConverter<Entity<TId>, TEntity> where TEntity : Entity<TId>
    {
        private readonly DatabaseContext _context;
        public AutocompleteToEntityConverter(DatabaseContext context)
        {
            _context = context;
        }

        public TEntity Convert(Entity<TId> source, TEntity destination, ResolutionContext context)
        {
            return _context.Set<TEntity>().Find(source.Id);
        }
    }
}
