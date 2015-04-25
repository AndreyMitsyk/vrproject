using System.Collections.Generic;

namespace VRA.BusinessLayer
{
    public interface IReportGenerator
    {
        void fillExcelTableByType(IEnumerable<object> grid, string status);
        string genHtmlWorksInGallery(string rep);
    }
}
