using HitendramahajanSimplyPy.Services; 
using Microsoft.AspNetCore.Mvc; 
using System.Threading.Tasks; 
using Microsoft.Extensions.Logging; 
namespace HitendramahajanSimplyPy.Controllers 
{ 
    [ApiController] 
    [Route("api/[controller]")] 
    public class DataController : ControllerBase 
    { 
        private readonly DataFetcherService _dataFetcherService; 
        private readonly ILogger<DataController> _logger; 
        public DataController(DataFetcherService dataFetcherService, ILogger<DataController> logger) 
        { 
            _dataFetcherService = dataFetcherService; 
            _logger = logger; 
        } 
        [HttpGet("fetch")] 
        public async Task<IActionResult> FetchData(string url) 
        { 
            if (string.IsNullOrEmpty(url)) 
            { 
                _logger.LogWarning("FetchData called with empty URL."); 
                return BadRequest("URL cannot be empty."); 
            } 
            try 
            { 
                _logger.LogInformation("Fetching data from URL: {Url}", url); 
                var data = await _dataFetcherService.FetchDataFromUrlAsync(url); 
                _logger.LogInformation("Data fetched successfully from URL: {Url}", url); 
                return Ok(data); 
            } 
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "Error occurred while fetching data from URL: {Url}", url); 
                return StatusCode(500, "An error occurred while fetching data."); 
            } 
        } 
    } 
}