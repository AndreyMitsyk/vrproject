using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface INationDao
    {
        /// <summary>
        /// Загрузить все национальности
        /// </summary>
        /// <returns></returns>
        IList<Nation> Load();

        /// <summary>
        /// Получить национальность по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Nation Get(int id);

        /// <summary>
        /// Очистить кеш
        /// </summary>
        void Reset();
        void Add(Nation Nation);
        void Delete(int id);
    }
}
