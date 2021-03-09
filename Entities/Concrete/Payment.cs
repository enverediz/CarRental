using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment: IEntity
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentTotal { get; set; }
    }
}
