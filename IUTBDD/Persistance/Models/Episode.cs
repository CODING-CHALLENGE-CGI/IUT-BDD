using System.Collections.Generic;

namespace Persistance.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Character Hero { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}
