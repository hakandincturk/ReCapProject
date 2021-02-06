using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            A:
            int istenenIslem = 0;
            Console.WriteLine("\n1-)Yeni bir araba ekleme" +
                              "\n2-)Bütün Arabaları Listeleme" +
                              "\n3-)RenkId'ye Göre Arabaları Listeleme" +
                              "\n4-)BrandId'ye Göre Arabaları Listeleme");
            Console.Write("Yapmak İstediğiniz İşlemin Numarasını Giriniz:");
            try
            {
                istenenIslem = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Lütfen belirtilenlerden başka bir şey girmeyin...");
                goto A;  
            }

            switch (istenenIslem)
            {
                case 1:
                    {
                        Car addedCar = new Car();

                        Console.Write("\nBrandId giriniz:");
                        addedCar.BrandId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("RenkId giriniz:");
                        addedCar.ColorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Günlük Fiyat giriniz:");
                        addedCar.DailyPrice = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Araba İsmi giriniz:");
                        addedCar.Description = (Console.ReadLine());

                        Console.Write("Model Yılı giriniz:");
                        addedCar.ModelYear = Convert.ToUInt32(Console.ReadLine());

                        carManager.Add(addedCar);
                        break;
                    }

                case 2:
                    {
                        foreach (var car in carManager.GetAll())
                        {
                            Console.WriteLine(car.Description);
                        }
                        break;
                    }

                case 3:
                    {

                        Console.Write("RenkId giriniz:");
                        
                        foreach (var car in carManager.GetCarsByColorId(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine(car.Description);
                        }
                        break;
                    }

                case 4:
                    {
                        Console.Write("BrandId giriniz:");

                        foreach (var car in carManager.GetCarsByBrandId(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine(car.Description);
                        }
                        break;
                    }
            }

            Console.Write("\nDevam Etmek için 1'e çıkmak için 2'ye basınız:");
            istenenIslem = Convert.ToInt32(Console.ReadLine());
            switch (istenenIslem)
            {
                case 1:
                    {
                        goto A;
                    }
                case 2:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }

        }
    }
}
