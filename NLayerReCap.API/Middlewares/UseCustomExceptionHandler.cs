using Microsoft.AspNetCore.Diagnostics;
using NLayerReCap.Core.Dtos;
using NLayerReCap.Service.Exceptions;
using System.Text.Json;

namespace NLayerReCap.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        /*
               * Burada harika bir durum var yeni öğrendim.
                    * Hem mevcut sınıfımız hemde metodumuz static olması şartıylar aşağıdaki gibi 
                        public static void UserCustomException(this IApplicationBuilder app)
                      şeklinde tanımladığım metot isminde  " this IApplicationBuilder app " oluşturduğum bu static UserCustomException metodunu IApplicationBuilder
                      interface' sinin bir kontratı haline getir demektir. 
                    * Dolayısıyla bu sınıfı implement eden bütün sınıflar bu metodumuza rahatlıkla . operatoru ile rahatlıkla erişebilecekler.
         */
        public static void UserCustomException(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Burada uygulamanın mı bizim hatamız mı onu algılamak için kendimiz bir exception sınıfı oluşturup gönderip buradan yakalayacağız.

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500 // Burası swith-case-default alaındaki default kısmına denk gelmektedir.
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode,exceptionFeature.Error.Message);

                    /* 
                        * Daha önceden "ObjectResult" lar üzerinden bizim CutomResponseDto verilerimizi geri döndüğümüzden dolayı Json Serializable 
                          işlemini otomatik olara API yapmaktaydı aslında framework yapmaktadır. ancak artık bizim burada yaptığımız işlemler API' den
                          bağımsız oldğu için bunu kendimiz yapmak zorundayız.
                     */

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                    /*  Git Middleware' yi aktif hale getir.  */
                });
            });


        }
    }
}
