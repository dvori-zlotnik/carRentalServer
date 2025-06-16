using Dal.Models;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    public class CarsConvert
    {
        public static async Task<Dto.Car> To_dto(Models.Car car)
        {
            Dto.Car c = new Dto.Car();
            c.Year = car.Year;
            c.Code = car.Code;
            c.BalanceInLiters = car.BalanceInLiters;
            c.LicensePlate = car.LicensePlate;
            c.PricePerHour = car.PricePerHour;
            c.Available = car.Available;
            c.Gear = car.Gear;
            c.NumberOfSeats = car.NumberOfSeats;
            c.Image = car.Image;
            
            if(car.CityNavigation != null) 
            {
                c.City_code = car.CityNavigation.Code;
                c.City = car.CityNavigation.Name;
            }
            if(car.CodeModelNavigation!=null)
            {
                Dto.Model model = ModelConvert.To_dto(car.CodeModelNavigation);
                c.Image_company = model.Image_company;
                c.DriveType = model.DriveType;
                c.DriveType_code = model.DriveType_code;
                c.Company = model.Company;
                c.Model_name = model.Model_name;
                c.TypeVehicles = model.TypeVehicles;
                c.TypeVehicles_code = model.TypeVehicles_code;
                c.size = model.size;
            }
            return c;
        }

        public static Models.Car to_dal(Dto.Car car)
        {
            Models.Car c = new Models.Car();
            c.Year = car.Year;
            c.CodeModel = car.CodeModel;
            c.LicensePlate = car.LicensePlate;
            c.BalanceInLiters = car.BalanceInLiters;
            c.Available = car.Available;
            c.Gear = car.Gear;
            c.Image = car.Image;
            c.NumberOfSeats = car.NumberOfSeats;
            c.PricePerHour = car.PricePerHour;
            c.City = car.City_code;
            c.ConsumptionPerKm = car.ConsumptionPerKm;
            return c;
        }

        public static async Task<List<Dto.Car>> to_list_dto(List<Models.Car> list)
        {
            List<Dto.Car> cars = new List<Dto.Car>();
            foreach (Models.Car car in list) 
            {
                cars.Add(To_dto(car).Result);
            }
            return  cars;
        }
    }
}
