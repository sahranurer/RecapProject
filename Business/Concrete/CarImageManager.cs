using Business.Abstract;
using Business.Constans;
using Core.Business;
using Core.Utilities;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarPictureLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImagesDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetbyCarId(int id)
        {
            var result = BusinessRules.Run(CheckCarImage(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(c => c.CarId == id));
        }

       

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImagesDal.Update(carImage);
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult CheckCarPictureLimit(int CarId)
        {
            var results = _carImagesDal.GetAll(c => c.CarId == CarId).Count;
            if (results>5)
            {
                return new ErrorResult(Messages.PhotoLimitExceeded);
            }
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c => c.ID == imageId));
        }
    }
}
