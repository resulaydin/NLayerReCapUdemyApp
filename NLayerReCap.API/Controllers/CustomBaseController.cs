using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerReCap.Core.Dtos;

namespace NLayerReCap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response) where T : class 
        { 
        
            if (response.StatusCode==204) 
            {
                return new ObjectResult(null) { StatusCode=response.StatusCode };
            }
            return new ObjectResult(response) { StatusCode=response.StatusCode };
        }
    }
}
