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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CT_HocPhanRequestDto ct_hp)
        {
            if (string.IsNullOrEmpty(ct_hp.Malophocphan) ||
                string.IsNullOrEmpty(ct_hp.Masv) ||
                string.IsNullOrEmpty(ct_hp.Mahocphan))
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
                var item = _mapper.Map<CT_HocPhanAddDto>(ct_hp);
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
    }
}
