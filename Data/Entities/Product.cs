using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Solution.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "money")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to 0")]
        public int Price { get; set; }
        [Range(0, 100, ErrorMessage = "Please enter a value between 0 and 100")]
        public float DiscountPercent { get; set; } = 0;
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
