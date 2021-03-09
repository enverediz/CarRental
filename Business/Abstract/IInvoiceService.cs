using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        IDataResult<List<Invoice>> GetAll();
        IDataResult<Invoice> GetById(int invoiceId);
        IResult Delete(Invoice invoice);
        IResult Update(Invoice invoice);
        IResult Add(Invoice invoice);
    }
}
