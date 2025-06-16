namespace Bll
{
    public class Cities
    {
        IDal.IDal<Dto.City> idal;
        public Cities(IDal.IDal<Dto.City> dal)
        {
            idal = dal;
        }

        public async Task<List<Dto.City>> SelectAllAsync()
        {
            var cities = await idal.SelectAllAsync();
            return cities;
        }

        public async Task<int> AddAsync(Dto.City city)
        {
            int x= await idal.AddAsync(city);
            return x;
        }

        public async Task<int> DeleteAsync(int code)
        {
            return await idal.DeleteAsync(code);
        }
    }
}