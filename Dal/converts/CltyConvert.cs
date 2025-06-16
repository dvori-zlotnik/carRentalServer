using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    internal class CltyConvert
    {
        public static Dto.City To_dto(Models.City city)
        {
            Dto.City c = new Dto.City();
            c.Code = city.Code;
            c.Name = city.Name;
            return c;
        }
        public static Models.City to_dal(Dto.City city)
        {
            Models.City c = new Models.City();
            c.Name = city.Name;
            return c;
        }
        public static List<Dto.City> to_list_dto(List<Models.City> list) 
        {
            List<Dto.City> cities = new List<Dto.City>();
            foreach (var item in list) 
            {
                cities.Add(To_dto(item));
            }
            return cities;
        }
    }
}
