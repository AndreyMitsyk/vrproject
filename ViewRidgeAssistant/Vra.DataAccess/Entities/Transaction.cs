using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vra.DataAccess.Entities
{
    public class Transaction
    {
        public int TransID;
        public int? CustomerID;
        public int WorkId;
        public DateTime? DateAcquired;
        public decimal? AcquisitionPrice;
        public DateTime? PurchaseDate;
        public decimal? SalesPrice;
        public decimal? AskingPrice;
    }
}
