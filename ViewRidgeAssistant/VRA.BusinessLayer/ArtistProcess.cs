using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class ArtistProcess : IArtistProcess
    {
        private static readonly IDictionary<int, ArtistDto> Artists = new Dictionary<int, ArtistDto>();

        public IList<ArtistDto> GetList()
        {
            return new List<ArtistDto>(Artists.Values);
        }

        public ArtistDto Get(int id)
        {
            return Artists.ContainsKey(id) ? Artists[id] : null;
        }

        public void Add(ArtistDto artist)
        {
            int max = Artists.Keys.Count == 0 ? 1 : Artists.Keys.Max(p => p) + 1;
            artist.Id = max;
            Artists.Add(max, artist);
        }

        public void Update(ArtistDto artist)
        {
            if (Artists.ContainsKey(artist.Id))
                Artists[artist.Id] = artist;
        }

        public void Delete(int id)
        {
            if (Artists.ContainsKey(id))
                Artists.Remove(id);
        }

        public IList<ArtistDto> SearchArtist(string Name, string Nation)
        {
            throw new NotImplementedException();
        }
    }
}
