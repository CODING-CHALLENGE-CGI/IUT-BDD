using Persistance.Models;
using System.Collections.Generic;

namespace Persistance.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Human> Humans { get; set; }
    }
}
