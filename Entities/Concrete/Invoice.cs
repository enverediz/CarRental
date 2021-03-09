using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Invoice :IEntity
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int AddressId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
