using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ICT_HocPhanServices;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.CT_HocPhanRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.GiangVienRequestDto;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CT_HocPhanController : ControllerBase
    {
        private readonly ICT_HocPhanServices _services;
        private readonly IMapper _mapper;

        public CT_HocPhanController(ICT_HocPhanServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("cthp/dssv/{malhp}")]
        public async Task<IActionResult> GetDSSVHP(string malhp)
        {
            // not
            if (!await _services.ItemExists(malhp, "", ""))
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
                data = JsonConvert.SerializeObject(await _services.GetDS_SVHocPhanAsync(malhp))
            });
        }

        [HttpGet("{malophocphan}")]
        public async Task<IActionResult> Get(string malophocphan)
        {
            // not
            if (!await _services.ItemExists(malophocphan, "", ""))
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
                data = JsonConvert.SerializeObject(await _services.GetAllAsync(malophocphan))
            });
        }

        [HttpPost("{mahocphan}")]
        public async Task<IActionResult> Post(string mahocphan, [FromBody] List<CT_HocPhanRequestDto> ct_hp)
        {
            if (ct_hp.Count <= 0 || string.IsNullOrEmpty(mahocphan))
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
                var items = _mapper.Map<List<CT_HocPhanAddDto>>(ct_hp);
                await _services.AddRangeAsync(mahocphan, items);
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

        [HttpPut("{malophocphan}")]
        public async Task<IActionResult> Put(string malophocphan, [FromBody] CT_HocPhanRequestDto ct_hp)
        {
            if (!await _services.ItemExists(malophocphan, "", ""))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                };
                return BadRequest(errorrResponse);
            }

            try
            {
                var itemDto = _mapper.Map<CT_HocPhanDto>(ct_hp);
                await _services.UpdateAsync(malophocphan, itemDto);
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

        [HttpDelete("{malophocphan}")]
        public async Task<IActionResult> Delete(string malophocphan)
        {
            if (!await _services.ItemExists(malophocphan, "", ""))
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
                await _services.DeleteAsync(malophocphan);
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
