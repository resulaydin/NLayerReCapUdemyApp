using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerReCap.Core.Dtos;

namespace NLayerReCap.API.Filters
{
    public class ValidateFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                // Errors olanlanları yani invalid olanları yani bizim modelimiz ile client' in girdiği zorunlu alanlardan eşleşmeyenler alındı.
                var errors=context.ModelState.Values
                                  .SelectMany(x => x.Errors)
                                  .Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400,errors));
            }
            
            base.OnActionExecuting(context);
        }
    }
}
