using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class DisheIngredient
    {
        public Guid Id { get; set; }
        public Guid IngredientId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
