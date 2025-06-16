using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converts
{
    internal class ModelConvert
    {
        public static Dto.Model To_dto(Models.Model model)
        {
            Dto.Model m = new Dto.Model();
            m.Code = model.Code;
            m.Model_name = model.Model1;
            m.TypeVehicles_code = model.TypeVehicles;
            if (model.TypeVehiclesNavigation != null)
            {
                Dto.TypeVehicle typeVehicle = converts.TypeVehicle.to_dto(model.TypeVehiclesNavigation);
                m.TypeVehicles = typeVehicle.Description;
                m.size = typeVehicle.Size;
            }
            if (model.DriveTypeNavigation != null)
            {
                m.DriveType = model.DriveTypeNavigation.Description;
                m.DriveType_code = model.DriveTypeNavigation.Code;
            }
            if (model.CodeCompanyNavigation != null)
            {
                m.Company = model.CodeCompanyNavigation.Name;
                m.Image_company = model.CodeCompanyNavigation.Image;
            }
           return m;
        }
        public static Models.Model To_dal(Dto.Model model) 
        {
            Models.Model m = new Models.Model();
            m.CodeCompany = model.CodeCompany;
            m.DriveType = model.DriveType_code;
            m.TypeVehicles = model.TypeVehicles_code;
            m.Model1 = model.Model_name;
            return m;
        }

        public static List<Dto.Model> to_list_dto(List<Models.Model> model) 
        {
            List<Dto.Model> m = new List<Dto.Model>();
            foreach(Models.Model mo in model)
            {
                m.Add(To_dto(mo));
            }
            return m;
        }

    }
}
