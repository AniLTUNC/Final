using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        public Country Country { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
    }
}
