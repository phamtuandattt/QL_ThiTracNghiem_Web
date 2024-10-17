using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IGiangVienServices;
using QL_ThiTracNghiem_WebAPI.Common;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.GiangVienRequestDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienServices _services;
        private readonly IMapper _mapper;
        
        public GiangVienController(IGiangVienServices services, IMapper mapper)
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

        [HttpGet("{magiangvien}")]
        public async Task<IActionResult> Get(string magiangvien)
        {
            if (!await _services.ItemExists(magiangvien))
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
                data = JsonConvert.SerializeObject(await _services.GetByIdAsync(magiangvien))
            });
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GiangVienRequestDto giangvien)
        {
            // Create ModelDto to Add
            // Add mapping profile
            if (giangvien.Magv == null)
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
                var item = _mapper.Map<GiangVienAddDto>(giangvien);
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

        [HttpPut("{magiangvien}")]
        public async Task<IActionResult> Put(string magiangvien, [FromBody] GiangVienDto giangvien)
        {
            if (!await _services.ItemExists(magiangvien) || string.IsNullOrEmpty(giangvien.Magv))
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
                var itemDto = _mapper.Map<GiangVienDto>(giangvien);
                await _services.UpdateAsync(magiangvien, itemDto);
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

        [HttpDelete("{magiangvien}")]
        public async Task<IActionResult> Delete(string magiangvien)
        {
            if (!await _services.ItemExists(magiangvien))
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
                await _services.DeleteAsync(magiangvien);
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
