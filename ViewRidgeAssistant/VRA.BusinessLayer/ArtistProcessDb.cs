using System.Collections.Generic;
using Vra.DataAccess;
using VRA.BusinessLayer.Converters;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class ArtistProcessDb : IArtistProcess
    {
        private readonly IArtistDao _artistDao;

        public ArtistProcessDb()
        {
            //Получаем объект для работы с художниками в базе
            _artistDao = DaoFactory.GetArtistDao();
        }

        public IList<ArtistDto> GetList()
        {
            return DtoConverter.Convert(_artistDao.GetAll());
        }

        public ArtistDto Get(int id)
        {
            return DtoConverter.Convert(_artistDao.Get(id));
        }

        public void Add(ArtistDto artist)
        {
            _artistDao.Add(DtoConverter.Convert(artist));
        }

        public void Update(ArtistDto artist)
        {
            _artistDao.Update(DtoConverter.Convert(artist));
        }

        public void Delete(int id)
        {
            _artistDao.Delete(id);
        }

        public IList<ArtistDto> SearchArtist(string Name, string Nation)
        {
            return DtoConverter.Convert(_artistDao.SearchArtists(Name, Nation));
        }
    }
}
