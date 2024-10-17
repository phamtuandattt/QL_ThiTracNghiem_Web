

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebAPI.Common;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.ChucVuRequestDto;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuServices _chucVuServices;
        private readonly IMapper mapper;

        public ChucVuController(IChucVuServices chucVuServices, IMapper mapper)
        {
            _chucVuServices = chucVuServices;
            this.mapper = mapper;
        }

        // GET: api/<ChucVuController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _chucVuServices.GetAllAsync();
            if (!lst.Any())
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                });
            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(lst)
            });
        }

        // GET api/<ChucVuController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _chucVuServices.ItemExists(id))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                };
                return BadRequest(errorrResponse);
            }

            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(await _chucVuServices.GetByIdAsync(id))
            });
        }

        // POST api/<ChucVuController>
        [HttpPost]
        public ActionResult<Chucvu> Post([FromBody] ChucVuRequestDto chucVu)
        {
            if (chucVu.TenChucVu == null || chucVu.TenChucVu == "")
            {
                return BadRequest(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.INVALID_OBJECT,
                    data = null
                });
            }
            try
            {
                var item = mapper.Map<ChucVuDto>(chucVu);
                _chucVuServices.AddAsync(item);
            }
            catch (DbUpdateException)
            {

            }

            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = ""
            });
        }

        // PUT api/<ChucVuController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, [FromBody] ChucVuRequestDto chucvu)
        {
            if (!await _chucVuServices.ItemExists(id) || string.IsNullOrEmpty(chucvu.TenChucVu))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                };
                return NotFound(errorrResponse);
            }

            try
            {
                var item = mapper.Map<ChucVuDto> (chucvu);
                await _chucVuServices.UpdateAsync(id, item);
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = ""
            });
        }

        // DELETE api/<ChucVuController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var item = _chucVuServices.chucvu(id);
            if (!await _chucVuServices.ItemExists(id))
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                });
            }
            
            try
            {
                await _chucVuServices.DeleteAsync(id);
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.NoContent + "",
                message = ApiResponseMessage.SUCCESS,
                data = ""
            });
        }
    }
}
