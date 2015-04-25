using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.BusinessLayer
{
    public interface IReportGenerator
    {
        void fillExcelTableByType(List<object> grid, string status);
        string genHtmlWorksInGallery(string rep);
    }
}
