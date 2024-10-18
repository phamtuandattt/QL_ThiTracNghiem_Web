using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IHocPhanServices;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.GiangVienRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.HocPhanRequestDto;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocPhanController : ControllerBase
    {
        private readonly IHocPhanServices _services;
        private readonly IMapper _mapper;

        public HocPhanController(IHocPhanServices services, IMapper mapper)
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

        [HttpGet("{mahp}")]
        public async Task<IActionResult> Get(string mahp)
        {
            if (!await _services.ItemExists(mahp))
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
                data = JsonConvert.SerializeObject(await _services.GetByIdAsync(mahp))
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] HocPhanRequestDto hp)
        //{
        //    // Create ModelDto to Add
        //    // Add mapping profile
        //    if (hp.Mahocphan == null)
        //    {
        //        return BadRequest(new ApiResponse
        //        {
        //            status = HttpStatusCode.NotFound + "",
        //            message = ApiResponseMessage.INVALID_OBJECT,
        //            data = null
        //        });
        //    }

        //    try
        //    {
        //        var item = _mapper.Map<HocPhanAddDto>(hp);
        //        await _services.AddAsync(item);
        //    }
        //    catch (DbUpdateException)
        //    {

        //    }
        //    return Ok(new ApiResponse
        //    {
        //        status = HttpStatusCode.NoContent + "",
        //        message = ApiResponseMessage.SUCCESS,
        //        data = ""
        //    });
        //}

        //[HttpPut("{mahp}")]
        //public async Task<IActionResult> Put(string mahp, [FromBody] HocPhanRequestDto hocPhan)
        //{
        //    if (!await _services.ItemExists(mahp))
        //    {
        //        var errorrResponse = new ApiResponse
        //        {
        //            status = HttpStatusCode.NotFound + "",
        //            message = ApiResponseMessage.NOT_FOUND,
        //            data = ""
        //        };
        //        return NotFound(errorrResponse);
        //    }

        //    try
        //    {
        //        var itemDto = _mapper.Map<HocPhanDto>(hocPhan);
        //        await _services.UpdateAsync(mahp, itemDto);
        //    }
        //    catch (DbUpdateException)
        //    {

        //    }
        //    return Ok(new ApiResponse
        //    {
        //        status = HttpStatusCode.OK + "",
        //        message = ApiResponseMessage.SUCCESS,
        //        data = ""
        //    });
        //}

        //[HttpDelete("{mahp}")]
        //public async Task<IActionResult> Delete(string mahp)
        //{
        //    if (!await _services.ItemExists(mahp))
        //    {
        //        return NotFound(new ApiResponse
        //        {
        //            status = HttpStatusCode.NotFound + "",
        //            message = ApiResponseMessage.NOT_FOUND,
        //            data = ""
        //        });
        //    }

        //    try
        //    {
        //        await _services.DeleteAsync(mahp);
        //    }
        //    catch (DbUpdateException)
        //    {

        //    }
        //    return Ok(new ApiResponse
        //    {
        //        status = HttpStatusCode.NoContent + "",
        //        message = ApiResponseMessage.SUCCESS,
        //        data = ""
        //    });
        //}
    }
}
