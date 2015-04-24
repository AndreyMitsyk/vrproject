using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess.Entities;

namespace Vra.DataAccess
{
    public interface IReportItemDao
    {
        /// <summary>
        /// Возвращает записи о купленных картинах
        /// с периодом день
        /// </summary>
        /// <param name="start"> Дата начала периода</param>
        /// <param name="end">Дата конца</param>
        /// <returns>Report о цене, количестве и дате</returns>
        IList<Report> getPurchasedPerDays(DateTime start, DateTime end);

        /// <summary>
        /// Возвращает все купленные картины с периодом 
        /// месяц
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Report о цене, количестве и дате</returns>
        IList<Report> getPurchasedPerMonth(DateTime start, DateTime end);

        /// <summary>
        /// Возвращает все купленные картины с периодом 
        /// год
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Report о цене, количестве и дате</returns>
        IList<Report> getPurchasedPerYear(DateTime start, DateTime end);

        /// <summary>
        /// Возвращает все проданные за
        /// период картины с шагом 
        /// день
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Report о цене, количестве и дате</returns>
        IList<Report> getSalesPerDay(DateTime start, DateTime end);

        /// <summary>
        /// Возвращает все проданные за
        /// период картины с шагом 
        /// месяц
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Report о цене, количестве и дате</returns>
        IList<Report> getSalesPerMonth(DateTime start, DateTime end);

        /// <summary>
        /// Возвращает все проданные за
        /// период картины с шагом 
        /// год
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Report о цене, количестве и дате</returns>
        IList<Report> getSalesPerYear(DateTime start, DateTime end);
    }
}
