using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Price { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        ICollection<Deneme> Denemes { get; set;}

    }
}
