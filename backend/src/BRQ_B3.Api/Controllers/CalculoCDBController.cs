using AutoMapper;
using BRQ_B3.Api.ViewModels;
using BRQ_B3.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using BRQ_B3.Business.Models;

namespace BRQ_B3.API.Controllers
{
    [Route("api/calculoCdb")]
    [ApiController]
    public class CalculoCDBController : ControllerBase
    {
        private readonly ICalculoCDBRepository _calculoCdbRepository;
        private readonly ICalculoCDBService _calculoCdbervice;
        private readonly IMapper _mapper;

        public CalculoCDBController(ICalculoCDBRepository calculoCdbRepository, ICalculoCDBService calculoCdbervice, IMapper mapper)
        {
            _calculoCdbRepository = calculoCdbRepository;
            _calculoCdbervice = calculoCdbervice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CDBResultViewModel>>> GetAll()
        {
            var result = _mapper.Map<List<CDBResultViewModel>>(await _calculoCdbRepository.GetAll());

            if (result == null || !result.Any())
            {
                return Ok(new List<CDBResultViewModel>());
            }

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CDBResultViewModel>> GetId(Guid id)
        {
            var result = _mapper.Map<CDBResultViewModel>(await _calculoCdbRepository.GetId(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CDBResultViewModel>> Add(CDBCalculoViewModel calculoCdbViewModel)
        {

            if (calculoCdbViewModel == null)
                return NotFound();

            var result = await _calculoCdbervice.Add(_mapper.Map<CalculoCDB>(calculoCdbViewModel));

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CDBResultViewModel>(result));
        }

        [HttpPut]
        public async Task<ActionResult<CDBResultViewModel>> Update(CDBCalculoViewModel calculoCdbViewModel)
        {
            var result = await _calculoCdbervice.Update(_mapper.Map<CalculoCDB>(calculoCdbViewModel));

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CDBResultViewModel>(result));

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {

            var result = await _calculoCdbervice.Delete(id);

            if (result == false)
                return NotFound();

            return Ok(result);
        }
    }
}
