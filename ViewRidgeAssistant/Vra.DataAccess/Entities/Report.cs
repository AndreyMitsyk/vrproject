using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vra.DataAccess.Entities
{
    public class Report
    {
        public DateTime date { get; set; }
        public int count { get; set; }
        public decimal price { get; set; }
    }
}
