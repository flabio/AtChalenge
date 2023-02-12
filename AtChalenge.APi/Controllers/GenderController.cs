using AtChalenge.Core.DTOs;
using AtChalenge.Core.Entities;
using AtChalenge.Core.Extensions;
using AtChalenge.Core.Interfaces;
using AtChalenge.Infrastructure.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AtChalenge.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;
        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var genders = await _genderService.GetGenders();
                var results = _mapper.Map<IEnumerable<GenderDto>>(genders);
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Data = results
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(GenderDto genderDto)
        {
            try
            {
                var gender = _mapper.Map<Gender>(genderDto);
                var result = await _genderService.CreateGender(gender);
                genderDto = _mapper.Map<GenderDto>(gender);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyCreated : MessagesAlert.NotSuccessfullyCreated,
                    Data = genderDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _genderService.GetGender(id);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = null,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GenderDto genderDto)
        {
            try
            {
                var gender = _mapper.Map<Gender>(genderDto);
                var result = await _genderService.UpdateGender(id, gender);
                genderDto = _mapper.Map<GenderDto>(gender);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyUpdated : MessagesAlert.NotSuccessfullyUpdated,
                    Data = genderDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Detele(int id)
        {
            try
            {
                var result = await _genderService.DeleteGender(id);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result? MessagesAlert.SuccessfullyRemoved : MessagesAlert.NotSuccessfullyDeleted,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }
    }
}
