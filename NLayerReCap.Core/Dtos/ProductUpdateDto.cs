using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Dtos
{
    public class ProductUpdateDto
    {
        /* Bu sınıfı oluşturmamızın amacı eğer ben endpoint' in update'sine CreatedDate(BaseDto) dönmek istemiyorsam 
           ProductDto sınıfını kullanamayacaktım. Çünkü bu sınıf BaseDto sınıfını inherit etmektedir. 
           Dolayısıyla CreatedDate property' sini kullanacaktır.
           İşte bu yüzden bu sınıf oluşturuldu.
        */
        public int id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
