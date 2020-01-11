using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class DishCalendarDateDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DishDTO Dish { get; set; }
    }
}
