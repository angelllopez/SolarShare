using Microsoft.AspNetCore.Mvc;

namespace SolarShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolarDataController : ControllerBase
    {
        private readonly SolarDataRepository _repo;


        /// <summary>
        /// Initializes a new instance of the SolarDataController class.
        /// </summary>
        /// <param name="SolarDataRepository">
        /// A SolarDataRepository type that represents the dependency injected.
        /// </param>
        public SolarDataController(SolarDataRepository repository)
        {
            _repo = repository;
        }

        // GET: api/<SolarDataController>
        /// <summary>
        /// Asynchronously retrieves all the production data records from the repository and 
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 
        /// or 404. If the production data is available, it returns Ok(data). If not,
        /// it returns NotFound().
        /// </summary>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSolarData()
        {
            var data = await _repo.GetAllSolarDataAsync();

            if (!data.Any())
            {
                return NotFound();
            }

            return Ok(data);
        }

        // GET api/<SolarDataController>/5
        /// <summary>
        /// Asynchronously retrives a single solar data record from the repository and 
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 or 404.
        /// If record property date matches the date parameter, it returns Ok(data). If not,
        /// it returns NotFound().
        /// </summary>
        /// <param name="date">
        /// A DateTime value that specifies the date to filter the solar data records.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns> 
        [HttpGet("{date}")]
        [Route("GetSolarDataByDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSolarDataByDayAsync(DateTime date)
        {
            var data = await _repo.GetProductionDataByDay(date);

            return data.Id < 1 ? NotFound() : Ok(data);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of solar data records from a repository and 
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 or 404.
        /// If record properties Date.Month and Date.Year matches the date.month and date.year parameters, 
        /// it returns Ok(data). If not, it returns NotFound().
        /// or returns a 404 status code if no record is found.
        /// </summary>
        /// <param name="date">
        /// A DateTime value that specifies the month and year to filter the production data records.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpGet]
        [Route("GetProductionDataByMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductionDataByMonthAsync(DateTime date)
        {
            var data = await _repo.GetProductionDataByMonth(date);

            return !data.Any() ? NotFound() : Ok(data);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of production data records from a repository and
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 or 404.
        /// If record property Date.Year matches the date.year parameter, it returns Ok(data).
        /// If not, it returns NotFound().
        /// </summary>
        /// <param name="date">
        /// A DateTime value that specifies the year to filter the production data records.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpGet]
        [Route("GetProductionDataByYear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductionDataByYearAsync(DateTime date)
        {
            var data = await _repo.GetProductionDataByYear(date);

            return !data.Any() ? NotFound() : Ok(data);
        }

    }
}
