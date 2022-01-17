﻿using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetbyCarId(int id);
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete( CarImage carImage);
        IDataResult<CarImage> GetByImageId(int imageId);
        IResult Update(IFormFile file, CarImage carImage);

    }
}
