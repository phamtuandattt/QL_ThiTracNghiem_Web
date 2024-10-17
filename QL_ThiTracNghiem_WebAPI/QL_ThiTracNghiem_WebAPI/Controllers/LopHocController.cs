
using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.LopHocRequestDto;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocController : ControllerBase
    {
        private readonly ILopHocServices _services;
        private readonly IMapper mapper;
        public LopHocController(ILopHocServices services, IMapper mapper)
        {
            _services = services;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _services.GetAllAsync();
            if (!lst.Any())
            {
                return NotFound(new ApiResponse()
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NO_AVAILABLE,
                    data = ""
                });
            }

            return Ok(new ApiResponse()
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(lst)
            });
        }

        [HttpGet("{malop}")]
        public async Task<IActionResult> Get(string malop)
        {
            var chk = await _services.ItemExists(malop);
            if (!chk)
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                };
                return BadRequest(errorrResponse);
            }
            var item = await _services.GetByIdAsync(malop);
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(item)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LopHocRequestDto lop)
        {
            if (string.IsNullOrEmpty(lop.MaLop) || string.IsNullOrEmpty(lop.MaKhoa))
            {
                return BadRequest(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.INVALID_OBJECT,
                    data = null
                });
            }
            var item = mapper.Map<LopHocDto>(lop);

            try
            {
                await _services.AddAsync(item);
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

        [HttpPut("{malop}")]
        public async Task<IActionResult> Put(string malop, [FromBody] LopHocRequestDto lop)
        {
            if (!await _services.ItemExists(malop) || string.IsNullOrEmpty(lop.MaLop))
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
                var itemDto = mapper.Map<LopHocDto>(lop);
                await _services.UpdateAsync(malop, itemDto);
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

        [HttpDelete("{malop}")]
        public async Task<IActionResult> DeleteItem(string malop)
        {
            if (!await _services.ItemExists(malop))
            {
                return BadRequest(new ApiResponse()
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""

                });
            }
            await _services.DeleteAsync(malop);
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = ""
            });
        }
    }
}
