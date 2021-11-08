using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrderDto
    {
       public String BasketId { get; set; }
       public int DeliveryMethodId { get; set; }
       public AddressDto ShipToAddress { get; set; } 
    }
}