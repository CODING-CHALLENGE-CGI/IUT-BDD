using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Models
{
    public class CharacterFromEpisode
    {
        public string Name { get; set; }

        public int EpisodeId { get; set; }

        public override string ToString()
        {
            return Name + " " + EpisodeId;
        }

        public CharacterFromEpisode(string name, int episodeId)
        {
            Name = name;
            EpisodeId = episodeId;
        }
    }
}
