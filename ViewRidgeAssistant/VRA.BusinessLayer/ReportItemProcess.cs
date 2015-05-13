using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VRA.Dto;
using Vra.DataAccess;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    public class ReportItemProcess : IReportItemProcess
    {
        private static readonly IReportItemDao reportDao = new ReportDao();

        private static ObservableCollection<ReportItemDto> GetCollection(IList<ReportItemDto> Items, string period, DateTime start, DateTime stop)
        {
            ObservableCollection<ReportItemDto> Collection = new ObservableCollection<ReportItemDto>();
            if (Items == null) { return null; }
            switch (period)
            {
                case "day":
                    {
                        DateTime d = start;
                        while (d <= stop)
                        {
                            ReportItemDto repItem = new ReportItemDto { date = d.Date.ToString("dd-MM-yyyy"), count = 0, price = 0 };

                            foreach (var item in Items)
                            {
                                if (Convert.ToDateTime(item.date).Date == d)
                                {
                                    repItem.count += item.count;
                                    repItem.price += item.price;
                                }

                            }

                            Collection.Add(repItem);

                            d = d.AddDays(1);

                        }

                        break;
                    }

                case "month":
                    {
                        DateTime d = start;
                        while (d <= stop)
                        {
                            ReportItemDto repItem = new ReportItemDto { date = d.Date.ToString("Y") , count = 0, price = 0 };

                            foreach (var item in Items)
                            {
                                if ((Convert.ToDateTime(item.date).Month == d.Month) && (Convert.ToDateTime(item.date).Year == d.Year))
                                {

                                    repItem.count += item.count;
                                    repItem.price += item.price;
                                }

                            }

                            Collection.Add(repItem);

                            d = d.AddMonths(1);
                        }

                        break;
                    }

                case "year":
                    {
                        DateTime d = start;
                        while (d <= stop)
                        {
                            ReportItemDto repItem = new ReportItemDto {date = d.Date.Year.ToString(), count = 0, price = 0};

                            foreach (var item in Items)
                            {
                                if (Convert.ToDateTime(item.date).Year == d.Year)
                                {
                                    repItem.count += item.count;
                                    repItem.price += item.price;
                                }

                            }

                            Collection.Add(repItem);

                            d = d.AddYears(1);
                        }

                        break;
                    }

            }
            return Collection;
        }

        public ObservableCollection<ReportItemDto> GetPurchased(string period, DateTime start, DateTime stop)
        {
            IList<ReportItemDto> ReportList;

            switch (period)
            {
                case "day":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getPurchasedPerDays(start, stop));
                        break;
                    }
                case "month":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getPurchasedPerMonth(start, stop));
                        break;
                    }

                case "year":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getPurchasedPerYear(start, stop));
                        break;
                    }
                default:
                    {
                        ReportList = null;
                        break;
                    }

            }

            return GetCollection(ReportList, period, start, stop);
        }

        public ObservableCollection<ReportItemDto> GetSaled(string period, DateTime start, DateTime stop)
        {
            IList<ReportItemDto> ReportList;

            switch (period)
            {
                case "day":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getSalesPerDay(start, stop));
                        break;
                    }
                case "month":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getSalesPerMonth(start, stop));
                        break;
                    }

                case "year":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getSalesPerYear(start, stop));
                        break;
                    }
                default:
                    {
                        ReportList = null;
                        break;
                    }

            }

            return GetCollection(ReportList, period, start, stop);
        }
    }
}
