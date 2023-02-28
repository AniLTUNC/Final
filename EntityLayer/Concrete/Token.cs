using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Token
    {
        public string TokenValue { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
