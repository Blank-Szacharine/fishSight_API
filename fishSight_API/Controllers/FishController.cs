
using fishSight_API.Entities;
using fishSight_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fishSight_APIDatabase.Controllers
{
    [Route("api/fishes")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly IFishRepository _repository;
        private readonly ILogger<FishController> _logger;
        public FishController(IFishRepository repository, ILogger<FishController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFish()
        {
            try
            {
                var Fishes = await _repository.GetFishAsync();


                return Ok(Fishes);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        StatusCode = 500,
                        message = ex.Message
                    });
            }
        }

        [HttpGet("ById/{Id}", Name = "GetFishById")]
        public async Task<IActionResult> GetFishbyId(int Id)
        {
            try
            {
                var Fish = await _repository.GetFishByIdAsync(Id);
                if (Fish == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Record not found"
                    });
                }
                return Ok(Fish);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        StatusCode = 500,
                        message = ex.Message
                    });
            }
        }

        [HttpGet("ByEnv/{water_id}", Name = "GetFishByEnv")]
        public async Task<IActionResult> GetFishbyEnv(int water_id)
        {
            try
            {
                var Fish = await _repository.GetFishByEnv(water_id);
                if (Fish == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Record not found"
                    });
                }
                return Ok(Fish);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        StatusCode = 500,
                        message = ex.Message
                    });
            }
        }

    }
}
