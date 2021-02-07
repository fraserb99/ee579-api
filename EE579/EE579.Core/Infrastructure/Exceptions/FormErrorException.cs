using System.Collections.Generic;
using EE579.Core.Infrastructure.Exceptions.Models;

namespace EE579.Core.Infrastructure.Exceptions
{
    public class FormErrorException : HttpStatusCodeException
    {
        private List<FieldError> FieldErrors { get; set; }

        public FormErrorException(FieldError error) 
            : base(400)
        {
            FieldErrors = new List<FieldError> {error};
        }

        public FormErrorException(IEnumerable<FieldError> errors)
            : base(400)
        {
            FieldErrors = new List<FieldError>(errors);
        }

        protected override object RenderBodyCore()
        {
            return new
            {
                Errors = FieldErrors
            };
        }
    }
}
