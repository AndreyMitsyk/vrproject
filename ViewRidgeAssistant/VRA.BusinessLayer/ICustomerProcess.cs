using System.Collections.Generic;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface ICustomerProcess
    {
        /// <summary>
        /// Возвращает список Клиентов
        /// </summary>
        /// <returns>список Клиентов</returns>
        IList<CustomerDto> GetList();

        /// <summary>
        /// Добавляет Клиента
        /// </summary>
        /// <param name="Customer"></param>
        void Add(CustomerDto Customer);

        /// <summary>
        /// Обновляет данные о Клиенте
        /// </summary>
        /// <param name="Customer">Клиент, изменения которого надо сохранить</param>
        void Update(CustomerDto Customer);

        /// <summary>
        /// Удаляет Клиента
        /// </summary>
        /// <param name="id">id клиента, которого надо удалить</param>
        void Delete(int id);

        IList<CustomerDto> SearchCustomer(string name, string country, string city);
    }
}
