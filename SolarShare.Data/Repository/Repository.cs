using SolarShare.Data.Contracts;

namespace SolarShare.Data.Repository
{
    public class Repository : IRepository
    {
        public Task<IEnumerable<SolarData>> GetAllSolarDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SolarData> GetSolarDataByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolarData>> GetSolarDataByMonthAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolarData>> GetSolarDataByYearAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
