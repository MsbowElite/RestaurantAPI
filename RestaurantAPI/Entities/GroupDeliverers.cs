using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class GroupDeliverers
    {
        [Key, Column(Order = 0)]
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
