using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;       

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;            
        }

        [SecuredOperation("carimage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.Id));
            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();            

        }
        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) 
                + _carImageDal.Get(i => i.Id == carImage.Id).ImagePath;
            var result = BusinessRules.Run(FileHelper.DeleteAsync(oldpath));

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            if (CheckCarImageLimit(carImage.Id).Success)
            {
                var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot"))
                + _carImageDal.Get(i => i.Id == carImage.Id).ImagePath;

                carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);
                carImage.Date = DateTime.Now;

                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.CarImageUpdated);
            }
            return new ErrorResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == 0)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
        }        

        private IResult CheckCarImageLimit(int carImageId)
        {
            var result = _carImageDal.GetAll(c => c.Id == carImageId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.ImageCountOfCarImageError);
            }
            return new SuccessResult();
        }
        

        //private IResult DateAssignmentOfSystem()
        //{
        //    var result = _carService.GetAll();
        //    if (result.Data.)
        //    {

        //    }


        //}
    }
}
