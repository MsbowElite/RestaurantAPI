using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class MenuDisheDTO
    {
        public Guid MenuId { get; set; }
        public Guid DisheId { get; set; }
    }
}
