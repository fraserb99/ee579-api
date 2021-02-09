namespace EE579.Core.Infrastructure.Exceptions.Models
{
    public class FieldError
    {
        public FieldError(string field, string error)
        {
            Field = field;
            Error = error;
        }
        /// <summary>
        /// The name of the field
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Error message to be displayed in the form
        /// </summary>
        public string Error { get; set; }
    }
}
