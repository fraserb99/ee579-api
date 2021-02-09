using EE579.Domain.Models;

namespace EE579.Core.Slices.Rules.Models
{
    public class Input
    {
        public InputType Type { get; set; }
        public object Params { get; set; }
    }
}
