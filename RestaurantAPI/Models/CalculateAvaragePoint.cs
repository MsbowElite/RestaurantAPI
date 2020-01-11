using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class CalculatePoint
    {
        public double CalculateAvarageDistance(PointDTO point1, PointDTO point2, PointDTO point3)
        {
            var memo1 = Math.Pow((point1.x - point2.x), 2);
            var memo2 = Math.Pow((point1.y - point2.y), 2);
            var memo3 = Math.Pow((point1.x - point3.x), 2);
            var memo4 = Math.Pow((point1.y - point3.y), 2);
            var memo5 = Math.Pow((point2.x - point3.x), 2);
            var memo6 = Math.Pow((point2.y - point3.y), 2);


            return (Math.Sqrt(memo1 + memo2 + memo3 + memo4 + memo5 + memo6));
        }
    }
}
