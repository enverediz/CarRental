using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);        
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile formFile,CarImage carImage);
        IResult Add(IFormFile formFile,CarImage carImage);
    }
}
