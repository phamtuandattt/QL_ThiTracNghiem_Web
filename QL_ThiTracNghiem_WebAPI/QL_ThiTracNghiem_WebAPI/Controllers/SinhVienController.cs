using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.SinhVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ISinhVienServices;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.GiangVienRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.SinhVienRequestDto;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : Controller
    {
        private readonly ISinhVienServices _services;
        private readonly IMapper _mapper;

        public SinhVienController(ISinhVienServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _services.GetAllAsync();
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

        [HttpGet("{masinhvien}")]
        public async Task<IActionResult> Get(string masinhvien)
        {
            if (!await _services.ItemExists(masinhvien))
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
                data = JsonConvert.SerializeObject(await _services.GetByIdAsync(masinhvien))
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SinhVienRequestDto sinhvien)
        {
            try
            {
                var item = _mapper.Map<SinhVienAddDto>(sinhvien);
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

        [HttpPut("{masinhvien}")]
        public async Task<IActionResult> Put(string masinhvien, [FromBody] SinhVienRequestDto sinhvienDto)
        {
            if (!await _services.ItemExists(masinhvien))
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
                var itemDto = _mapper.Map<SinhVienDto>(sinhvienDto);
                await _services.UpdateAsync(masinhvien, itemDto);
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
        [HttpDelete("{masinhvien}")]
        public async Task<IActionResult> Delete(string masinhvien)
        {
            if (!await _services.ItemExists(masinhvien))
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
                await _services.DeleteAsync(masinhvien);
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
