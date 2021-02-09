using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Exceptions.Models;

namespace EE579.Api.Examples
{
    public class FormErrorResponse
    {
        /// <summary>
        /// A list of field errors, to be used by the web interface to display feedback to the user
        /// </summary>
        public List<FieldError> Errors { get; set; }
    }
}
