using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Models
{
    public class HomePlanetCharacter
    {
        public HomePlanetCharacter(string name, string homePlanetName)
        {
            Name = name;
            HomePlanetName = homePlanetName;
        }

        public string Name { get; set; }
        public string HomePlanetName { get; set; }

        public override string ToString()
        {
            return Name + " " + HomePlanetName;
        }
    }
}
