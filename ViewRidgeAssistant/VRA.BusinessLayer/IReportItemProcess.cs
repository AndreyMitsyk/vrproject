using System;
using System.Collections.ObjectModel;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public interface IReportItemProcess
    {
        ObservableCollection<ReportItemDto> GetPurchased(string period, DateTime start, DateTime stop);
        ObservableCollection<ReportItemDto> GetSaled(string period, DateTime start, DateTime stop);
    }
}
