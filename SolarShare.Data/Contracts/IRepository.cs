namespace SolarShare.Data.Contracts
{
    public interface IRepository
    {
        Task<IEnumerable<SolarData>> GetAllSolarDataAsync();
        Task<SolarData> GetSolarDataByDateAsync(DateTime date);
        Task<IEnumerable<SolarData>> GetSolarDataByMonthAsync(DateTime date);
        Task<IEnumerable<SolarData>> GetSolarDataByYearAsync(DateTime date);
    }
}
