using System.Collections.Generic;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    /// <summary>
    /// Описание действий с объектом художника в базе
    /// </summary>
    public interface IArtistDao
    {
        /// <summary>
        /// Получить художника по id
        /// </summary>
        /// <param name="id">id художника</param>
        /// <returns>художник</returns>
        Artist Get(int id);
        
        /// <summary>
        /// Получить список всех художников в базе
        /// </summary>
        /// <returns>список всех художников в базе</returns>
        IEnumerable<Artist> GetAll();

        /// <summary>
        /// Добавить художника в базу
        /// </summary>
        /// <param name="artist">новый художник</param>
        void Add(Artist artist);

        /// <summary>
        /// Обновить художника
        /// </summary>
        /// <param name="artist">обновленный художник</param>
        void Update(Artist artist);

        /// <summary>
        /// Удалить художника
        /// </summary>
        /// <param name="id">id удаляемого художника</param>
        void Delete(int id);

        IEnumerable<Artist> SearchArtists(string Name, string Nation);
    }
}
