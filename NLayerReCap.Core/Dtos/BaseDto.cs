using NLayerReCap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Dtos
{
    public abstract class BaseDto:IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
