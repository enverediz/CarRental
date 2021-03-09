using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        [SecuredOperation("invoice.add,admin")]
        [ValidationAspect(typeof(InvoiceValidator))]
        [CacheRemoveAspect("IInvoiceService.Get")]
        public IResult Add(Invoice invoice)
        {
            _invoiceDal.Add(invoice);
            return new SuccessResult();
        }


        [CacheRemoveAspect("IInvoiceService.Get")]
        public IResult Delete(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);
            return new SuccessResult(Messages.InvoiceDeleted);
        }

        public IDataResult<List<Invoice>> GetAll()
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(), Messages.InvoicessListed);
        }

        public IDataResult<Invoice> GetById(int invoiceId)
        {
            return new SuccessDataResult<Invoice>(_invoiceDal.Get(i => i.Id == invoiceId));
        }

        [CacheRemoveAspect("IInvoiceService.Get")]
        public IResult Update(Invoice invoice)
        {
            _invoiceDal.Update(invoice);
            return new SuccessResult(Messages.InvoiceUpdated);
        }
    }
}
