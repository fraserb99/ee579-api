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
    public class MACStringToDeviceConverter : ITypeConverter<string, Device>
    {
        private readonly DatabaseContext _context;
        public MACStringToDeviceConverter(DatabaseContext context)
        {
            _context = context;
        }
        public Device Convert(string source, Device destination, ResolutionContext context)
        {
            return _context.Devices.FirstOrDefault(x => x.Id == source);
        }
    }
}
