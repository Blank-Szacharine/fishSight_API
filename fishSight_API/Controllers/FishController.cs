
using fishSight_API.Entities;
using fishSight_API.Models;
using fishSight_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fishSight_APIDatabase.Controllers
{
    [Route("api/fishes")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly IFishRepository _repository;
        private readonly ILogger<FishController> _logger;
        private readonly FinsapContext _ctx;
        public FishController(IFishRepository repository, ILogger<FishController> logger, FinsapContext ctx)
        {
            _repository = repository;
            _logger = logger;
            _ctx = ctx;
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

        [HttpGet("ByName/{Id}", Name = "GetFishByName")]
        public async Task<IActionResult> GetFishbyName(string Id)
        {
            try
            {
                var Fish = await _repository.GetFishByNameAsync(Id);
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
        [HttpGet("ByRegion/{region}", Name = "GetFishByReg")]
        public async Task<IActionResult> GetFishbyRegion(string region)
        {
            try
            {
                var Fish = await _repository.GetFishByReg(region);
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


        [HttpGet("ByFamily/{family_id}", Name = "GetFishByFam")]
        public async Task<IActionResult> GetFishbyFamily(int family_id)
        {
            try
            {
                var Fish = await _repository.GetFishByFam(family_id);
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


        [HttpGet("ByNameall", Name = "GetFishByNameall")]
        public async Task<IActionResult> GetFishbyNameall()
        {
            try
            {
                var Fish = await _repository.GetFishByNameallAsync();
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



        [HttpGet("ByFamilyall", Name = "GetFamily")]
        public async Task<IActionResult> GetFamily()
        {
            try
            {
                var Fish = await _ctx.FishFamilies.ToListAsync();
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

        [HttpPost("AddFish", Name = "addFish")]
        public async Task<IActionResult> AddFish(Fish_complete fish)
        {
            try
            {
                var Fish = await _ctx.FishFamilies.ToListAsync();
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
