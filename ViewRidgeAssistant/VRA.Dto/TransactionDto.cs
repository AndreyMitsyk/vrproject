using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRA.Dto
{
    public class TransactionDto
    {
        public int TransactionID { get; set; }
        public CustomerDto Customer { get; set; }
        public WorkDto Work { get; set; }
        public DateTime? DateAcquired { get; set; }
        public decimal? AcquisitionPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? AskingPrice { get; set; }
    }
}
