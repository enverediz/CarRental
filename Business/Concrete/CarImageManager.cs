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

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarImageCorrect(carImage.CarImageId));
            if (result!=null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult();            

        }
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IResult Update(CarImage carImage)
        {
            if (CheckIfImageCountOfCarImageCorrect(carImage.CarImageId).Success)
            {
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
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }        

        private IResult CheckIfImageCountOfCarImageCorrect(int carImageId)
        {
            var result = _carImageDal.GetAll(c => c.CarImageId == carImageId).Count;
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
