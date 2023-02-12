using AtChalenge.Core.DTOs;
using AtChalenge.Core.Entities;
using AtChalenge.Core.Extensions;
using AtChalenge.Core.Interfaces;
using AtChalenge.Infrastructure.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtChalenge.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var comments = await _commentService.GetComments(id);
                var results = _mapper.Map<IEnumerable<CommentDto>>(comments);
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
        public async Task<IActionResult> Post(CommentDto commentDto)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentDto);
                var result = await _commentService.CreateComment(comment);
                commentDto = _mapper.Map<CommentDto>(comment);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyCreated : MessagesAlert.NotSuccessfullyCreated,
                    Data = commentDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var result = await _commentService.GetComment(id);

        //        return StatusCode(StatusCodes.Status200OK, new ResponseModel()
        //        {
        //            IsSuccessfull = true,
        //            Message = null,
        //            Data = result
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
        //    }
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommentDto commentDto)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentDto);
                var result = await _commentService.UpdateComment(id, comment);
                commentDto = _mapper.Map<CommentDto>(comment);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyUpdated : MessagesAlert.NotSuccessfullyUpdated,
                    Data = commentDto
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
                var result = await _commentService.DeleteComment(id);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyRemoved : MessagesAlert.NotSuccessfullyDeleted,
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
