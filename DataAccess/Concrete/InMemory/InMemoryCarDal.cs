using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car(){ Id= 1, BrandId=1, ColorId = "#fff", DailyPrice = 10, ModelYear=1999, Description="Beyaz Araba 1"},
                new Car(){ Id= 2, BrandId=1, ColorId = "#ccc", DailyPrice = 10, ModelYear=1995, Description="Gri Araba 1"},
                new Car(){ Id= 3, BrandId=2, ColorId = "#fff", DailyPrice = 10, ModelYear=1999, Description="Beyaz Araba 2"},
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car car = _cars.SingleOrDefault(p => p.Id == id);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
