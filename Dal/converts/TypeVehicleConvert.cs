using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    internal class TypeVehicle
    {
        public TypeVehicle()
        {

        }



        public static Dto.TypeVehicle to_dto(Models.TypeVehicle type)
        {
          Dictionary<string, string> toconvert = new Dictionary<string, string>();
            toconvert.Add("A", "קטן");
            toconvert.Add("B", "משפחתי");
            toconvert.Add("C", "גדול");
            toconvert.Add("D", "משאית");
            Dto.TypeVehicle t = new Dto.TypeVehicle();
            t.Description = type.Description;
            if(toconvert.ContainsKey(type.Description))
            {
                t.Size = toconvert[type.Description];
            }
                //+" "+ toconvert[type.Description];
            t.Code = type.Code;
            return t;
        }
       public static Models.TypeVehicle to_dal(Dto.TypeVehicle type)
        {
            Models.TypeVehicle t = new Models.TypeVehicle();
            t.Description = type.Description;
            return t;
        }
       public static List<Dto.TypeVehicle> to_dto_list(List<Models.TypeVehicle> types) 
        {
            List<Dto.TypeVehicle> to_list = new List<Dto.TypeVehicle>();
            foreach (var type in types)
            {
                to_list.Add(to_dto(type));
            }
            return to_list;
        }


    }
}
