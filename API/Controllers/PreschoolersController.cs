using API.Data.Service;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreschoolersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PreschoolerService _preschoolerService;

        public PreschoolersController(IMapper mapper, PreschoolerService preschoolerService)
        {
            _mapper = mapper;
            _preschoolerService = preschoolerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreschoolerGetDto>>> GetPreschoolers()
        {
            var preschoolers = await _preschoolerService.GetPreschoolersAsync();
            var preschoolersDto = _mapper.Map<IEnumerable<PreschoolerGetDto>>(preschoolers);
            return Ok(preschoolersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreschoolerGetDto>> GetPreschooler(int id)
        {
            var preschooler = await _preschoolerService.GetPreschoolerAsync(id);
            var preschoolerDto = _mapper.Map<PreschoolerGetDto>(preschooler);
            return Ok(preschoolerDto);
        }

        [HttpPost("add-preschooler")]
        public async Task<ActionResult> AddPreschooler([FromBody] PreschoolerCreateDto preschoolerDto)
        {
            var preschoolerToAdd = _mapper.Map<Preschooler>(preschoolerDto);
            await _preschoolerService.CreatePreschoolerAsync(preschoolerToAdd);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Preschooler>> UpdatePreschooler(PreschoolerUpdateDto preschoolerUpdateDto)
        {
            var preschoolerToUpdate = _mapper.Map<Preschooler>(preschoolerUpdateDto);
            await _preschoolerService.UpdatePreschoolerAsync(preschoolerToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Preschooler>> DeletePreschooler(int id)
        {
            try
            {
                await _preschoolerService.DeletePreschoolerAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
